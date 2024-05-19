using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Bug_Traking
{
    public partial class SupportProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["support"] != null)
            {
                if (!IsPostBack)
                {
                    Tabels.Support sp = Session["support"] as Tabels.Support;
                    Literal1.Text = "<img src='pic/" + sp.PicUrl + "' id='PicPro' width='60' height='60' align='middle' />";
                    txtName.Text = sp.Name;
                    txtFamily.Text = sp.Family;
                    txtUser.Text = sp.UserName;
                    txtPass.Text = sp.PassWord;
                    txtPass2.Text = sp.PassWord;
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();
            Tabels.Support sp = Session["support"] as Tabels.Support;
            if (TextBox1.Text == sp.PassWord)
            {
                db.Support.Where(c => c.ID == sp.ID).Load();
                db.Support.Local[0].PassWord = txtPass.Text;
                db.Support.Local[0].UserName = txtUser.Text;
                db.Support.Local[0].Name = txtName.Text;
                db.Support.Local[0].Family = txtFamily.Text;
                if (UplPic.HasFile)
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(UplPic.FileName);
                    string Extention = fi.Extension;
                    if (Extention == ".jpg" || Extention == ".png")
                    {
                        string FileName = db.Support.Local[0].ID.ToString() + fi.Extension;
                        if (db.Support.Local[0].PicUrl != "Def.png")
                            System.IO.File.Delete(Server.MapPath(".") + "/pic/" + db.Support.Local[0].PicUrl);
                        UplPic.PostedFile.SaveAs(Server.MapPath(".") + @"/pic/" + FileName);
                        db.Support.Local[0].PicUrl = FileName;
                    }
                    else
                    {
                        litMess.Text = "<div class='OKPM' style='color:#a10f0f;background:#f39393;box-shadow:0px 0px 10px #f39393;'>پسوند فایل صحیح نمیباشد</div>";
                        return;
                    }
                }
                Session["support"] = db.Support.Local[0];
                db.SaveChanges();
                litMess.Text = "<div class='OKPM'>عملیات با موفقیت انجام شد</div>";
            }
            else
            {
                litMess.Text = "<div class='OKPM' style='color:#a10f0f;background:#f39393;box-shadow:0px 0px 10px #f39393;'>گذرواژه قبلی صحیح نیست</div>";
            }
        }
    }
}