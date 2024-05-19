using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.UI.WebControls;

namespace Bug_Traking
{
    public partial class SupportTiketShow : System.Web.UI.Page
    {
        public void FillTickOK(string id2)
        {
            try
            {
                Guid id = Guid.Parse(id2);
                drpKhataOK.Items.Clear();
                DataBaseContext db = new DataBaseContext();
                db.TiketOK.Where(c => c.CategoryID == id).Load();
                foreach (var obj in db.TiketOK.Local)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.ID.ToString();
                    li.Text = obj.Name;
                    drpKhataOK.Items.Add(li);
                }
                int ID = int.Parse(Request.QueryString["id"].ToString());
                DataBaseContext db2 = new DataBaseContext();
                db2.Tikets.Where(c => c.ID == ID).Load();
                try { drpKhataOK.Items.FindByText(db2.Tikets.Local[0].TicketOK).Selected = true; }
                catch { }
            }
            catch { }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["support"] != null)
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        int ID = int.Parse(Request.QueryString["id"].ToString());
                        DataBaseContext db = new DataBaseContext();
                        Tabels.Support sp = Session["support"] as Tabels.Support;

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
                        if (db.Tikets.Local.Count != -1)
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
                            FillTickOK(obj.CatID);
                            db.TikSupport.Where(c => c.SupportID == sp.ID && c.TikID == ID).Load();
                            if (db.TikSupport.Local.Count > 0)
                            {
                                if (db.TikSupport.Local[0].Status == "جدید")
                                    db.TikSupport.Local[0].Status = "در حال بررسی";
                                if (db.TikSupport.Local[0].Text != null)
                                {
                                    txtTickatAddDet.Text = db.TikSupport.Local[0].Text.Replace("#br#", b[0].ToString());
                                }
                                if (db.Tikets.Local[0].SeenData == null)
                                {
                                    db.Tikets.Local[0].SeenData = DateTime.Now;
                                }
                                litStatus.Text = db.TikSupport.Local[0].Status;
                                db.SaveChanges();
                                int id3 = db.TikSupport.Local[0].ID;
                                db.Comment.Where(c => c.TikSupID == id3).Load();
                                foreach (var obj1 in db.Comment.Local)
                                {
                                    Literal1.Text += "<div style='width: 90%; margin-bottom: 10px; background:url(pic/LoginBG2.png); padding: 1%; margin-right: 4%; padding-top: 7px; padding-bottom: 7px;border:solid 1px #bebcbc;'>" + obj1.Text.Replace("#br#", "<br />") + "</div>";
                                }
                            }

                            List<string> keys = obj.keyWords.Split(',').ToList<string>();
                            var tik = (from p in db.Tikets where p.ID != ID select p);
                            foreach (var tik2 in tik)
                            {
                                string[] nkey = tik2.keyWords.Split(',');
                                foreach (string q in nkey)
                                {
                                    if (keys.IndexOf(q) != -1)
                                    {
                                        Literal2.Text += @"<a href='SupportTiketShow.aspx?id=" + tik2.ID + "' style='color:#ffffff;text-decoration:none;display:inline;font-size:14px;background:url(pic/LoginBG2.png);padding:5px;margin-right:5px;margin-top:5px;'>" + tik2.Title + "</a>";
                                        break;
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
                        Response.Redirect("SupportSearch.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(Request.QueryString["id"].ToString());
            DataBaseContext db = new DataBaseContext();
            db.TikSupport.Where(c => c.TikID == ID).Load();
            db.Tikets.Where(c => c.ID == ID).Load();
            for (int i = 0; i <= db.TikSupport.Local.Count - 1; i++)
            {
                byte[] a = { 10 };
                char[] b = System.Text.Encoding.UTF8.GetChars(a);
                txtTickatAddDet.Text = txtTickatAddDet.Text.Replace((b[0]).ToString(), "#br#");
                db.TikSupport.Local[i].Status = "بسته شده";
                db.TikSupport.Local[i].Text = txtTickatAddDet.Text;
            }
            try
            {
                db.Tikets.Local[0].TicketOK = drpKhataOK.SelectedItem.Text;
            }
            catch { }
            db.SaveChanges();
            Response.Redirect("SupportSearch.aspx");
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
            if (litCategori.SelectedIndex != -1)
            {
                FillTickOK(litCategori.SelectedItem.Value);
            }
            byte[] a = { 10 };
            char[] b = System.Text.Encoding.UTF8.GetChars(a);
            db.Tikets.Local[0].Description = litDiscription.Text.Replace(b[0].ToString() , "#br#");
            db.SaveChanges();
            Response.Redirect("SupportSearch.aspx");
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
            litCategori_SelectedIndexChanged(null, null);
        }

        protected void litCategori_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}