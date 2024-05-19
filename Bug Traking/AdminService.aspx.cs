using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Bug_Traking
{
    public partial class AdminService : System.Web.UI.Page
    {
        private void FillCombo()
        {
            drpSelect.Items.Clear();
            drpProject.Items.Clear();
            drpProjectEdit.Items.Clear();
            DataBaseContext db = new DataBaseContext();
            db.Projects.Load();
            db.Service.Load();
            foreach (var obj in db.Projects.Local)
            {
                ListItem li = new ListItem();
                li.Value = obj.ID.ToString();
                li.Text = obj.Name;
                drpProject.Items.Add(li);
                drpProjectEdit.Items.Add(li);
            }
            foreach (var obj in db.Service.Local)
            {
                ListItem li = new ListItem();
                li.Value = obj.ID.ToString();
                li.Text = obj.Name;
                drpSelect.Items.Add(li);
            }
            drpProject_SelectedIndexChanged(null, null);
            drpProjectEdit_SelectedIndexChanged(null, null);
            drpSelect_SelectedIndexChanged(null, null);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                FillCombo();
            }
        }

        protected void drpProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpProject.SelectedIndex != -1)
            {
                Guid id = Guid.Parse(drpProject.SelectedValue);
                drpSsystem.Items.Clear();
                DataBaseContext db = new DataBaseContext();
                db.Ssystem.Where(c => c.ProjectID == id).Load();
                foreach (var obj in db.Ssystem.Local)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.ID.ToString();
                    li.Text = obj.Name;
                    drpSsystem.Items.Add(li);
                }
            }
            litMess.Text = "";
        }

        protected void drpProjectEdit_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (drpProjectEdit.SelectedIndex != -1)
            {
                Guid id = Guid.Parse(drpProjectEdit.SelectedValue);
                drpSsystemEdit.Items.Clear();
                DataBaseContext db = new DataBaseContext();
                db.Ssystem.Where(c => c.ProjectID == id).Load();
                foreach (var obj in db.Ssystem.Local)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.ID.ToString();
                    li.Text = obj.Name;
                    drpSsystemEdit.Items.Add(li);
                }
            }
            litMess.Text = "";
        }

        protected void drpSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpSelect.SelectedIndex != -1)
            {
                DataBaseContext db = new DataBaseContext();
                Guid ID = Guid.Parse(drpSelect.SelectedValue);
                try
                {
                    db.Service.Where(c => c.ID == ID).Load();
                    txtEdit.Text = db.Service.Local[0].Name;
                    Guid ID1 = db.Service.Local[0].SsystemID;

                    var s = (from p in db.Ssystem where p.ID == ID1 select p).Single();
                    Guid ID2 = s.ProjectID;

                    var s2 = (from p in db.Projects where p.ID == ID2 select p).Single();

                    Literal1.Text = s2.Name + " > " + s.Name;
                }catch{}
            }
            litMess.Text = "";
        }

        protected void btnTicketSend_Click(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();
            Tabels.Service pr = new Tabels.Service();
            pr.Name = txtTickatAddTitle.Text;
            Guid id = Guid.Parse(drpSsystem.SelectedValue);
            pr.SsystemID = id;
            db.Service.Add(pr);
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
                Guid ID2 = Guid.Parse(drpSsystemEdit.SelectedValue);
                db.Service.Where(c => c.ID == ID).Load();
                db.Service.Local[0].Name = txtEdit.Text;
                db.Service.Local[0].SsystemID = ID2;
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
                db.Service.Where(c => c.ID == ID).Load();
                db.Service.Local.Remove(db.Service.Local[0]);
                db.SaveChanges();
                FillCombo();
                litMess.Text = "<div class='OKPM'>عملیات با موفقیت انجام شد</div>";
            }
        }
    }
}