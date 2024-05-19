using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Data.Entity;
using System.Globalization;
using System.Collections;
using System.Web.Services;

namespace Bug_Traking
{
    public partial class ClientPortal : System.Web.UI.Page
    {



        [WebMethod]
        public static ArrayList ZirSystem(string id)
        {
            ArrayList li = new ArrayList();
            DataBaseContext db = new DataBaseContext();
            Guid ID = Guid.Parse(id);
            db.Ssystem.Where(c => c.ProjectID == ID).Load();
            foreach (var obj in db.Ssystem.Local)
            {
                ListItem li2 = new ListItem();
                li2.Value = obj.ID.ToString() + "§" + obj.Name;
                li2.Text = obj.Name;
                li.Add(li2);
            }
            return li;
        }

        [WebMethod]
        public static ArrayList Service(string id)
        {
            ArrayList li = new ArrayList();
            DataBaseContext db = new DataBaseContext();
            Guid ID = Guid.Parse(id);
            db.Service.Where(c => c.SsystemID == ID).Load();
            foreach (var obj in db.Service.Local)
            {
                ListItem li2 = new ListItem();
                li2.Value = obj.ID.ToString() + "§" + obj.Name;
                li2.Text = obj.Name;
                li.Add(li2);
            }
            return li;
        }

        [WebMethod]
        public static ArrayList Part(string id)
        {
            ArrayList li = new ArrayList();
            DataBaseContext db = new DataBaseContext();
            Guid ID = Guid.Parse(id);
            db.Parts.Where(c => c.ServiceID == ID).Load();
            foreach (var obj in db.Parts.Local)
            {
                ListItem li2 = new ListItem();
                li2.Value = obj.ID.ToString() + "§" + obj.Name;
                li2.Text = obj.Name;
                li.Add(li2);
            }
            return li;
        }

        [WebMethod]
        public static ArrayList Category(string id)
        {
            ArrayList li = new ArrayList();
            DataBaseContext db = new DataBaseContext();
            Guid ID = Guid.Parse(id);
            db.Category.Where(c => c.PartsID == ID).Load();
            foreach (var obj in db.Category.Local)
            {
                ListItem li2 = new ListItem();
                li2.Value = obj.ID.ToString() + "§" + obj.Name;
                li2.Text = obj.Name;
                li.Add(li2);
            }
            return li;
        }

