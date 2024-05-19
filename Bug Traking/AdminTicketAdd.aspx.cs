using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Text;
using System.Web.Services;
using System.IO;
using System.Data.SqlClient;

namespace Bug_Traking
{
    public partial class AdminTicketAdd : System.Web.UI.Page
    {
        [WebMethod]
        public static ArrayList FillProJect(string RdoVal)
        {
            ArrayList li = new ArrayList();
            if (RdoVal == "2")
            {
                List<LiveClassifi.ReqOrganization> lis = new List<LiveClassifi.ReqOrganization>();
                LiveClassifi.LiveClassificationClient client = new LiveClassifi.LiveClassificationClient();
                try
                {
                    lis.AddRange(client.GetBehdashtClassificationByParam(1000, (2).ToString(), (14554455).ToString()));
                    lis.AddRange(client.GetBehdashtClassificationByParam(1000, (28).ToString(), (14554455).ToString()));
                    li.Add(new ListItem { Text = "", Value = "" });
                }
                catch
                {
                    LiveClassifi.ReqOrganization empLi = new LiveClassifi.ReqOrganization();
                    empLi.OrganizationID8Digit = 0;
                    empLi.LongName = "باگذاری ناموفق";
                    lis.Add(empLi);
                }
                foreach (LiveClassifi.ReqOrganization obj in lis)
                {
                    ListItem li2 = new ListItem();
                    li2.Text = obj.LongName;
                    li2.Value = obj.OrganizationID8Digit.ToString() + "§" + obj.LongName;
                    li.Add(li2);
                }
            }
            else
            {
                SqlConnection Cn = new SqlConnection();
                Cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseContext"].ToString();
                SqlCommand Cm = new SqlCommand();
                Cm.Connection = Cn;
                Cm.CommandText = "select distinct UniversityOrganizationID8Digit,UniversityLongName from [dbo].[HealthNetwork]";
                SqlDataReader Rd;
                Cn.Open();
                Rd = Cm.ExecuteReader();
                li.Add(new ListItem { Text = "", Value = "" });
                while (Rd.Read())
                {
                    ListItem li2 = new ListItem();
                    li2.Text = Rd[1].ToString();
                    li2.Value = Rd[0].ToString() + "§" + Rd[1].ToString();
                    li.Add(li2);
                }
                Cn.Close();
            }
            return li;
        }

        [WebMethod]
        public static ArrayList ShabakeShahrestan(string RdoVal,string id)
        {
            ArrayList li = new ArrayList();

            if (RdoVal == "2")
            {
                List<LiveClassifi.ReqOrganization> lis = new List<LiveClassifi.ReqOrganization>();
                LiveClassifi.LiveClassificationClient client = new LiveClassifi.LiveClassificationClient();
                try
                {
                    lis.AddRange(client.GetBehdashtClassificationByParam(1000, (3).ToString(), (id).ToString()));
                    li.Add(new ListItem { Text = "", Value = "" });
                }
                catch (Exception ex)
                {
                    LiveClassifi.ReqOrganization empLi = new LiveClassifi.ReqOrganization();
                    empLi.OrganizationID8Digit = 0;
                    empLi.LongName = "باگذاری ناموفق";
                    lis.Add(empLi);
                }
                foreach (LiveClassifi.ReqOrganization obj in lis)
                {
                    ListItem li2 = new ListItem();
                    li2.Text = obj.LongName;
                    li2.Value = obj.OrganizationID8Digit.ToString() + "§" + obj.LongName;
                    li.Add(li2);
                }
            }
            else
            {
                SqlConnection Cn = new SqlConnection();
                Cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseContext"].ToString();
                SqlCommand Cm = new SqlCommand();
                Cm.Connection = Cn;
                Cm.CommandText = "select distinct ShabakeOrganizationID8Digit,ShabakeLongName from [dbo].[HealthNetwork] where UniversityOrganizationID8Digit ='" + id + "'";
                SqlDataReader Rd;
                li.Add(new ListItem { Text = "", Value = "" });
                Cn.Open();
                Rd = Cm.ExecuteReader();
                while (Rd.Read())
                {
                    ListItem li2 = new ListItem();
                    li2.Text = Rd[1].ToString();
                    li2.Value = Rd[0].ToString() + "§" + Rd[1].ToString();
                    li.Add(li2);
                }
                Cn.Close();
            }
            return li;
        }

