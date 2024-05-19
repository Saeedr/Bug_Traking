using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Bug_Traking
{
    public partial class AdminTitle : System.Web.UI.Page
    {
        private void FillCombo()
        {
            drpSelect.Items.Clear();
            drpProject.Items.Clear();
            drpProjectEdit.Items.Clear();
            DataBaseContext db = new DataBaseContext();
            db.Projects.Load();
            db.Category.Load();
            foreach (var obj in db.Projects.Local)
            {
                ListItem li = new ListItem();
                li.Value = obj.ID.ToString();
                li.Text = obj.Name;
                drpProject.Items.Add(li);
                drpProjectEdit.Items.Add(li);
            }
            foreach (var obj in db.Category.Local)
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
            drpSsystem_SelectedIndexChanged(null, null);
            litMess.Text = "";
        }

        protected void drpSsystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpSsystem.SelectedIndex != -1)
            {
                Guid id = Guid.Parse(drpSsystem.SelectedValue);
                drpService.Items.Clear();
                DataBaseContext db = new DataBaseContext();
                db.Service.Where(c => c.SsystemID == id).Load();
                foreach (var obj in db.Service.Local)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.ID.ToString();
                    li.Text = obj.Name;
                    drpService.Items.Add(li);
                }
                drpService_SelectedIndexChanged(null, null);
            }
            litMess.Text = "";
        }

        protected void drpService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpService.SelectedIndex != -1)
            {
                Guid id = Guid.Parse(drpService.SelectedValue);
                drpPart.Items.Clear();
                DataBaseContext db = new DataBaseContext();
                db.Parts.Where(c => c.ServiceID == id).Load();
                foreach (var obj in db.Parts.Local)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.ID.ToString();
                    li.Text = obj.Name;
                    drpPart.Items.Add(li);
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
            drpSsystemEdit_SelectedIndexChanged(null, null);
            litMess.Text = "";
        }

        protected void drpSsystemEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpSsystemEdit.SelectedIndex != -1)
            {
                Guid id = Guid.Parse(drpSsystemEdit.SelectedValue);
                drpServiceEdit.Items.Clear();
                DataBaseContext db = new DataBaseContext();
                db.Service.Where(c => c.SsystemID == id).Load();
                foreach (var obj in db.Service.Local)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.ID.ToString();
                    li.Text = obj.Name;
                    drpServiceEdit.Items.Add(li);
                }
                drpServiceEdit_SelectedIndexChanged(null, null);
            }
            litMess.Text = "";
        }

        protected void drpServiceEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpServiceEdit.SelectedIndex != -1)
            {
                Guid id = Guid.Parse(drpServiceEdit.SelectedValue);
                drpPartEdit.Items.Clear();
                DataBaseContext db = new DataBaseContext();
                db.Parts.Where(c => c.ServiceID == id).Load();
                foreach (var obj in db.Parts.Local)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.ID.ToString();
                    li.Text = obj.Name;
                    drpPartEdit.Items.Add(li);
                }
            }
            litMess.Text = "";
        }

        protected void drpSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpSelect.SelectedIndex != -1)
            {
                DataBaseContext db = new DataBaseContext();
                Guid ID0 = Guid.Parse(drpSelect.SelectedValue);
                db.Category.Where(c => c.ID == ID0).Load();
                txtEdit.Text = db.Category.Local[0].Name;
                Guid ID9 = db.Category.Local[0].PartsID;
                try
                {
                    var s4 = (from p in db.Parts where p.ID == ID9 select p).Single();
                    Guid ID = s4.ServiceID;

                    var s3 = (from p in db.Service where p.ID == ID select p).Single();
                    Guid ID1 = s3.SsystemID;

                    var s = (from p in db.Ssystem where p.ID == ID1 select p).Single();
                    Guid ID2 = s.ProjectID;

                    var s2 = (from p in db.Projects where p.ID == ID2 select p).Single();

                    Literal1.Text = s2.Name + " > " + s.Name + " > " + s3.Name + " > " + s4.Name;
                }
                catch { }
            }
            litMess.Text = "";
        }

        protected void btnTicketSend_Click(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();
            Tabels.Category pr = new Tabels.Category();
            pr.Name = txtTickatAddTitle.Text;
            Guid id = Guid.Parse(drpPart.SelectedValue);
            pr.PartsID = id;
            db.Category.Add(pr);
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
                Guid ID2 = Guid.Parse(drpPartEdit.SelectedValue);
                db.Category.Where(c => c.ID == ID).Load();
                db.Category.Local[0].Name = txtEdit.Text;
                db.Category.Local[0].PartsID = ID2;
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
                db.Category.Where(c => c.ID == ID).Load();
                db.Category.Local.Remove(db.Category.Local[0]);
                db.SaveChanges();
                FillCombo();
                litMess.Text = "<div class='OKPM'>عملیات با موفقیت انجام شد</div>";
            }
        }

        protected void drpPartEdit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}