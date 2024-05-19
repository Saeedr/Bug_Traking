using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Web.Services;
using System.Collections;

namespace Bug_Traking
{
    public partial class SupportBugAdd : System.Web.UI.Page
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
        public static ArrayList ShabakeShahrestan(string RdoVal, string id)
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
            foreach (var obj in db2.Tikets.Local)
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
            if (Session["support"] != null)
            {
                if (!IsPostBack)
                {
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
                    string z1 = "<script> $(document).ready(function () {var a = [#inja#];});</script>";
                    DataBaseContext db = new DataBaseContext();
                    db.Profile.Load();
                    foreach (var z in db.Profile.Local)
                    {
                        d += "'" + z.Family + "',";
                    }
                    if (d.Length > 0)
                        d = d.Substring(0, d.Length - 1);
                    s = s.Replace("#inja#", d);
                    z1 = z1.Replace("#inja#", d);
                    Literal1.Text = z1;
                    lit1.Text = s;
                    db.Shedat.Load();
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
    	    $(document).ready(function () {
    	        $('#ConfirmDialog').fadeOut(0);
    	        $('#btnGhabliDel').fadeOut(0);
    	    });
    	    if ($('#inputTagator').data('tagator') === undefined) {
    	        $('#inputTagator').tagator({
    	            autocomplete: [#inja#]
    	        });
    	    } else {
    	        $('#inputTagator').tagator('destroy');
    	    }
        </script>";
                    Tabels.Support sp = Session["support"] as Tabels.Support;
                    db.KeyWords.Where(c => c.WhatUser == "support" && c.UserID == sp.ID).Load();
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
                        Literal2.Text = keyTex.Replace("#inja#", s5);
                    }
                    else
                    {
                        Literal2.Text = keyTex.Replace("#inja#", "");
                    }
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
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

        protected void btnSearch1_Click(object sender, EventArgs e)
        {
        }

        protected void btnTicketSend_Click(object sender, EventArgs e)
        {
            Tabels.Support sp = Session["support"] as Tabels.Support;
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
                    if (((uploadedFile.ContentLength / 1024) / 1024) < 6)
                    {
                        string FileName = System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString() + FI.Extension;
                        uploadedFile.SaveAs(Server.MapPath(".") + @"/Upload/" + FileName);
                        oTikets.FileName += FileName + ",";
                        Response.Write(((uploadedFile.ContentLength / 1024) / 1024) + " < " + 10 + "<br />");
                    }
                }
            }
            db.KeyWords.Where(c => c.WhatUser == "support" && c.UserID == sp.ID).Load();
            if (db.KeyWords.Local.Count > 0)
            {
                db.KeyWords.Local[0].Keys += "," + Request.Form["inputTagator"];
            }
            else
            {
                Tabels.KeyWords tb = new Tabels.KeyWords();
                tb.UserID = sp.ID;
                tb.WhatUser = "support";
                tb.Keys = Request.Form["inputTagator"];
                db.KeyWords.Add(tb);
            }
            oTikets.Priority = drpTickatAddPriority.SelectedItem.Value;
            oTikets.Title = txtTickatAddTitle.Text;
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
            try { s = Request.Form[drpMarkazBehdaaht.UniqueID].Split('§'); oTikets.MarkazeBehdasht = s[1]; }
            catch { }
            try { s = Request.Form[drpShabakeShahrestan.UniqueID].Split('§'); oTikets.ShahrestanName = s[1]; }
            catch { }
            try { oTikets.Shedat = drpShedat.SelectedItem.Text; }
            catch { }
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
            Tabels.TicketSupport ts = new Tabels.TicketSupport();
            ts.Status = "جدید";
            ts.SupportID = sp.ID;
            ts.TikID = oTikets.ID;
            db.TikSupport.Add(ts);
            db.SaveChanges();
            lblTickatAddStatus.ForeColor = System.Drawing.Color.LightGreen;
            lblTickatAddStatus.Text = "عملیات با موفقیت انجام شد";
            Response.Redirect("SupportSearch.aspx");
        }

