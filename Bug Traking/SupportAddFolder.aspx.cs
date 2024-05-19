using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bug_Traking
{
    public partial class SupportAddFolder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();
            Tabels.Folders fl = new Tabels.Folders();
            fl.Name = txtName.Text;
            Tabels.Support sp = Session["support"] as Tabels.Support;
            fl.UserID = sp.ID;
            fl.UserStatus = "Support";
            db.Folders.Add(fl);
            txtName.Text = "";
            db.SaveChanges();
            litMess.Text = "<div class='OKPM'>عملیات با موفقیت انجام شد</div>";
        }
    }
}