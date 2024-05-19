using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Bug_Traking
{
    public partial class AdminProject1 : System.Web.UI.Page
    {
        private void FillCombo()
        {
            drpSelect.Items.Clear();
            DataBaseContext db = new DataBaseContext();
            db.Projects.Load();
            foreach (var obj in db.Projects.Local)
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
            Tabels.Projects pr = new Tabels.Projects();
            pr.Name = txtTickatAddTitle.Text;
            db.Projects.Add(pr);
            db.SaveChanges();
            txtTickatAddTitle.Text = "";
            FillCombo();
            litMess.Text = "<div class='OKPM'>عملیات با موفقیت انجام شد</div>";
        }

        protected void btnEdir_Click(object sender, EventArgs e)
        {
            if (drpSelect.SelectedIndex != -1)
            {
                DataBaseContext db = new DataBaseContext();
                Guid ID = Guid.Parse(drpSelect.SelectedValue);
                db.Projects.Where(c => c.ID == ID).Load();
                db.Projects.Local[0].Name = txtEdit.Text;
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
                Guid ID = Guid.Parse(drpSelect.SelectedValue);
                db.Projects.Where(c => c.ID == ID).Load();
                db.Projects.Local.Remove(db.Projects.Local[0]);
                db.SaveChanges();
                FillCombo();
                litMess.Text = "<div class='OKPM'>عملیات با موفقیت انجام شد</div>";
            }
        }

        protected void drpSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpSelect.SelectedIndex != -1)
            {
                DataBaseContext db = new DataBaseContext();
                Guid ID = Guid.Parse(drpSelect.SelectedValue);
                db.Projects.Where(c => c.ID == ID).Load();
                txtEdit.Text = db.Projects.Local[0].Name;
            }
            litMess.Text = "";
        }
    }
}