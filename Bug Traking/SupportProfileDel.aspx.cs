using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data.Entity;

namespace Bug_Traking
{
    public partial class SupportProfileDel : System.Web.UI.Page
    {
        private void FillCombo()
        {
            drpSelect.Items.Clear();
            DataBaseContext db = new DataBaseContext();
            db.Profile.Load();
            foreach (var obj in db.Profile.Local)
            {
                ListItem li = new ListItem();
                li.Value = obj.ID.ToString();
                li.Text = obj.Name + " " + obj.Family;
                drpSelect.Items.Add(li);
            }
            drpSelect_SelectedIndexChanged(null, null);
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
                li2.Value = Rd[1].ToString();
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
                li2.Value = Rd[1].ToString();
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
                    FillCombo();
                    foreach (ListItem li in FillOstan())
                    {
                        DropDownList1.Items.Add(li);
                    }
                    DropDownList1_SelectedIndexChanged(null, null);
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

        protected void drpSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataBaseContext db = new DataBaseContext();
                int id = int.Parse(drpSelect.SelectedItem.Value);
                db.Profile.Where(c => c.ID == id).Load();
                var obj = db.Profile.Local[0];
                txtName.Text = obj.Name;
                txtFamily.Text = obj.Family;
                txtTell1.Text = obj.Tell1;
                txtTell2.Text = obj.Tell2;
                Literal11.Text = obj.UniName;
                Literal10.Text = obj.ShahrestanName;
                Literal9.Text = obj.MarkazeBehdasht;
                Literal8.Text = obj.KhaneBehdast;
                Literal7.Text = obj.Code8Raghami;
                Literal6.Text = obj.Ostan;
                Literal5.Text = obj.Shahrestan;
                Literal4.Text = obj.Bakhsh;
                Literal3.Text = obj.Shahr;
                Literal2.Text = obj.Dehestan;
                Literal1.Text = obj.Rosta;
                txtEmail.Text = obj.Email;
                try
                {
                    DropDownList7.ClearSelection();
                    DropDownList7.SelectedIndex = DropDownList7.Items.IndexOf(DropDownList7.Items.FindByText(obj.Position));
                }
                catch { }
                txtEmail.Text = obj.Email;
                try
                {
                    drpSex.ClearSelection();
                    drpSex.SelectedIndex = drpSex.Items.IndexOf(drpSex.Items.FindByText(obj.Sex));
                }
                catch { }
            }
            catch { }
            litMess.Text = "";
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
                        drpShabakeShahrestan.Items.Add("");
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
                    drpShabakeShahrestan.Items.Add("");
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
            litMess.Text = "";
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            if (DropDownList1.SelectedIndex != -1)
            {
                SqlConnection Cn = new SqlConnection();
                Cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseContext"].ToString();
                SqlCommand Cm = new SqlCommand();
                Cm.Connection = Cn;
                Cm.CommandText = "select * from CountryDivision where AreaTypeCode = '2' AND ParentAreaCode = '" + DropDownList1.SelectedItem.Value + "'";
                SqlDataReader Rd;
                Cn.Open();
                Rd = Cm.ExecuteReader();
                if (Rd.HasRows)
                    DropDownList2.Items.Add("");
                while (Rd.Read())
                {
                    ListItem li2 = new ListItem();
                    li2.Text = Rd[2].ToString();
                    li2.Value = Rd[1].ToString();
                    DropDownList2.Items.Add(li2);
                }
                Cn.Close();
            }
            DropDownList2_SelectedIndexChanged(null, null);
            litMess.Text = "";
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
                DropDownList3.Items.Clear();
            if (DropDownList2.SelectedIndex != -1)
            {
                SqlConnection Cn = new SqlConnection();
                Cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseContext"].ToString();
                SqlCommand Cm = new SqlCommand();
                Cm.Connection = Cn;
                Cm.CommandText = "select * from CountryDivision where AreaTypeCode = '3' AND ParentAreaCode = '" + DropDownList2.SelectedItem.Value + "'";
                SqlDataReader Rd;
                Cn.Open();
                Rd = Cm.ExecuteReader();
                if (Rd.HasRows)
                    DropDownList3.Items.Add("");
                while (Rd.Read())
                {
                    ListItem li2 = new ListItem();
                    li2.Text = Rd[2].ToString();
                    li2.Value = Rd[1].ToString();
                    DropDownList3.Items.Add(li2);
                }
                Cn.Close();
            }
            DropDownList3_SelectedIndexChanged(null, null);
            litMess.Text = "";
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
                DropDownList4.Items.Clear();
            if (DropDownList3.SelectedIndex != -1)
            {
                SqlConnection Cn = new SqlConnection();
                Cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseContext"].ToString();
                SqlCommand Cm = new SqlCommand();
                Cm.Connection = Cn;
                Cm.CommandText = "select * from CountryDivision where AreaTypeCode = '4' AND ParentAreaCode = '" + DropDownList3.SelectedItem.Value + "'";
                SqlDataReader Rd;
                Cn.Open();
                Rd = Cm.ExecuteReader();
                if (Rd.HasRows)
                    DropDownList4.Items.Add("");
                while (Rd.Read())
                {
                    ListItem li2 = new ListItem();
                    li2.Text = Rd[2].ToString();
                    li2.Value = Rd[1].ToString();
                    DropDownList4.Items.Add(li2);
                }
                Cn.Close();
            } 
            FillAbadi();
            litMess.Text = "";
        }

