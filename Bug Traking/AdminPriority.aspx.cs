using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Bug_Traking
{
    public partial class AdminProject : System.Web.UI.Page
    {
        private void FillCombo()
        {
            drpSelect.Items.Clear();
            DataBaseContext db = new DataBaseContext();
            db.Priority.Load();
            foreach (var obj in db.Priority.Local)
            {
                ListItem li = new ListItem();
                li.Value = obj.ID.ToString();
                li.Text = obj.Name;
                drpSelect.Items.Add(li);
            }
            drpSelect_SelectedIndexChanged(null, null);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillCombo();
            }
        }

        protected void btnTicketSend_Click(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();
            Tabels.Priority pr = new Tabels.Priority();
            pr.Name = txtTickatAddTitle.Text;
            pr.Timee = int.Parse(TextBox1.Text);
            db.Priority.Add(pr);
            db.SaveChanges();
            txtTickatAddTitle.Text = "";
            TextBox1.Text = "";
            FillCombo();
            litMess.Text = "<div class='OKPM'>عملیات با موفقیت انجام شد</div>";
        }

        protected void drpSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpSelect.SelectedIndex != -1)
            {
                DataBaseContext db = new DataBaseContext();
                Int32 ID = Int32.Parse(drpSelect.SelectedValue);
                db.Priority.Where(c => c.ID == ID).Load();
                txtEdit.Text = db.Priority.Local[0].Name;
                TextBox2.Text = db.Priority.Local[0].Timee.ToString();
            }
            litMess.Text = "";
        }

        protected void btnEdir_Click(object sender, EventArgs e)
        {
            if (drpSelect.SelectedIndex != -1)
            {
                DataBaseContext db = new DataBaseContext();
                Int32 ID = Int32.Parse(drpSelect.SelectedValue);
                db.Priority.Where(c => c.ID == ID).Load();
                db.Priority.Local[0].Name = txtEdit.Text;
                db.Priority.Local[0].Timee = int.Parse(TextBox2.Text);
                db.SaveChanges();
                FillCombo();
                litMess.Text = "<div class='OKPM'>عملیات با موفقیت انجام شد</div>";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (drpSelect.SelectedIndex != -1)
            {
                DataBaseContext db = new DataBaseContext();
                Int32 ID = Int32.Parse(drpSelect.SelectedValue);
                db.Priority.Where(c => c.ID == ID).Load();
                db.Priority.Local.Remove(db.Priority.Local[0]);
                db.SaveChanges();
                FillCombo();
                litMess.Text = "<div class='OKPM'>عملیات با موفقیت انجام شد</div>";
            }
        }
    }
}