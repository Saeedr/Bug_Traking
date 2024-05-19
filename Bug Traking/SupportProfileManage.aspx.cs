using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Web.Services;
using System.Collections;
using System.Data.SqlClient;

namespace Bug_Traking
{
    public partial class SupportProfileManage : System.Web.UI.Page
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
        public static ArrayList FillOstan()
        {
            ArrayList li = new ArrayList();
            SqlConnection Cn = new SqlConnection();
            Cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseContext"].ToString();
            SqlCommand Cm = new SqlCommand();
            Cm.Connection = Cn;
            Cm.CommandText = "select  * from CountryDivision where AreaTypeCode = '1'";
            SqlDataReader Rd;
            Cn.Open();
            Rd = Cm.ExecuteReader();
            while (Rd.Read())
            {
                ListItem li2 = new ListItem();
                li2.Text = Rd[2].ToString();
                li2.Value = Rd[1].ToString() + "§" + Rd[2].ToString();
                li.Add(li2);
            }
            Cn.Close();
            return li;
        }

        [WebMethod]
        public static ArrayList FillTghsimat(string AreaTypeCode, string ParentAreaCode)
        {
            ArrayList li = new ArrayList();
            SqlConnection Cn = new SqlConnection();
            Cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseContext"].ToString();
            SqlCommand Cm = new SqlCommand();
            Cm.Connection = Cn;
            Cm.CommandText = "select * from CountryDivision where AreaTypeCode = '" + AreaTypeCode + "' AND ParentAreaCode = '" + ParentAreaCode + "'";
            SqlDataReader Rd;
            Cn.Open();
            Rd = Cm.ExecuteReader();
            if (Rd.HasRows)
                li.Add("");
            while (Rd.Read())
            {
                ListItem li2 = new ListItem();
                li2.Text = Rd[2].ToString();
                li2.Value = Rd[1].ToString() + "§" + Rd[2].ToString();
                li.Add(li2);
            }
            Cn.Close();
            return li;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["support"] != null)
            {
                if (!IsPostBack)
                {
                    DataBaseContext db = new DataBaseContext();
                    db.Position.Load();
                    foreach (var obj in db.Position.Local)
                    {
                        ListItem Li = new ListItem();
                        Li.Text = obj.name;
                        Li.Value = obj.ID.ToString();
                        DropDownList7.Items.Add(Li);
                    }
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnTicketSend_Click(object sender, EventArgs e)
        {
            int id=77777777;
            DataBaseContext db = new DataBaseContext();
            try
            {
                id=int.Parse(txt8Code.Text);
            }
            catch { }
            db.Profile.Where(c => c.ID == id).Load();
            Response.Write(db.Profile.Local.Count);
            if (db.Profile.Local.Count == 0)
            {
                Tabels.Profile pf = new Tabels.Profile();
                pf.Name = txtName.Text;
                pf.Family = txtFamily.Text;
                pf.Tell1 = txtTell1.Text;
                pf.Tell2 = txtTell2.Text;
                string[] s = new string[2];
                try { pf.Code8Raghami = Request.Form[txt8Code.UniqueID]; }
                catch { }
                try { s = Request.Form[drpUniName.UniqueID].Split('§'); pf.UniName = s[1]; }
                catch { }
                try { s = Request.Form[drpKhaneBehdasht.UniqueID].Split('§'); pf.KhaneBehdast = s[1]; }
                catch { }
                try { s = Request.Form[drpMarkazBehdaaht.UniqueID].Split('§'); pf.MarkazeBehdasht = s[1]; }
                catch { }
                try { s = Request.Form[drpShabakeShahrestan.UniqueID].Split('§'); pf.ShahrestanName = s[1]; }
                catch { }
                try { s = Request.Form[DropDownList1.UniqueID].Split('§'); pf.Ostan = s[1]; }
                catch { }
                try { s = Request.Form[DropDownList2.UniqueID].Split('§'); pf.Shahrestan = s[1]; }
                catch { }
                try { s = Request.Form[DropDownList3.UniqueID].Split('§'); pf.Bakhsh = s[1]; }
                catch { }
                try { s = Request.Form[DropDownList4.UniqueID].Split('§'); pf.Shahr = s[1]; }
                catch { }
                try { s = Request.Form[DropDownList5.UniqueID].Split('§'); pf.Dehestan = s[1]; }
                catch { }
                try { s = Request.Form[DropDownList6.UniqueID].Split('§'); pf.Rosta = s[1]; }
                catch { }
                pf.Sex = drpSex.SelectedItem.Text;
                try
                {
                    pf.Position = DropDownList7.SelectedItem.Text;
                }
                catch { }
                pf.Email = txtEmail.Text;
                db.Profile.Add(pf);
                db.SaveChanges();
                txtTell2.Text = txtTell1.Text = txtName.Text = txtFamily.Text = txt8Code.Text = txtEmail.Text = string.Empty;
                litMess.Text = "<div class='OKPM'>عملیات با موفقیت انجام شد</div>";
            }
            else
            {
                txt8Code.Text = "";
                litMess.Text = "<div class='OKPM' style='color:#a10f0f;background:#f39393;box-shadow:0px 0px 10px #f39393;'>این شخص قبلا ثبت شده</div>";
            }
        }
    }
}