        [WebMethod]
        public static ArrayList MarkazBehdaaht(string RdoVal, string id)
        {
            ArrayList li = new ArrayList();

            if (RdoVal == "2")
            {
                List<LiveClassifi.ReqOrganization> lis = new List<LiveClassifi.ReqOrganization>();
                LiveClassifi.LiveClassificationClient client = new LiveClassifi.LiveClassificationClient();
                try
                {
                    lis.AddRange(client.GetBehdashtClassificationByParam(1000, (26).ToString(), (id).ToString()));
                    li.Add("");
                }
                catch (Exception ex)
                {
                    LiveClassifi.ReqOrganization empLi = new LiveClassifi.ReqOrganization();
                    empLi.OrganizationID8Digit = 0;
                    empLi.LongName = "باگذاری ناموفق";
                    lis.Add(empLi);
                }
                foreach (LiveClassifi.ReqOrganization obj in lis)
                {
                    ListItem li2 = new ListItem();
                    li2.Text = obj.LongName;
                    li2.Value = obj.OrganizationID8Digit.ToString() + "§" + obj.LongName;
                    li.Add(li2);
                }
            }
            else
            {
                SqlConnection Cn = new SqlConnection();
                Cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseContext"].ToString();
                SqlCommand Cm = new SqlCommand();
                Cm.Connection = Cn;
                Cm.CommandText = "select distinct MarkazOrganizationID8Digit,MarkazLongName from [dbo].[HealthNetwork] where ShabakeOrganizationID8Digit ='" + id + "'";
                SqlDataReader Rd;
                li.Add("");
                Cn.Open();
                Rd = Cm.ExecuteReader();
                while (Rd.Read())
                {
                    ListItem li2 = new ListItem();
                    li2.Text = Rd[1].ToString();
                    li2.Value = Rd[0].ToString() + "§" + Rd[1].ToString();
                    li.Add(li2);
                }
                Cn.Close();
            }
            return li;
        }

        [WebMethod]
        public static ArrayList KhaneBehdasht(string RdoVal, string id)
        {
            ArrayList li = new ArrayList();
            if (RdoVal == "2")
            {
                List<LiveClassifi.ReqOrganization> lis = new List<LiveClassifi.ReqOrganization>();
                LiveClassifi.LiveClassificationClient client = new LiveClassifi.LiveClassificationClient();
                try
                {
                    lis.AddRange(client.GetBehdashtClassificationByParam(1000, (15).ToString(), (id).ToString()));
                    li.Add("گزینه ای را انتخاب کنید");
                }
                catch (Exception ex)
                {
                    LiveClassifi.ReqOrganization empLi = new LiveClassifi.ReqOrganization();
                    empLi.OrganizationID8Digit = 0;
                    empLi.LongName = "باگذاری ناموفق";
                    lis.Add(empLi);
                }
                foreach (LiveClassifi.ReqOrganization obj in lis)
                {
                    ListItem li2 = new ListItem();
                    li2.Text = obj.LongName;
                    li2.Value = obj.OrganizationID8Digit.ToString() + "§" + obj.LongName;
                    li.Add(li2);
                }
            }
            else
            {
                SqlConnection Cn = new SqlConnection();
                Cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseContext"].ToString();
                SqlCommand Cm = new SqlCommand();
                Cm.Connection = Cn;
                Cm.CommandText = "select distinct OrganizationID8Digit,LongName from [dbo].[HealthNetwork] where MarkazOrganizationID8Digit ='" + id + "'";
                SqlDataReader Rd;
                li.Add("گزینه ای را انتخاب کنید");
                Cn.Open();
                Rd = Cm.ExecuteReader();
                while (Rd.Read())
                {
                    ListItem li2 = new ListItem();
                    li2.Text = Rd[1].ToString();
                    li2.Value = Rd[0].ToString() + "§" + Rd[1].ToString();
                    li.Add(li2);
                }
                Cn.Close();
            }
            return li;
        }

        [WebMethod]
        public static ArrayList ZirSystem(string id)
        {
            ArrayList li = new ArrayList();
            DataBaseContext db = new DataBaseContext();
            Guid ID = Guid.Parse(id);
            db.Ssystem.Where(c => c.ProjectID == ID).Load();
            foreach (var obj in db.Ssystem.Local)
            {
                ListItem li2 = new ListItem();
                li2.Value = obj.ID.ToString() + "§" + obj.Name;
                li2.Text = obj.Name;
                li.Add(li2);
            }
            return li;
        }

