using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Text;

namespace Bug_Traking
{
    public partial class AdminTiketShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int ID = int.Parse(Request.QueryString["id"].ToString());
                    DataBaseContext db = new DataBaseContext();

                    db.Projects.Load();
                    foreach (var obj in db.Projects.Local)
                    {
                        ListItem li = new ListItem();
                        li.Value = obj.ID.ToString();
                        li.Text = obj.Name;
                        litProject.Items.Add(li);
                    }
                    litProject_SelectedIndexChanged(null, null);
                    db.Priority.Load();
                    foreach (var obj in db.Priority.Local)
                    {
                        ListItem li = new ListItem();
                        li.Value = obj.ID.ToString();
                        li.Text = obj.Name;
                        liOlaviat.Items.Add(li);
                    }

                    db.Tikets.Where(c => c.ID == ID).Load();
                    if (db.Tikets.Local.Count > 0)
                    {
                        var obj = db.Tikets.Local[0];
                        DateTime dt = obj.SendData;
                        System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                        string s = pc.GetYear(dt) + "/" + pc.GetMonth(dt) + "/" + pc.GetDayOfMonth(dt);
                        string s2 = "مشاهده نشده";
                        if (obj.SeenData != null)
                        {
                            DateTime dt2 = obj.SeenData.Value;
                            s2 = pc.GetYear(dt2) + "/" + pc.GetMonth(dt2) + "/" + pc.GetDayOfMonth(dt2);
                        }
                        liOlaviat.Items.FindByValue(obj.Priority).Selected = true;
                        string sss = obj.Description;
                        byte[] a = { 10 };
                        char[] b = System.Text.Encoding.UTF8.GetChars(a);
                        sss = sss.Replace("#br#", b[0].ToString());
                        litSendDate.Text = s;
                        litPart2.Text = obj.Part;
                        litProject2.Text = obj.ProjectName;
                        litService2.Text = obj.Service;
                        litStatus.Text = obj.Status;
                        litTitle.Text = obj.Title;
                        litCategori2.Text = obj.Category;
                        litDiscription.Text = sss;
                        litShowDate.Text = s2;
                        liOlaviat.Text = obj.Priority.ToString();
                        litSystem2.Text = obj.Ssystem;
                        Literal2.Text = obj.TicketOK;
                        db.SaveChanges();

                        db.TikSupport.Where(c => c.TikID == ID).Load();
                        foreach (var obj2 in db.TikSupport.Local)
                        {
                            var z = (from p in db.Support where p.ID == obj2.SupportID select p).Single();
                            if (obj2.Text != null)
                            {
                                Literal3.Text += z.Name + " " + z.Family + " ( " + obj2.Status + " ) :<br />" + obj2.Text.Replace("#br#", "<br />") + "<hr />";
                            }
                            else
                            {
                                Literal3.Text += z.Name + " " + z.Family + " ( " + obj2.Status + " ) :<br /><hr />";
                            }

                            DataBaseContext db2 = new DataBaseContext();
                            db2.Support.Where(c => c.ID == obj2.SupportID).Load();
                            if(db2.Support.Local.Count>0)
                            {
                                ListItem li = new ListItem();
                                li.Value = obj2.ID.ToString();
                                li.Text = db2.Support.Local[0].Name + " " + db2.Support.Local[0].Family;
                                CheckBoxList1.Items.Add(li);

                                int id3 = obj2.ID;
                                db2.Comment.Where(c => c.TikSupID == id3).Load();
                                foreach (var obj1 in db2.Comment.Local)
                                {
                                    Literal1.Text += "<div style='width: 90%; margin-bottom: 10px; background:url(pic/LoginBG2.png); padding: 1%; margin-right: 4%; padding-top: 7px; padding-bottom: 7px;border:solid 1px #bebcbc;'>" + db2.Support.Local[0].Name + " " + db2.Support.Local[0].Family + " :<br />" + obj1.Text.Replace("#br#", "<br />") + "</div>";
                                }
                            }
                        }

                    }
                    else
                    {
                        litSendDate.Text = "یافت نشد";
                        litPart.Text = "یافت نشد";
                        litProject.Text = "یافت نشد";
                        litService.Text = "یافت نشد";
                        litStatus.Text = "یافت نشد";
                        litTitle.Text = "یافت نشد";
                        litCategori.Text = "یافت نشد";
                        litDiscription.Text = "یافت نشد";
                        litShowDate.Text = "یافت نشد";
                        liOlaviat.Text = "یافت نشد";
                        litSystem.Text = "یافت نشد";
                    }
                }
                else
                {
                    Response.Redirect("AdminKartable.aspx");
                }
            }
        }

        protected void litProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            litSystem.Items.Clear();
            if (litProject.SelectedIndex != -1)
            {
                DataBaseContext db = new DataBaseContext();
                Guid ID = Guid.Parse(litProject.SelectedValue);
                db.Ssystem.Where(c => c.ProjectID == ID).Load();
                foreach (var obj in db.Ssystem.Local)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.ID.ToString();
                    li.Text = obj.Name;
                    litSystem.Items.Add(li);
                }
            }
            litSystem_SelectedIndexChanged(null, null);
        }

        protected void litSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            litService.Items.Clear();
            if (litSystem.SelectedIndex != -1)
            {
                DataBaseContext db = new DataBaseContext();
                Guid ID = Guid.Parse(litSystem.SelectedValue);
                db.Service.Where(c => c.SsystemID == ID).Load();
                foreach (var obj in db.Service.Local)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.ID.ToString();
                    li.Text = obj.Name;
                    litService.Items.Add(li);
                }
            }
            litService_SelectedIndexChanged(null, null);
        }

        protected void litService_SelectedIndexChanged(object sender, EventArgs e)
        {
            litPart.Items.Clear();
            if (litService.SelectedIndex != -1)
            {
                DataBaseContext db = new DataBaseContext();
                Guid ID = Guid.Parse(litService.SelectedValue);
                db.Parts.Where(c => c.ServiceID == ID).Load();
                foreach (var obj in db.Parts.Local)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.ID.ToString();
                    li.Text = obj.Name;
                    litPart.Items.Add(li);
                }
            }
            litPart_SelectedIndexChanged(null, null);
        }

        protected void litPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            litCategori.Items.Clear();
            if (litPart.SelectedIndex != -1)
            {
                DataBaseContext db = new DataBaseContext();
                Guid ID = Guid.Parse(litPart.SelectedValue);
                db.Category.Where(c => c.PartsID == ID).Load();
                foreach (var obj in db.Category.Local)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.ID.ToString();
                    li.Text = obj.Name;
                    litCategori.Items.Add(li);
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(Request.QueryString["id"].ToString());
            DataBaseContext db = new DataBaseContext();
            db.Tikets.Where(c => c.ID == ID).Load();
            db.Tikets.Local[0].Title = litTitle.Text;
            db.Tikets.Local[0].Priority = liOlaviat.SelectedItem.Value;
            try
            {
                db.Tikets.Local[0].Category = litCategori.SelectedItem.Text;
            }
            catch { db.Tikets.Local[0].Category = ""; }
            try
            {
                db.Tikets.Local[0].Part = litPart.SelectedItem.Text;
            }
            catch { db.Tikets.Local[0].Part = ""; }

            try
            {
                db.Tikets.Local[0].ProjectName = litProject.SelectedItem.Text;
            }
            catch { db.Tikets.Local[0].ProjectName = ""; }

            try
            {
                db.Tikets.Local[0].Service = litService.SelectedItem.Text;
            }
            catch { db.Tikets.Local[0].Service = ""; }

            try
            {
                db.Tikets.Local[0].Ssystem = litSystem.SelectedItem.Text;
            }
            catch { db.Tikets.Local[0].Ssystem = ""; }

            try
            {
                db.Tikets.Local[0].CatID = litCategori.SelectedItem.Text;
            }
            catch { db.Tikets.Local[0].CatID = ""; }

            byte[] a = { 10 };
            char[] b = System.Text.Encoding.UTF8.GetChars(a);
            db.Tikets.Local[0].Description = litDiscription.Text.Replace(b[0].ToString(), "#br#");
            db.SaveChanges();
            Response.Redirect("AdminTiketShow.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();
            foreach (ListItem li in CheckBoxList1.Items)
            {
                if (li.Selected == true)
                {
                    Tabels.Comment ts = new Tabels.Comment();
                    byte[] a = { 10 };
                    char[] b = Encoding.UTF8.GetChars(a);
                    ts.Text = txtTickatAddDet.Text.Replace(b.ToString(),"#br#");
                    ts.TikSupID = int.Parse(li.Value);
                    db.Comment.Add(ts);
                }
            }
            db.SaveChanges();
            Response.Redirect("AdminTiketShow.aspx?id=" + Request.QueryString["id"].ToString());
        }
    }
}