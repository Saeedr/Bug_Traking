using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Web.Services;

namespace Bug_Traking
{
    public partial class Default : System.Web.UI.Page
    {

        [WebMethod(EnableSession = true)]
        public static string Login(string user,string pass,string role)
        {
            if (role == "1")
            {
                if (user == "admin" && user == "admin")
                {
                    HttpContext.Current.Session.Add("admin", "ok");
                    HttpContext.Current.Session.Timeout = 525600;
                    return "admin";
                }
                else
                {
                    if (user != "admin")

                         return "نام کاربری صحیح نیست";
                    else if (pass != "admin")

                        return "گذرواژه صحیح نیست";
                }
            }
            else if (role == "2")
            {
                DataBaseContext db = new DataBaseContext();
                db.Support.Where(c => c.UserName == user && c.PassWord == pass).Load();
                if (db.Support.Local.Count != 0)
                {
                    Tabels.Support user1 = new Tabels.Support();
                    user1.Name = db.Support.Local[0].Name;
                    user1.ID = db.Support.Local[0].ID;
                    user1.Family = db.Support.Local[0].Family;
                    user1.PassWord = db.Support.Local[0].PassWord;
                    user1.PicUrl = db.Support.Local[0].PicUrl;
                    user1.UserName = db.Support.Local[0].UserName;
                    HttpContext.Current.Session.Add("support", user1);
                    HttpContext.Current.Session.Timeout = 525600;
                    return "user";
                }
                else
                {
                    DataBaseContext db2 = new DataBaseContext();
                    db2.Support.Where(c => c.UserName == user).Load();
                    if (db2.Support.Local.Count <= 0)
                    {
                        return "نام کاربری صحیح نیست";
                    }
                    else
                    {
                        return "گذرواژه صحیح نیست";
                    }
                }
            }
            return "Z";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["admin"] != null || Session["support"] != null)
            //{
            //}
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue == "1")
            {
                if (txtUser.Text == "admin" && txtPass.Text == "123mnbXSW$")
                {
                    Session.Add("admin", "ok");
                    Session.Timeout = 525600;
                    Response.Redirect("AdminKartable.aspx");
                }
                else
                {
                    if (txtUser.Text != "admin")

                        Literal1.Text = "<div class='OKPM' style='color:#a10f0f;background:#f39393;box-shadow:0px 0px 10px #f39393;'>نام کاربری صحیح نیست</div>";
                    else if (txtPass.Text != "admin")

                        Literal1.Text = "<div class='OKPM' style='color:#a10f0f;background:#f39393;box-shadow:0px 0px 10px #f39393;'>گذرواژه صحیح نیست</div>";
                }
            }
            else if (RadioButtonList1.SelectedValue == "3")
            {
                //DataBaseContext db = new DataBaseContext();
                //db.Users.Where(c => c.UserName == txtUser.Text && c.PassWord == txtPass.Text).Load();
                //if (db.Users.Local.Count != 0)
                //{
                //    Tabels.User user = new Tabels.User();
                //    user.Name = db.Users.Local[0].Name;
                //    user.ID = db.Users.Local[0].ID;
                //    user.Family = db.Users.Local[0].Family;
                //    user.PassWord = db.Users.Local[0].PassWord;
                //    user.PicUrl = db.Users.Local[0].PicUrl;
                //    user.UserName = db.Users.Local[0].UserName;
                //    Session.Add("user", user);
                //    Session.Timeout = 525600;
                //    Response.Redirect("ClientTicketsKartable.aspx");
                //}
            }
            else if (RadioButtonList1.SelectedValue == "2")
            {
                DataBaseContext db = new DataBaseContext();
                db.Support.Where(c => c.UserName == txtUser.Text && c.PassWord == txtPass.Text).Load();
                if (db.Support.Local.Count != 0)
                {
                    Tabels.Support user = new Tabels.Support();
                    user.Name = db.Support.Local[0].Name;
                    user.ID = db.Support.Local[0].ID;
                    user.Family = db.Support.Local[0].Family;
                    user.PassWord = db.Support.Local[0].PassWord;
                    user.PicUrl = db.Support.Local[0].PicUrl;
                    user.UserName = db.Support.Local[0].UserName;
                    Session.Add("support", user);
                    Session.Timeout = 525600;
                    Response.Redirect("SupportDashboard.aspx");
                }
                else
                {
                    DataBaseContext db2 = new DataBaseContext();
                    db2.Support.Where(c => c.UserName == txtUser.Text).Load();
                    if (db2.Support.Local.Count <= 0)
                    {
                        Literal1.Text = "<div class='OKPM' style='color:#a10f0f;background:#f39393;box-shadow:0px 0px 10px #f39393;'>نام کاربری صحیح نیست</div>";
                    }
                    else
                    {
                        Literal1.Text = "<div class='OKPM' style='color:#a10f0f;background:#f39393;box-shadow:0px 0px 10px #f39393;'>گذرواژه صحیح نیست</div>";
                    }
                }
            }
        }
    }
}