        [WebMethod]
        public static ArrayList Service(string id)
        {
            ArrayList li = new ArrayList();
            DataBaseContext db = new DataBaseContext();
            Guid ID = Guid.Parse(id);
            db.Service.Where(c => c.SsystemID == ID).Load();
            foreach (var obj in db.Service.Local)
            {
                ListItem li2 = new ListItem();
                li2.Value = obj.ID.ToString() + "§" + obj.Name;
                li2.Text = obj.Name;
                li.Add(li2);
            }
            return li;
        }

        [WebMethod]
        public static ArrayList Part(string id)
        {
            ArrayList li = new ArrayList();
            DataBaseContext db = new DataBaseContext();
            Guid ID = Guid.Parse(id);
            db.Parts.Where(c => c.ServiceID == ID).Load();
            foreach (var obj in db.Parts.Local)
            {
                ListItem li2 = new ListItem();
                li2.Value = obj.ID.ToString() + "§" + obj.Name;
                li2.Text = obj.Name;
                li.Add(li2);
            }
            return li;
        }

        [WebMethod]
        public static ArrayList Category(string id)
        {
            ArrayList li = new ArrayList();
            DataBaseContext db = new DataBaseContext();
            Guid ID = Guid.Parse(id);
            db.Category.Where(c => c.PartsID == ID).Load();
            foreach (var obj in db.Category.Local)
            {
                ListItem li2 = new ListItem();
                li2.Value = obj.ID.ToString() + "§" + obj.Name;
                li2.Text = obj.Name;
                li.Add(li2);
            }
            return li;
        }

        [WebMethod]
        public static ArrayList FillGhabli(string date, string code)
        {
            ArrayList li = new ArrayList();
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            DataBaseContext db2 = new DataBaseContext();
            db2.Tikets.Where(c => c.Title.Contains(code)).Load();
            foreach(var obj in db2.Tikets.Local)
            {
                string s = pc.GetYear(obj.SendData) + "/" + pc.GetMonth(obj.SendData) + "/" + pc.GetDayOfMonth(obj.SendData);
                if (date == s || date.Length < 2)
                {
                    ListItem li2 = new ListItem();
                    li2.Value = obj.ID.ToString();
                    li2.Text = obj.IDName;
                    li.Add(li2);
                }
            }
            return li;
        }

