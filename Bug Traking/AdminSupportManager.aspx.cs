using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.Entity;
using System.Web.UI.WebControls;

namespace Bug_Traking
{
    public partial class AdminSupportManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Fill();
            }
        }

        private void Fill()
        {
            DropDownList1.Items.Clear();
            DataBaseContext db = new DataBaseContext();
            db.Support.Load();
            foreach (var obj in db.Support.Local)
            {
                ListItem li = new ListItem();
                li.Text = obj.Name + " " + obj.Family;
                li.Value = obj.ID.ToString();
                DropDownList1.Items.Add(li);
            }
            DropDownList1_SelectedIndexChanged(null, null);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();
            Tabels.Support sp = new Tabels.Support();
            db.Support.Where(c => c.UserName == txtUser.Text).Load();
            if (db.Support.Local.Count <= 0)
            {
                sp.Name = txtName.Text;
                sp.Family = txtFamily.Text;
                sp.UserName = txtUser.Text;
                sp.PassWord = txtPass.Text;
                sp.PicUrl = "Def.png";
                sp.Tell = txtAddTell.Text;
                db.Support.Add(sp);
                db.SaveChanges();
                Fill();
                litMess.Text = "<div class='OKPM'>عملیات با موفقیت انجام شد</div>";
                txtName.Text = txtFamily.Text = txtAddTell.Text = txtUser.Text = "";
            }
            else
            {
                litMess.Text = "<div class='OKPM' style='color:#a10f0f;background:#f39393;box-shadow:0px 0px 10px #f39393;'>این نام کاربری موجود میباشد</div>";
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex != -1)
            {
                DataBaseContext db = new DataBaseContext();
                int id = int.Parse(DropDownList1.SelectedItem.Value);
                db.Support.Where(c => c.ID == id).Load();
                TextBox1.Text = db.Support.Local[0].Name;
                TextBox2.Text = db.Support.Local[0].Family;
                TextBox3.Text = db.Support.Local[0].UserName;
                TextBox4.Text = db.Support.Local[0].PassWord;
                TextBox5.Text = db.Support.Local[0].Tell;
            }
            litMess.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();
            int id = int.Parse(DropDownList1.SelectedItem.Value);
            db.Support.Where(c => c.ID == id).Load();
            db.Support.Local[0].Name = TextBox1.Text;
            db.Support.Local[0].Family = TextBox2.Text;
            db.Support.Local[0].UserName = TextBox3.Text;
            db.Support.Local[0].PassWord = TextBox4.Text;
            db.Support.Local[0].Tell = TextBox5.Text;
            db.SaveChanges();
            Fill();
            litMess.Text = "<div class='OKPM'>عملیات با موفقیت انجام شد</div>";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();
            int id = int.Parse(DropDownList1.SelectedItem.Value);
            db.Support.Where(c => c.ID == id).Load();
            db.Support.Remove(db.Support.Local[0]);
            db.SaveChanges();
            Fill();
            litMess.Text = "<div class='OKPM'>عملیات با موفقیت انجام شد</div>";
        }
    }
}