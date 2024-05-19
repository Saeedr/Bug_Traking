using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Bug_Traking
{
    public partial class ClientTiketDell : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                int ID = int.Parse(Request.QueryString["id"].ToString());
                DataBaseContext db = new DataBaseContext();
                Tabels.User sp = Session["user"] as Tabels.User;
                db.Tikets.Where(c => c.ID == ID && c.UserID == sp.ID).Load();
                if (db.Tikets.Local.Count != -1 && db.Tikets.Local[0].UserID == sp.ID)
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
                    string sss = obj.Description;
                    byte[] a = { 10 };
                    char[] b = System.Text.Encoding.UTF8.GetChars(a);
                    sss = sss.Replace("#br#", "<br />");
                    litSendDate.Text = s;
                    litPart.Text = obj.Part;
                    litProject.Text = obj.ProjectName;
                    litService.Text = obj.Service;
                    litStatus.Text = obj.Status;
                    litTitle.Text = obj.Title;
                    litCategori.Text = obj.Category;
                    litDiscription.Text = sss;
                    litShowDate.Text = s2;
                    litOlaviat.Text = obj.Priority.ToString();
                    litSystem.Text = obj.Ssystem;
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
                    litOlaviat.Text = "یافت نشد";
                    litSystem.Text = "یافت نشد";
                }
            }
            else
            {
                Response.Redirect("ClientTicketsKartable.aspx");
            }
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(Request.QueryString["id"].ToString());
            DataBaseContext db = new DataBaseContext();
            db.Tikets.Where(c => c.ID == ID).Load();
            if (db.Tikets.Local.Count != -1)
            {
                db.Tikets.Local[0].Status = "حذف شده";
                db.SaveChanges();
                Response.Redirect("ClientTicketsKartable.aspx");
            }
        }
    }
}