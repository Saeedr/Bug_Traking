using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Bug_Traking
{
    public partial class ClientProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Tabels.User sp = Session["user"] as Tabels.User;
                Literal1.Text = "<img src='pic/" + sp.PicUrl + "' id='PicPro' width='60' height='60' align='middle' />";
                txtName.Text = sp.Name;
                txtFamily.Text = sp.Family;
                txtUser.Text = sp.UserName;
                txtPass.Text = sp.PassWord;
                txtPass2.Text = sp.PassWord;
            }
            else
            {
                Response.Redirect(Server.MapPath("Default.aspx"));
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();
            Tabels.User sp = Session["user"] as Tabels.User;
            db.Users.Where(c => c.ID == sp.ID).Load();
            db.Users.Local[0].PassWord = txtPass.Text;
            db.Users.Local[0].UserName = txtUser.Text;
            db.Users.Local[0].Name = txtName.Text;
            db.Users.Local[0].Family = txtFamily.Text;
            if (UplPic.HasFile)
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(UplPic.FileName);
                string Extention = fi.Extension;
                if (Extention == ".jpg" || Extention == ".png")
                {
                    string FileName = db.Users.Local[0].ID.ToString() + fi.Extension;
                    if (db.Users.Local[0].PicUrl != "Def.png")
                        System.IO.File.Delete(Server.MapPath(".") + "/pic/" + db.Users.Local[0].PicUrl);
                    UplPic.PostedFile.SaveAs(Server.MapPath(".") + @"/pic/" + FileName);
                    db.Users.Local[0].PicUrl = FileName;
                }
                else
                {
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "پسوند فایل متعبر نیست (پسوندهای مجاز png,jpg)";
                    return;
                }
            }
            db.SaveChanges();
            lblStatus.ForeColor = System.Drawing.Color.LightGreen;
            lblStatus.Text = "عملیات با موفقیت انجام شد";
        }
    }
}