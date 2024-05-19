using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Bug_Traking
{
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                liDate.Text = "امروز : " + pc.GetYear(DateTime.Now) + "/" + pc.GetMonth(DateTime.Now) + "/" + pc.GetDayOfMonth(DateTime.Now);
                DataBaseContext db = new DataBaseContext();
                Tabels.User sp = Session["user"] as Tabels.User;
                db.Users.Where(c => c.ID == sp.ID).Load();
                if (db.Users.Local.Count != -1)
                {
                    litTopProp.Text = "<img src='pic/" + db.Users.Local[0].PicUrl + "' width='60' height='60' /><span style='display:block;float:right;margin-right:10px;color:#FFF;margin-top:25px;'>خوش آمدید " + db.Users.Local[0].Name + " " + db.Users.Local[0].Family + "</span>";
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }
    }
}