        [WebMethod]
        public static ArrayList FillGhabli(string date, string code)
        {
            ArrayList li = new ArrayList();
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            DataBaseContext db2 = new DataBaseContext();
            db2.Tikets.Where(c => c.Title.Contains(code)).Load();
            foreach (var obj in db2.Tikets.Local)
            {
                string s = pc.GetYear(obj.SendData) + "/" + pc.GetMonth(obj.SendData) + "/" + pc.GetDayOfMonth(obj.SendData);
                if (date == s || date.Length < 2)
                {
                    ListItem li2 = new ListItem();
                    li2.Value = obj.ID.ToString();
                    li2.Text = obj.IDName;
                    li.Add(li2);
                }
            }
            return li;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBaseContext db = new DataBaseContext();
                db.Projects.Load();
                foreach (var obj in db.Projects.Local)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.ID.ToString() + "§" + obj.Name;
                    li.Text = obj.Name;
                    drpTickatAddProject.Items.Add(li);
                }
                drpTickatAddProject_SelectedIndexChanged(null, null);
                db.Priority.Load();
                foreach (var obj in db.Priority.Local)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.ID.ToString();
                    li.Text = obj.Name;
                    drpTickatAddPriority.Items.Add(li);
                }
            }
        }

        protected void btnTicketSend_Click(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();
            Tabels.Tikets oTikets = new Tabels.Tikets();
            oTikets.SendData = DateTime.Now;
            string sss = txtTickatAddDet.Text;
            byte[] a = { 10 };
            char[] b = Encoding.UTF8.GetChars(a);
            sss = sss.Replace((b[0]).ToString(), "#br#");
            oTikets.Description = sss;
            if (TicketUpload.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in TicketUpload.PostedFiles)
                {
                    FileInfo FI = new FileInfo(uploadedFile.FileName);
                    if (((uploadedFile.ContentLength / 1024) / 1024) < 10)
                    {
                        string FileName = System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString() + FI.Extension;
                        uploadedFile.SaveAs(Server.MapPath(".") + @"/Upload/" + FileName);
                        oTikets.FileName += FileName + ",";
                        Response.Write(((uploadedFile.ContentLength / 1024) / 1024) + " < " + 10 + "<br />");
                    }
                }
            }
            string[] s = Request.Form[drpTickatAddPart.UniqueID].Split('§');
            oTikets.Part = s[1];
            oTikets.Priority = drpTickatAddPriority.SelectedItem.Text;
            s = Request.Form[drpTickatAddProject.UniqueID].Split('§');
            oTikets.ProjectName = s[1];
            s = Request.Form[drpTickatAddService.UniqueID].Split('§');
            oTikets.Service = s[1];
            s = Request.Form[drpTickatAddSsystem.UniqueID].Split('§');
            oTikets.Ssystem = s[1];
            s = Request.Form[drpTickatAddCategory.UniqueID].Split('§');
            oTikets.Category = s[1];
            oTikets.Title = txtTickatAddTitle.Text;
            oTikets.UserName = txtUserName.Text;
            Tabels.User sp = Session["user"] as Tabels.User;
            oTikets.UserID = sp.ID;
            string Tags = Request.Form["inputTagator"];
            string[] s2 = Tags.Split(',');
            oTikets.KeyWords(s2);
            oTikets.Status = "جدید";
            if (HRabt.Value != "")
                oTikets.LastErrorID = int.Parse(HRabt.Value);
            db.Tikets.Add(oTikets);
            db.SaveChanges();
            lblTickatAddStatus.ForeColor = System.Drawing.Color.LightGreen;
            lblTickatAddStatus.Text = "عملیات با موفقیت انجام شد";
            Response.Redirect("ClientTicketsKartable.aspx");
        }

        protected void drpTickatAddProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpTickatAddSsystem.Items.Clear();
            if (drpTickatAddProject.SelectedIndex != -1)
            {
                DataBaseContext db = new DataBaseContext();
                string[] s = drpTickatAddProject.SelectedValue.Split('§');
                Guid ID = Guid.Parse(s[0]);
                db.Ssystem.Where(c => c.ProjectID == ID).Load();
                foreach (var obj in db.Ssystem.Local)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.ID.ToString();
                    li.Text = obj.Name;
                    drpTickatAddSsystem.Items.Add(li);
                }
            }
            drpTickatAddSsystem_SelectedIndexChanged(null, null);
        }

        protected void drpTickatAddSsystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpTickatAddService.Items.Clear();
            if (drpTickatAddSsystem.SelectedIndex != -1)
            {
                DataBaseContext db = new DataBaseContext();
                string[] s = drpTickatAddSsystem.SelectedValue.Split('§');
                Guid ID = Guid.Parse(s[0]);
                db.Service.Where(c => c.SsystemID == ID).Load();
                foreach (var obj in db.Service.Local)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.ID.ToString();
                    li.Text = obj.Name;
                    drpTickatAddService.Items.Add(li);
                }
            }
                drpTickatAddService_SelectedIndexChanged(null, null);
        }

        protected void drpTickatAddService_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpTickatAddPart.Items.Clear();
            if (drpTickatAddService.SelectedIndex != -1)
            {
                DataBaseContext db = new DataBaseContext();
                string[] s = drpTickatAddService.SelectedValue.Split('§');
                Guid ID = Guid.Parse(s[0]);
                db.Parts.Where(c => c.ServiceID == ID).Load();
                foreach (var obj in db.Parts.Local)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.ID.ToString();
                    li.Text = obj.Name;
                    drpTickatAddPart.Items.Add(li);
                }
            }
                drpTickatAddPart_SelectedIndexChanged(null, null);
        }

        protected void drpTickatAddPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpTickatAddCategory.Items.Clear();
            if (drpTickatAddPart.SelectedIndex != -1)
            {
                DataBaseContext db = new DataBaseContext();
                string[] s = drpTickatAddPart.SelectedValue.Split('§');
                Guid ID = Guid.Parse(s[0]);
                db.Category.Where(c => c.PartsID == ID).Load();
                foreach (var obj in db.Category.Local)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.ID.ToString();
                    li.Text = obj.Name;
                    drpTickatAddCategory.Items.Add(li);
                }
            }
        }
    }
}