        private void FillAbadi()
        {
            DropDownList5.Items.Clear();
            if (DropDownList4.SelectedIndex != -1)
            {
                SqlConnection Cn = new SqlConnection();
                Cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseContext"].ToString();
                SqlCommand Cm = new SqlCommand();
                Cm.Connection = Cn;
                Cm.CommandText = "select * from CountryDivision where AreaTypeCode = '5' AND ParentAreaCode = '" + DropDownList3.SelectedItem.Value + "'";
                SqlDataReader Rd;
                Cn.Open();
                Rd = Cm.ExecuteReader();
                if (Rd.HasRows)
                    DropDownList5.Items.Add("");
                while (Rd.Read())
                {
                    ListItem li2 = new ListItem();
                    li2.Text = Rd[2].ToString();
                    li2.Value = Rd[1].ToString();
                    DropDownList5.Items.Add(li2);
                }
                Cn.Close();
            }
            DropDownList5_SelectedIndexChanged(null, null);
            litMess.Text = "";
        }

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList6.Items.Clear();
            if (DropDownList5.SelectedIndex != -1)
            {
                SqlConnection Cn = new SqlConnection();
                Cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseContext"].ToString();
                SqlCommand Cm = new SqlCommand();
                Cm.Connection = Cn;
                Cm.CommandText = "select * from CountryDivision where AreaTypeCode = '6' AND ParentAreaCode = '" + DropDownList5.SelectedItem.Value + "'";
                SqlDataReader Rd;
                Cn.Open();
                Rd = Cm.ExecuteReader();
                if (Rd.HasRows)
                    DropDownList6.Items.Add("");
                while (Rd.Read())
                {
                    ListItem li2 = new ListItem();
                    li2.Text = Rd[2].ToString();
                    li2.Value = Rd[1].ToString();
                    DropDownList6.Items.Add(li2);
                }
                Cn.Close();
            }
            litMess.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue == "2")
            {
                List<LiveClassifi.ReqOrganization> lis = new List<LiveClassifi.ReqOrganization>();
                LiveClassifi.LiveClassificationClient client = new LiveClassifi.LiveClassificationClient();
                try
                {
                    lis.AddRange(client.GetBehdashtClassificationByParam(1000, (2).ToString(), (14554455).ToString()));
                    lis.AddRange(client.GetBehdashtClassificationByParam(1000, (28).ToString(), (14554455).ToString()));
                    drpUniName.Items.Add(new ListItem { Text = "", Value = "" });
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
                    drpUniName.Items.Add(li2);
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
                drpUniName.Items.Add(new ListItem { Text = "", Value = "" });
                while (Rd.Read())
                {
                    ListItem li2 = new ListItem();
                    li2.Text = Rd[1].ToString();
                    li2.Value = Rd[0].ToString();
                    drpUniName.Items.Add(li2);
                }
                Cn.Close();
            }
            litMess.Text = "";
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
                        drpMarkazBehdaaht.Items.Add("");
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
                    drpMarkazBehdaaht.Items.Add("");
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
            litMess.Text = "";
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
                        drpKhaneBehdasht.Items.Add("");
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
                    drpKhaneBehdasht.Items.Add("");
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
            litMess.Text = "";
        }

        protected void drpKhaneBehdasht_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpKhaneBehdasht.SelectedIndex != -1)
            {
                txt8Code.Text = drpKhaneBehdasht.SelectedItem.Value;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();
            int id = int.Parse(drpSelect.SelectedItem.Value);
            db.Profile.Where(c => c.ID == id).Load();
            db.Profile.Remove(db.Profile.Local[0]);
            db.SaveChanges();
            FillCombo();
            litMess.Text = "<div class='OKPM'>عملیات با موفقیت انجام شد</div>";
        }
    
        protected void btnTicketSend_Click(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();
            int id = int.Parse(drpSelect.SelectedItem.Value);
            try{db.Profile.Where(c => c.ID == id).Load();}catch{}
            try{db.Profile.Local[0].Name = txtName.Text;}catch{}
            try{db.Profile.Local[0].Family = txtFamily.Text;}catch{}
            try{db.Profile.Local[0].Tell1 = txtTell1.Text;}catch{}
            try{db.Profile.Local[0].Tell2 = txtTell2.Text;}catch{}
            try{db.Profile.Local[0].Bakhsh = DropDownList3.SelectedItem.Text;}catch{}
            try{db.Profile.Local[0].Code8Raghami = txt8Code.Text;}catch{}
            try{db.Profile.Local[0].Dehestan = DropDownList5.SelectedItem.Text;}catch{}
            try{db.Profile.Local[0].KhaneBehdast = drpKhaneBehdasht.SelectedItem.Text;}catch{}
            try{db.Profile.Local[0].MarkazeBehdasht = drpMarkazBehdaaht.SelectedItem.Text;}catch{}
            try{db.Profile.Local[0].Ostan = DropDownList1.SelectedItem.Text;}catch{}
            try{db.Profile.Local[0].Rosta = DropDownList6.SelectedItem.Text;}catch{}
            try{db.Profile.Local[0].Shahr = DropDownList4.SelectedItem.Text;}catch{}
            try{db.Profile.Local[0].Shahrestan = DropDownList2.SelectedItem.Text;}catch{}
            try{db.Profile.Local[0].UniName = drpUniName.SelectedItem.Text;}catch{}
            try { db.Profile.Local[0].ShahrestanName = drpShabakeShahrestan.SelectedItem.Text; } catch { }
            db.Profile.Local[0].Position = DropDownList7.SelectedItem.Text;
            db.Profile.Local[0].Email = txtEmail.Text;
            db.Profile.Local[0].Sex = drpSex.SelectedItem.Text;
            db.SaveChanges();
            litMess.Text = "<div class='OKPM'>عملیات با موفقیت انجام شد</div>";
        }
    }
}