        [WebMethod]
        public static string WhatPersion(string name)
        {
            string s = "";
            DataBaseContext db2 = new DataBaseContext();
            db2.Profile.Where(c => c.Family == name).Load();
            if (db2.Profile.Local.Count > 0)
            {
                s += "0§" + db2.Profile.Local[0].UniName;
                s += "!0§" + db2.Profile.Local[0].ShahrestanName;
                s += "!0§" + db2.Profile.Local[0].MarkazeBehdasht;
                s += "!0§" + db2.Profile.Local[0].KhaneBehdast;
                s += "!" + db2.Profile.Local[0].Code8Raghami;
                return s;
            }
            return "null";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBaseContext db = new DataBaseContext();
                db.Support.Load();
                foreach (var obj in db.Support.Local)
                {
                    ListItem chk = new ListItem();
                    chk.Text = obj.Name + " " + obj.Family;
                    chk.Value = obj.ID.ToString();
                    CheckBoxList1.Items.Add(chk);
                    drpErja.Items.Add(chk);
                }
                db.Shedat.Load();
                string s = @"<script> $(document).ready(function () { $('#txtUserName').autoComplete({
            minChars: 1,
            source: function (term, suggest) {
                term = term.toLowerCase();
                var choices = [#inja#];
                var suggestions = [];
                for (i = 0; i < choices.length; i++)
                    if (~choices[i].toLowerCase().indexOf(term)) suggestions.push(choices[i]);
                suggest(suggestions);
            }
        });});</script>";
                string d = "";
                db.Profile.Load();
                foreach (var z in db.Profile.Local)
                {
                    d += "'" + z.Family + "',";
                }
                if (d.Length > 0)
                    d = d.Substring(0, d.Length - 1);
                s = s.Replace("#inja#", d);
                lit1.Text = s;
                foreach (var obj in db.Shedat.Local)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.ID.ToString();
                    li.Text = obj.name;
                    drpShedat.Items.Add(li);
                }
                db.Projects.Load();
                foreach (var obj in db.Projects.Local)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.ID.ToString() + "§" + obj.Name;
                    li.Text = obj.Name;
                    drpTickatAddProject.Items.Add(li);
                }
                drpTickatAddProject_SelectedIndexChanged(null, null);
                db.Priority.Load();
                foreach (var obj in db.Priority.Local)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.ID.ToString();
                    li.Text = obj.Name;
                    drpTickatAddPriority.Items.Add(li);
                }
                string keyTex = @"<script>
    	    if ($('#inputTagator').data('tagator') === undefined) {
    	        $('#inputTagator').tagator({
    	            autocomplete: [#inja#]
    	        });
    	    } else {
    	        $('#inputTagator').tagator('destroy');
    	    }
	</script>";
                db.KeyWords.Where(c => c.WhatUser == "admin" && c.UserID == 0).Load();
                if (db.KeyWords.Local.Count > 0)
                {
                    string[] keys = db.KeyWords.Local[0].Keys.Split(',');
                    string s5 = "";
                    keys = keys.Distinct().ToArray();
                    foreach (string s6 in keys)
                    {
                        s5 += "'" + s6 + "',";
                    }
                    s5 = s5.Substring(0, s5.Length - 1);
                    Literal1.Text = keyTex.Replace("#inja#", s5);
                }
                else
                {
                    Literal1.Text = keyTex.Replace("#inja#", "");
                }
            }
        }

        protected void drpTickatAddProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpTickatAddSsystem.Items.Clear();
            if (drpTickatAddProject.SelectedIndex != -1)
            {
                DataBaseContext db = new DataBaseContext();
                string[] s = drpTickatAddProject.SelectedValue.Split('§');
                Guid ID = Guid.Parse(s[0]);
                db.Ssystem.Where(c => c.ProjectID == ID).Load();
                foreach (var obj in db.Ssystem.Local)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.ID.ToString() + "§" + obj.Name;
                    li.Text = obj.Name;
                    drpTickatAddSsystem.Items.Add(li);
                }
            }
            drpTickatAddSsystem_SelectedIndexChanged(null, null);
        }

        protected void drpTickatAddSsystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpTickatAddService.Items.Clear();
            if (drpTickatAddSsystem.SelectedIndex != -1)
            {
                DataBaseContext db = new DataBaseContext();
                string[] s = drpTickatAddSsystem.SelectedValue.Split('§');
                Guid ID = Guid.Parse(s[0]);
                db.Service.Where(c => c.SsystemID == ID).Load();
                foreach (var obj in db.Service.Local)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.ID.ToString() + "§" + obj.Name;
                    li.Text = obj.Name;
                    drpTickatAddService.Items.Add(li);
                }
            }
            drpTickatAddService_SelectedIndexChanged(null, null);
        }

        protected void drpTickatAddService_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpTickatAddPart.Items.Clear();
            if (drpTickatAddService.SelectedIndex != -1)
            {
                DataBaseContext db = new DataBaseContext();
                string[] s = drpTickatAddService.SelectedValue.Split('§');
                Guid ID = Guid.Parse(s[0]);
                db.Parts.Where(c => c.ServiceID == ID).Load();
                foreach (var obj in db.Parts.Local)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.ID.ToString() + "§" + obj.Name;
                    li.Text = obj.Name;
                    drpTickatAddPart.Items.Add(li);
                }
            }
            drpTickatAddPart_SelectedIndexChanged(null, null);
        }

        protected void drpTickatAddPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpTickatAddCategory.Items.Clear();
            if (drpTickatAddPart.SelectedIndex != -1)
            {
                DataBaseContext db = new DataBaseContext();
                string[] s = drpTickatAddPart.SelectedValue.Split('§');
                Guid ID = Guid.Parse(s[0]);
                db.Category.Where(c => c.PartsID == ID).Load();
                foreach (var obj in db.Category.Local)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.ID.ToString() + "§" + obj.Name;
                    li.Text = obj.Name;
                    drpTickatAddCategory.Items.Add(li);
                }
            }
        }

        protected void btnTicketSend_Click(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();
            Tabels.Tikets oTikets = new Tabels.Tikets();
            oTikets.SendData = DateTime.Now;
            string sss = txtTickatAddDet.Text;
            byte[] a = { 10 };
            char[] b = Encoding.UTF8.GetChars(a);
            sss = sss.Replace((b[0]).ToString(), "#br#");
            oTikets.Description = sss;
            if (TicketUpload.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in TicketUpload.PostedFiles)
                {
                    FileInfo FI = new FileInfo(uploadedFile.FileName);
                    if (((uploadedFile.ContentLength / 1024) / 1024) < 10)
                    {
                        string FileName = System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString() + FI.Extension;
                        uploadedFile.SaveAs(Server.MapPath(".") + @"/Upload/" + FileName);
                        oTikets.FileName += FileName + ",";
                        Response.Write(((uploadedFile.ContentLength / 1024) / 1024) + " < " + 10 + "<br />");
                    }
                }
            }
            db.KeyWords.Where(c => c.WhatUser == "admin" && c.UserID == 0).Load();
            if (db.KeyWords.Local.Count > 0)
            {
                db.KeyWords.Local[0].Keys += "," + Request.Form["inputTagator"];
            }
            else
            {
                Tabels.KeyWords tb = new Tabels.KeyWords();
                tb.UserID = 0;
                tb.WhatUser = "admin";
                tb.Keys = Request.Form["inputTagator"];
                db.KeyWords.Add(tb);
            }
            oTikets.Priority = drpTickatAddPriority.SelectedItem.Value;
            string[] s;
            try
            {
                s = Request.Form[drpTickatAddPart.UniqueID].Split('§');
                oTikets.Part = s[1];
            }
            catch { }
            try
            {
                s = Request.Form[drpTickatAddProject.UniqueID].Split('§');
                oTikets.ProjectName = s[1];
            }
            catch { }
            try
            {
            s = Request.Form[drpTickatAddService.UniqueID].Split('§');
            oTikets.Service = s[1];
            }
            catch { }
            try
            {
                s = Request.Form[drpTickatAddSsystem.UniqueID].Split('§');
                oTikets.Ssystem = s[1];
            }
            catch { }
            try
            {
                s = Request.Form[drpTickatAddCategory.UniqueID].Split('§');
                oTikets.Category = s[1];
                oTikets.CatID = s[0];
            }
            catch { }
            try { oTikets.Code8Raghami = txt8Code.Text; }
            catch { }
            try { s = Request.Form[drpUniName.UniqueID].Split('§'); oTikets.UniName = s[1]; }
            catch { }
            try { s = Request.Form[drpKhaneBehdasht.UniqueID].Split('§'); oTikets.KhaneBehdast = s[1]; }
            catch { }
            try {s = Request.Form[drpMarkazBehdaaht.UniqueID].Split('§'); oTikets.MarkazeBehdasht = s[1]; }
            catch { }
            try { s = Request.Form[drpShabakeShahrestan.UniqueID].Split('§'); oTikets.ShahrestanName = s[1]; }
            catch { }
            try { oTikets.Shedat = drpShedat.SelectedItem.Text; }
            catch { }
            oTikets.Title = txtTickatAddTitle.Text;
            oTikets.UserName = Request.Form["txtUserName"];
            oTikets.UserID = 0;
            string Tags = Request.Form["inputTagator"];
            string[] s2 = Tags.Split(',');
            oTikets.KeyWords(s2);
            oTikets.Status = "جدید";
            if (HRabt.Value != "")
                oTikets.LastErrorID = int.Parse(HRabt.Value);
            db.Tikets.Add(oTikets);
            db.SaveChanges();
            foreach (ListItem li in CheckBoxList1.Items)
            {
                if (li.Selected == true)
                {
                    Tabels.TicketSupport ts = new Tabels.TicketSupport();
                    ts.Status = "جدید";
                    ts.SupportID = int.Parse(li.Value);
                    ts.TikID = oTikets.ID;
                    ts.PeigiriID = int.Parse(drpErja.SelectedItem.Value);
                    db.TikSupport.Add(ts);
                }
            }
            db.SaveChanges();
            lblTickatAddStatus.ForeColor = System.Drawing.Color.LightGreen;
            lblTickatAddStatus.Text = "عملیات با موفقیت انجام شد";
            Response.Redirect("AdminKartable.aspx");
        }

        protected void drpUniName_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        protected void drpShabakeShahrestan_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void drpMarkazBehdaaht_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpKhaneBehdasht.Items.Clear();
            if (drpMarkazBehdaaht.SelectedIndex != -1)
            {
                
            }
        }

        protected void drpKhaneBehdasht_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpKhaneBehdasht.SelectedIndex != -1)
            {
                txt8Code.Text = drpKhaneBehdasht.SelectedItem.Value;
            }
        }
    }
}