using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Bug_Traking
{
    public partial class AdminSystem : System.Web.UI.Page
    {
        private void FillCombo()
        {
            drpSelect.Items.Clear();
            DropDownList1.Items.Clear();
            DropDownList2.Items.Clear();
            DataBaseContext db = new DataBaseContext();
            db.Projects.Load();
            db.Ssystem.Load();
            foreach (var obj in db.Projects.Local)
            {
                ListItem li = new ListItem();
                li.Value = obj.ID.ToString();
                li.Text = obj.Name;
                DropDownList1.Items.Add(li);
                DropDownList2.Items.Add(li);
            }
            foreach (var obj in db.Ssystem.Local)
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
            if(!IsPostBack)
            {
                FillCombo();
            }
        }

        protected void drpSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpSelect.SelectedIndex != -1)
            {
                try
                {
                    DataBaseContext db = new DataBaseContext();
                    Guid ID = Guid.Parse(drpSelect.SelectedValue);
                    db.Ssystem.Where(c => c.ID == ID).Load();
                    txtEdit.Text = db.Ssystem.Local[0].Name;
                    DropDownList2.SelectedValue = db.Ssystem.Local[0].ProjectID.ToString();
                }
                catch { }
            }
            litMess.Text = "";
        }

        protected void btnEdir_Click(object sender, EventArgs e)
        {
            if (drpSelect.SelectedIndex != -1)
            {
                DataBaseContext db = new DataBaseContext();
                Guid ID = Guid.Parse(drpSelect.SelectedValue);
                db.Ssystem.Where(c => c.ID == ID).Load();
                Guid id = Guid.Parse(DropDownList2.SelectedValue);
                db.Ssystem.Local[0].Name = txtEdit.Text;
                db.Ssystem.Local[0].ProjectID = id;
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
                db.Ssystem.Where(c => c.ID == ID).Load();
                db.Ssystem.Local.Remove(db.Ssystem.Local[0]);
                db.SaveChanges();
                FillCombo();
                litMess.Text = "<div class='OKPM'>عملیات با موفقیت انجام شد</div>";
            }
        }

        protected void btnTicketSend_Click(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();
            Tabels.Ssystem pr = new Tabels.Ssystem();
            pr.Name = txtTickatAddTitle.Text;
            Guid id = Guid.Parse(DropDownList1.SelectedValue);
            pr.ProjectID = id;
            db.Ssystem.Add(pr);
            db.SaveChanges();
            txtTickatAddTitle.Text = "";
            FillCombo();
            litMess.Text = "<div class='OKPM'>عملیات با موفقیت انجام شد</div>";
        }
    }
}