        protected void drpUniName_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpShabakeShahrestan.Items.Clear();
            if (drpUniName.SelectedIndex != -1)
            {
                if (RadioButtonList1.SelectedItem.Value == "2")
                {
                    List<LiveClassifi.ReqOrganization> lis = new List<LiveClassifi.ReqOrganization>();
                    LiveClassifi.LiveClassificationClient client = new LiveClassifi.LiveClassificationClient();
                    try
                    {
                        lis.AddRange(client.GetBehdashtClassificationByParam(1000, (3).ToString(), (drpUniName.SelectedItem.Value).ToString()));
                        drpShabakeShahrestan.Items.Add("گزینه ای را انتخاب کنید");
                    }
                    catch (Exception ex)
                    {
                        LiveClassifi.ReqOrganization empLi = new LiveClassifi.ReqOrganization();
                        empLi.OrganizationID8Digit = 0;
                        empLi.LongName = "باگذاری ناموفق";
                        lis.Add(empLi);
                        RadioButtonList1.Items.FindByValue("1").Selected = true;
                    }
                    foreach (LiveClassifi.ReqOrganization obj in lis)
                    {
                        ListItem li = new ListItem();
                        li.Text = obj.LongName;
                        li.Value = obj.OrganizationID8Digit.ToString();
                        drpShabakeShahrestan.Items.Add(li);
                    }
                }
                else
                {
                    SqlConnection Cn = new SqlConnection();
                    Cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseContext"].ToString();
                    SqlCommand Cm = new SqlCommand();
                    Cm.Connection = Cn;
                    Cm.CommandText = "select distinct ShabakeOrganizationID8Digit,ShabakeLongName from [dbo].[HealthNetwork] where UniversityOrganizationID8Digit ='" + drpUniName.SelectedItem.Value.ToString() + "'";
                    SqlDataReader Rd;
                    drpShabakeShahrestan.Items.Add("گزینه ای را انتخاب کنید");
                    Cn.Open();
                    Rd = Cm.ExecuteReader();
                    while (Rd.Read())
                    {
                        ListItem li = new ListItem();
                        li.Text = Rd[1].ToString();
                        li.Value = Rd[0].ToString();
                        drpShabakeShahrestan.Items.Add(li);
                    }
                    Cn.Close();
                }
            }
        }

        protected void drpShabakeShahrestan_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpMarkazBehdaaht.Items.Clear();
            if (drpShabakeShahrestan.SelectedIndex != -1)
            {
                if (RadioButtonList1.SelectedItem.Value == "2")
                {
                    List<LiveClassifi.ReqOrganization> lis = new List<LiveClassifi.ReqOrganization>();
                    LiveClassifi.LiveClassificationClient client = new LiveClassifi.LiveClassificationClient();
                    try
                    {
                        lis.AddRange(client.GetBehdashtClassificationByParam(1000, (26).ToString(), (drpShabakeShahrestan.SelectedItem.Value).ToString()));
                        drpMarkazBehdaaht.Items.Add("گزینه ای را انتخاب کنید");
                    }
                    catch (Exception ex)
                    {
                        LiveClassifi.ReqOrganization empLi = new LiveClassifi.ReqOrganization();
                        empLi.OrganizationID8Digit = 0;
                        empLi.LongName = "باگذاری ناموفق";
                        lis.Add(empLi);
                        RadioButtonList1.Items.FindByValue("1").Selected = true;
                    }
                    foreach (LiveClassifi.ReqOrganization obj in lis)
                    {
                        ListItem li = new ListItem();
                        li.Text = obj.LongName;
                        li.Value = obj.OrganizationID8Digit.ToString();
                        drpMarkazBehdaaht.Items.Add(li);
                    }
                }
                else
                {
                    SqlConnection Cn = new SqlConnection();
                    Cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseContext"].ToString();
                    SqlCommand Cm = new SqlCommand();
                    Cm.Connection = Cn;
                    Cm.CommandText = "select distinct MarkazOrganizationID8Digit,MarkazLongName from [dbo].[HealthNetwork] where ShabakeOrganizationID8Digit ='" + drpShabakeShahrestan.SelectedItem.Value.ToString() + "'";
                    SqlDataReader Rd;
                    drpMarkazBehdaaht.Items.Add("گزینه ای را انتخاب کنید");
                    Cn.Open();
                    Rd = Cm.ExecuteReader();
                    while (Rd.Read())
                    {
                        ListItem li = new ListItem();
                        li.Text = Rd[1].ToString();
                        li.Value = Rd[0].ToString();
                        drpMarkazBehdaaht.Items.Add(li);
                    }
                    Cn.Close();
                }
            }
        }

        protected void drpMarkazBehdaaht_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpKhaneBehdasht.Items.Clear();
            if (drpMarkazBehdaaht.SelectedIndex != -1)
            {
                if (RadioButtonList1.SelectedItem.Value == "2")
                {
                    List<LiveClassifi.ReqOrganization> lis = new List<LiveClassifi.ReqOrganization>();
                    LiveClassifi.LiveClassificationClient client = new LiveClassifi.LiveClassificationClient();
                    try
                    {
                        lis.AddRange(client.GetBehdashtClassificationByParam(1000, (15).ToString(), (drpMarkazBehdaaht.SelectedItem.Value).ToString()));
                        drpKhaneBehdasht.Items.Add("گزینه ای را انتخاب کنید");
                    }
                    catch (Exception ex)
                    {
                        LiveClassifi.ReqOrganization empLi = new LiveClassifi.ReqOrganization();
                        empLi.OrganizationID8Digit = 0;
                        empLi.LongName = "باگذاری ناموفق";
                        lis.Add(empLi);
                        RadioButtonList1.Items.FindByValue("1").Selected = true;
                    }
                    foreach (LiveClassifi.ReqOrganization obj in lis)
                    {
                        ListItem li = new ListItem();
                        li.Text = obj.LongName;
                        li.Value = obj.OrganizationID8Digit.ToString();
                        drpKhaneBehdasht.Items.Add(li);
                    }
                }
                else
                {
                    SqlConnection Cn = new SqlConnection();
                    Cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseContext"].ToString();
                    SqlCommand Cm = new SqlCommand();
                    Cm.Connection = Cn;
                    Cm.CommandText = "select distinct OrganizationID8Digit,LongName from [dbo].[HealthNetwork] where MarkazOrganizationID8Digit ='" + drpMarkazBehdaaht.SelectedItem.Value.ToString() + "'";
                    SqlDataReader Rd;
                    drpKhaneBehdasht.Items.Add("گزینه ای را انتخاب کنید");
                    Cn.Open();
                    Rd = Cm.ExecuteReader();
                    while (Rd.Read())
                    {
                        ListItem li = new ListItem();
                        li.Text = Rd[1].ToString();
                        li.Value = Rd[0].ToString();
                        drpKhaneBehdasht.Items.Add(li);
                    }
                    Cn.Close();
                }
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