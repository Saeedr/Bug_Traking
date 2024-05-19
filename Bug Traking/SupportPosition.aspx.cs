using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Bug_Traking
{
    public partial class SupportPosition : System.Web.UI.Page
    {
        private void FillCombo()
        {
            drpSelect.Items.Clear();
            DataBaseContext db = new DataBaseContext();
            db.Position.Load();
            foreach (var obj in db.Position.Local)
            {
                ListItem li = new ListItem();
                li.Value = obj.ID.ToString();
                li.Text = obj.name;
                drpSelect.Items.Add(li);
            }
            drpSelect_SelectedIndexChanged(null, null);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["support"] != null)
            {
                if (!IsPostBack)
                {
                    FillCombo();
                }
            }
        }

        protected void btnTicketSend_Click(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();
            Tabels.Position pr = new Tabels.Position();
            pr.name = txtTickatAddTitle.Text;
            db.Position.Add(pr);
            db.SaveChanges();
            txtTickatAddTitle.Text = "";
            FillCombo();
            litMess.Text = "<div class='OKPM'>عملیات با موفقیت انجام شد</div>";
        }

        protected void drpSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpSelect.SelectedIndex != -1)
            {
                DataBaseContext db = new DataBaseContext();
                Int32 ID = Int32.Parse(drpSelect.SelectedValue);
                db.Position.Where(c => c.ID == ID).Load();
                txtEdit.Text = db.Position.Local[0].name;
            }
            litMess.Text = "";
        }

        protected void btnEdir_Click(object sender, EventArgs e)
        {
            if (drpSelect.SelectedIndex != -1)
            {
                DataBaseContext db = new DataBaseContext();
                Int32 ID = Int32.Parse(drpSelect.SelectedValue);
                db.Position.Where(c => c.ID == ID).Load();
                db.Position.Local[0].name = txtEdit.Text;
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
                db.Position.Where(c => c.ID == ID).Load();
                db.Position.Local.Remove(db.Position.Local[0]);
                db.SaveChanges();
                FillCombo();
                litMess.Text = "<div class='OKPM'>عملیات با موفقیت انجام شد</div>";
            }
        }
    }
}