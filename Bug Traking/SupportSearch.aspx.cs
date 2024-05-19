using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Bug_Traking
{
    public partial class SupportSearch : System.Web.UI.Page
    {

        private void FillData()
        {
            drpUni.Items.Clear();
            List<LiveClassifi.ReqOrganization> lis = new List<LiveClassifi.ReqOrganization>();
            LiveClassifi.LiveClassificationClient client = new LiveClassifi.LiveClassificationClient();
            try
            {
                lis.AddRange(client.GetBehdashtClassificationByParam(1000, (2).ToString(), (14554455).ToString()));
                lis.AddRange(client.GetBehdashtClassificationByParam(1000, (28).ToString(), (14554455).ToString()));
                drpUni.Items.Add(new ListItem { Text = "", Value = "" });
            }
            catch (Exception ex)
            {
                LiveClassifi.ReqOrganization empLi = new LiveClassifi.ReqOrganization();
                empLi.OrganizationID8Digit = 0;
                empLi.LongName = "";
                lis.Add(empLi);
            }
            foreach (LiveClassifi.ReqOrganization obj in lis)
            {
                ListItem li = new ListItem();
                li.Text = obj.LongName;
                li.Value = obj.OrganizationID8Digit.ToString();
                drpUni.Items.Add(li);
            }
        }

        private void FillData2()
        {
            drpUni.Items.Clear();
            SqlConnection Cn = new SqlConnection();
            Cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseContext"].ToString();
            SqlCommand Cm = new SqlCommand();
            Cm.Connection = Cn;
            Cm.CommandText = "select distinct UniversityOrganizationID8Digit,UniversityLongName from [dbo].[HealthNetwork]";
            SqlDataReader Rd;
            drpUni.Items.Add(new ListItem { Text = "", Value = "" });
            Cn.Open();
            Rd = Cm.ExecuteReader();
            while (Rd.Read())
            {
                ListItem li = new ListItem();
                li.Text = Rd[1].ToString();
                li.Value = Rd[0].ToString();
                drpUni.Items.Add(li);
            }
            Cn.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["support"] != null)
            {
                if (!IsPostBack)
                {
                    System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                    List<Tabels.Tikets> tk = new List<Tabels.Tikets>();
                    DataBaseContext db = new DataBaseContext();
                    Tabels.Support sp = Session["support"] as Tabels.Support;
                    if (Request.QueryString["FolderID"] == null)
                    {
                        db.TikSupport.Where(c => c.SupportID == sp.ID && c.Status != "حذف شده" && c.Status != "بسته شده").Load();
                    }
                    else
                    {
                        int FID = int.Parse(Request.QueryString["FolderID"]);
                        db.TikSupport.Where(c => c.SupportID == sp.ID && c.Status != "حذف شده" && c.Status != "بسته شده" && c.FolderID == FID).Load();
                    }
                    foreach (var obj in db.TikSupport.Local)
                    {
                        DataBaseContext db2 = new DataBaseContext();
                        db2.Tikets.Where(c => c.ID == obj.TikID && c.Status != "حذف شده").Load();
                        if (db2.Tikets.Local.Count > 0)
                        {
                            Tabels.Tikets tik = db2.Tikets.Local[0];
                            tik.SendDataReport = pc.GetYear(tik.SendData) + "/" + pc.GetMonth(tik.SendData) + "/" + pc.GetDayOfMonth(tik.SendData);
                            if (tik.SeenData == null)
                            {
                                tik.Part = "font-weight:bold;color:#9b0d0d;";
                                tik.SeenDataReport = "دیده نشده";
                            }
                            else
                            {
                                tik.Part = "";
                                tik.SeenDataReport = pc.GetYear(tik.SeenData.Value) + "/" + pc.GetMonth(tik.SeenData.Value) + "/" + pc.GetDayOfMonth(tik.SeenData.Value);
                            }
                            tik.Description = tik.Description.Replace("#br#", "<br />");
                            if (tik.FileName == null)
                                tik.FileName = "";
                            else
                                tik.FileName = "<img src='pic/attach.svg' width='20' height='20'>";
                            if (tik.LastErrorID == null)
                                tik.HasLastError = "ندارد";
                            else
                                tik.HasLastError = "دارد";
                            tk.Add(tik);
                        }
                    }
                    Repeater3.DataSource = tk.OrderByDescending(c => c.ID);
                    Repeater3.DataBind();

                    FillData2();

                    db.Folders.Where(c => c.UserStatus == "Admin").Load();
                    db.Folders.Where(c => c.UserID == sp.ID && c.UserStatus != "User").Load();
                    foreach (var obj in db.Folders.Local)
                    {
                        ListItem li = new ListItem();
                        li.Value = obj.ID.ToString();
                        li.Text = obj.Name;
                        drpSendTo.Items.Add(li);
                    }
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnSearch2_Click(object sender, EventArgs e)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            List<Tabels.Tikets> tk = new List<Tabels.Tikets>();
            DataBaseContext db = new DataBaseContext();
            Tabels.Support sp = Session["support"] as Tabels.Support;
            if (Request.QueryString["FolderID"] == null)
            {
                db.TikSupport.Where(c => c.SupportID == sp.ID && c.Status != "حذف شده" && c.Status != "بسته شده").Load();
            }
            else
            {
                int FID = int.Parse(Request.QueryString["FolderID"]);
                db.TikSupport.Where(c => c.SupportID == sp.ID && c.Status != "حذف شده" && c.Status != "بسته شده" && c.FolderID == FID).Load();
            }
            foreach (var obj in db.TikSupport.Local)
            {
                db.Tikets.Local.Clear();
                db.Tikets.Where(c => c.ID == obj.TikID &&
                    c.Title.Contains(txtTitle.Text) &&
                    c.UserName.Contains(txtReportName.Text) &&
                    c.UniName.Contains(drpUni.Text) &&
                    c.ShahrestanName.Contains(drpShahrestan.Text) &&
                    c.MarkazeBehdasht.Contains(drpMarkazBehdasht.Text) &&
                    c.KhaneBehdast.Contains(drpPaigahBehdasht.Text) &&
                                    c.Status != "حذف شده").Load();
                if (db.Tikets.Local.Count > 0 && (Request.Form["txtDate"] == "" || Request.Form["txtDate"] == pc.GetYear(db.Tikets.Local[0].SendData) + "/" + pc.GetMonth(db.Tikets.Local[0].SendData) + "/" + pc.GetDayOfMonth(db.Tikets.Local[0].SendData)))
                {
                    DataBaseContext db2 = new DataBaseContext();
                    db2.Tikets.Where(c => c.ID == obj.TikID && c.Status != "حذف شده").Load();
                    if (db2.Tikets.Local.Count > 0)
                    {
                        Tabels.Tikets tik = db2.Tikets.Local[0];
                        tik.SendDataReport = pc.GetYear(tik.SendData) + "/" + pc.GetMonth(tik.SendData) + "/" + pc.GetDayOfMonth(tik.SendData);
                        if (tik.SeenData == null)
                        {
                            tik.Part = "font-weight:bold;color:#9b0d0d;";
                            tik.SeenDataReport = "دیده نشده";
                        }
                        else
                        {
                            tik.Part = "";
                            tik.SeenDataReport = pc.GetYear(tik.SeenData.Value) + "/" + pc.GetMonth(tik.SeenData.Value) + "/" + pc.GetDayOfMonth(tik.SeenData.Value);
                        }
                        tik.Description = tik.Description.Replace("#br#", "<br />");
                        if (tik.FileName == null)
                            tik.FileName = "";
                        else
                            tik.FileName = "<img src='pic/attachment-icon.png' width='15' height='15'>";
                        if (tik.LastErrorID == null)
                            tik.HasLastError = "ندارد";
                        else
                            tik.HasLastError = "دارد";
                        tk.Add(tik);
                    }
                }
                Repeater3.DataSource = tk.OrderByDescending(c => c.ID);
                Repeater3.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();
            Tabels.Folders fl = new Tabels.Folders();
            fl.Name = txtFoderAd.Text;
            Tabels.Support sp = Session["support"] as Tabels.Support;
            fl.UserID = sp.ID;
            fl.UserStatus = "Support";
            db.Folders.Add(fl);
            db.SaveChanges();
            Response.Redirect("SupportSearch.aspx");
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            foreach (Control ctn in Repeater3.Items)
            {
                foreach (Control ctn2 in ctn.Controls)
                {
                    if (ctn2 is CheckBox)
                    {
                        CheckBox chk = ctn2 as CheckBox;
                        if (chk.Checked == true)
                        {
                            int ID = int.Parse(chk.Attributes["mohsenID"]);
                            Tabels.Support sp = Session["support"] as Tabels.Support;
                            DataBaseContext db = new DataBaseContext();
                            db.TikSupport.Where(c => c.TikID == ID && c.SupportID == sp.ID).Load();    
                            if (db.TikSupport.Local.Count > 0)
                            {
                                db.TikSupport.Local[0].Status = "حذف شده";
                                db.SaveChanges();
                            }
                        }
                    }
                }
            }
            Response.Redirect("SupportSearch.aspx");
        }

        protected void btnSendTo_Click(object sender, EventArgs e)
        {
            foreach (Control ctn in Repeater3.Items)
            {
                foreach (Control ctn2 in ctn.Controls)
                {
                    if (ctn2 is CheckBox)
                    {
                        CheckBox chk = ctn2 as CheckBox;
                        if (chk.Checked == true)
                        {
                            int ID = int.Parse(chk.Attributes["mohsenID"]);
                            Tabels.Support sp = Session["support"] as Tabels.Support;
                            DataBaseContext db = new DataBaseContext();
                            db.TikSupport.Where(c => c.TikID == ID && c.SupportID == sp.ID).Load();
                            if (db.TikSupport.Local.Count != -1)
                            {
                                Int32 ID2 = Int32.Parse(drpSendTo.SelectedValue);
                                db.TikSupport.Local[0].FolderID = ID2;
                                db.SaveChanges();
                                Response.Write("عملیات با موفقیت انجاو شد");
                            }
                        }
                    }
                }
            }
        }

        protected void drpUni_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpShahrestan.Items.Clear();
            if (drpUni.SelectedIndex != -1)
            {
                if (RadioButtonList1.SelectedItem.Value == "2")
                {
                    List<LiveClassifi.ReqOrganization> lis = new List<LiveClassifi.ReqOrganization>();
                    LiveClassifi.LiveClassificationClient client = new LiveClassifi.LiveClassificationClient();
                    try
                    {
                        lis.AddRange(client.GetBehdashtClassificationByParam(1000, (3).ToString(), (drpUni.SelectedItem.Value).ToString()));
                        drpShahrestan.Items.Add(new ListItem { Text = "", Value = "" });
                    }
                    catch (Exception ex)
                    {
                        LiveClassifi.ReqOrganization empLi = new LiveClassifi.ReqOrganization();
                        empLi.OrganizationID8Digit = 0;
                        empLi.LongName = "";
                        lis.Add(empLi);
                        RadioButtonList1.Items.FindByValue("1").Selected = true;
                    }
                    foreach (LiveClassifi.ReqOrganization obj in lis)
                    {
                        ListItem li = new ListItem();
                        li.Text = obj.LongName;
                        li.Value = obj.OrganizationID8Digit.ToString();
                        drpShahrestan.Items.Add(li);
                    }
                }
                else
                {
                    SqlConnection Cn = new SqlConnection();
                    Cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseContext"].ToString();
                    SqlCommand Cm = new SqlCommand();
                    Cm.Connection = Cn;
                    Cm.CommandText = "select distinct ShabakeOrganizationID8Digit,ShabakeLongName from [dbo].[HealthNetwork] where UniversityOrganizationID8Digit ='" + drpUni.SelectedItem.Value.ToString() + "'";
                    SqlDataReader Rd;
                    drpShahrestan.Items.Add(new ListItem { Text = "", Value = "" });
                    Cn.Open();
                    Rd = Cm.ExecuteReader();
                    while (Rd.Read())
                    {
                        ListItem li = new ListItem();
                        li.Text = Rd[1].ToString();
                        li.Value = Rd[0].ToString();
                        drpShahrestan.Items.Add(li);
                    }
                    Cn.Close();
                }
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedItem.Value == "2")
            {
                FillData();
            }
            else
            {
                FillData2();
            }
        }

        protected void drpShahrestan_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpMarkazBehdasht.Items.Clear();
            if (drpShahrestan.SelectedIndex != -1)
            {
                if (RadioButtonList1.SelectedItem.Value == "2")
                {
                    List<LiveClassifi.ReqOrganization> lis = new List<LiveClassifi.ReqOrganization>();
                    LiveClassifi.LiveClassificationClient client = new LiveClassifi.LiveClassificationClient();
                    try
                    {
                        lis.AddRange(client.GetBehdashtClassificationByParam(1000, (26).ToString(), (drpShahrestan.SelectedItem.Value).ToString()));
                        drpMarkazBehdasht.Items.Add(new ListItem { Text = "", Value = "" });
                    }
                    catch (Exception ex)
                    {
                        LiveClassifi.ReqOrganization empLi = new LiveClassifi.ReqOrganization();
                        empLi.OrganizationID8Digit = 0;
                        empLi.LongName = "";
                        lis.Add(empLi);
                        RadioButtonList1.Items.FindByValue("1").Selected = true;
                    }
                    foreach (LiveClassifi.ReqOrganization obj in lis)
                    {
                        ListItem li = new ListItem();
                        li.Text = obj.LongName;
                        li.Value = obj.OrganizationID8Digit.ToString();
                        drpMarkazBehdasht.Items.Add(li);
                    }
                }
                else
                {
                    SqlConnection Cn = new SqlConnection();
                    Cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseContext"].ToString();
                    SqlCommand Cm = new SqlCommand();
                    Cm.Connection = Cn;
                    Cm.CommandText = "select distinct MarkazOrganizationID8Digit,MarkazLongName from [dbo].[HealthNetwork] where ShabakeOrganizationID8Digit ='" + drpShahrestan.SelectedItem.Value.ToString() + "'";
                    SqlDataReader Rd;
                    drpMarkazBehdasht.Items.Add(new ListItem { Text = "", Value = "" });
                    Cn.Open();
                    Rd = Cm.ExecuteReader();
                    while (Rd.Read())
                    {
                        ListItem li = new ListItem();
                        li.Text = Rd[1].ToString();
                        li.Value = Rd[0].ToString();
                        drpMarkazBehdasht.Items.Add(li);
                    }
                    Cn.Close();
                }
            }
        }

        protected void drpMarkazBehdasht_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpPaigahBehdasht.Items.Clear();
            if (drpMarkazBehdasht.SelectedIndex != -1)
            {
                if (RadioButtonList1.SelectedItem.Value == "2")
                {
                    List<LiveClassifi.ReqOrganization> lis = new List<LiveClassifi.ReqOrganization>();
                    LiveClassifi.LiveClassificationClient client = new LiveClassifi.LiveClassificationClient();
                    try
                    {
                        lis.AddRange(client.GetBehdashtClassificationByParam(1000, (15).ToString(), (drpMarkazBehdasht.SelectedItem.Value).ToString()));
                        drpPaigahBehdasht.Items.Add(new ListItem { Text = "", Value = "" });
                    }
                    catch (Exception ex)
                    {
                        LiveClassifi.ReqOrganization empLi = new LiveClassifi.ReqOrganization();
                        empLi.OrganizationID8Digit = 0;
                        empLi.LongName = "";
                        lis.Add(empLi);
                        RadioButtonList1.Items.FindByValue("1").Selected = true;
                    }
                    foreach (LiveClassifi.ReqOrganization obj in lis)
                    {
                        ListItem li = new ListItem();
                        li.Text = obj.LongName;
                        li.Value = obj.OrganizationID8Digit.ToString();
                        drpPaigahBehdasht.Items.Add(li);
                    }
                }
                else
                {
                    SqlConnection Cn = new SqlConnection();
                    Cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseContext"].ToString();
                    SqlCommand Cm = new SqlCommand();
                    Cm.Connection = Cn;
                    Cm.CommandText = "select distinct OrganizationID8Digit,LongName from [dbo].[HealthNetwork] where MarkazOrganizationID8Digit ='" + drpMarkazBehdasht.SelectedItem.Value.ToString() + "'";
                    SqlDataReader Rd;
                    drpPaigahBehdasht.Items.Add(new ListItem { Text = "", Value = "" });
                    Cn.Open();
                    Rd = Cm.ExecuteReader();
                    while (Rd.Read())
                    {
                        ListItem li = new ListItem();
                        li.Text = Rd[1].ToString();
                        li.Value = Rd[0].ToString();
                        drpPaigahBehdasht.Items.Add(li);
                    }
                    Cn.Close();
                }
            }
        }
    }
}