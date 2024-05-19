using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Bug_Traking
{
    public partial class AdminKartable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBaseContext db = new DataBaseContext();
                if (Request.QueryString["Folder"] == null)
                {
                    db.Tikets.Where(c => c.Status != "حذف شده").OrderByDescending(c => c.ID).Load();
                }
                else
                {
                    Int32 ID2 = Int32.Parse(Request.QueryString["Folder"]);
                    db.Tikets.Where(c => c.FolderId == ID2 && c.Status != "حذف شده").OrderByDescending(c => c.ID).Load();
                }
                List<Tabels.Tikets> lisTik = new List<Tabels.Tikets>();
                int pageID = 0;
                // تعداد تیکت ها در هد صفحه
                int PageLen = 25;
                string s = "";
                if (Request.QueryString["PageId"] != null)
                {
                    pageID = int.Parse(Request.QueryString["PageId"]);
                }
                int i = 1;
                int j = 1;
                foreach (var obj in db.Tikets.Local)
                {
                    if (j > PageLen * pageID && j <= PageLen * pageID + PageLen)
                    {
                        System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                        string ss = pc.GetYear(obj.SendData) + "/" + pc.GetMonth(obj.SendData) + "/" + pc.GetDayOfMonth(obj.SendData);
                        if (Request.QueryString["Search"] == null || Request.QueryString["Search"] == ss)
                        {
                            if (Request.QueryString["SCode"] == null || obj.Title.Contains(Request.QueryString["SCode"]))
                            {
                                Tabels.Tikets tik = new Tabels.Tikets();
                                tik = obj;
                                tik.SendDataReport = pc.GetYear(obj.SendData) + "/" + pc.GetMonth(obj.SendData) + "/" + pc.GetDayOfMonth(obj.SendData);
                                if (obj.SeenData == null)
                                {
                                    tik.Part = "font-weight:bold;color:#9b0d0d;";
                                    tik.SeenDataReport = "دیده نشده";
                                }
                                else
                                {
                                    tik.Part = "";
                                    tik.SeenDataReport = pc.GetYear(obj.SeenData.Value) + "/" + pc.GetMonth(obj.SeenData.Value) + "/" + pc.GetDayOfMonth(obj.SeenData.Value);
                                }
                                tik.Description = obj.Description.Replace("#br#", "<br />");
                                if (obj.FileName == null)
                                    tik.FileName = "";
                                else
                                    tik.FileName = "<img src='pic/attach.svg' width='20' height='20'>";
                                if (obj.LastErrorID == null)
                                    tik.HasLastError = "ندارد";
                                else
                                    tik.HasLastError = "دارد";
                                lisTik.Add(tik);
                                i++;
                            }
                        }
                    }
                    j++;
                }
                if (db.Tikets.Local.Count > PageLen * pageID + PageLen)
                {
                    s += "<td><a href='?PageId=" + (pageID + 1);
                    if (Request.QueryString["Folder"] != null)
                        s += "&Folder=" + Request.QueryString["Folder"];
                    if (Request.QueryString["SCode"] != null)
                        s += "&SCode=" + Request.QueryString["SCode"];
                    s += "'><img style='margin-top:3px;' src='pic/RightFelesh.png' /></a></td>";
                }
                s += "<td><div style='color:#FFF;height:20px;padding:5px;border-radius:15px;background:url(pic/LoginBG.png);'>" + ((PageLen * pageID) + 1) + "-" + (PageLen * pageID + PageLen) + "</div></td>";
                if (Request.QueryString["PageId"] != null && Request.QueryString["PageId"] != "0")
                {
                    s += "<td><a href='?PageId=" + (pageID - 1);
                    if (Request.QueryString["Folder"] != null)
                        s += "&Folder=" + Request.QueryString["Folder"];
                    if (Request.QueryString["SCode"] != null)
                        s += "&SCode=" + Request.QueryString["SCode"];
                    s += "'><img style='margin-top:3px;' src='pic/LeftFelesh.png' /></a></td>";
                }
                litPage.Text = s;
                Repeater3.DataSource = lisTik.OrderByDescending(c => c.ID);
                Repeater3.DataBind();

                ListItem li2 = new ListItem();
                li2.Value = "-1";
                li2.Text = "همه";
                drpShowFolder.Items.Add(li2);
                db.Folders.Where(c => c.UserStatus == "Admin").Load();
                foreach (var obj in db.Folders.Local)
                {
                    ListItem li = new ListItem();
                    li.Value = obj.ID.ToString();
                    li.Text = obj.Name;
                    drpShowFolder.Items.Add(li);
                    drpSendTo.Items.Add(li);
                }
                drpShowFolder.SelectedValue = Request.QueryString["Folder"];
            }
        }

        protected void btnSearch2_Click(object sender, EventArgs e)
        {
            string s = "AdminKartable.aspx?";
            if (txtCode.Text != "")
                s += "SCode=" + txtCode.Text + "&";
            if (Request.Form["txtDate"] != "")
                s += "Search=" + Request.Form["txtDate"];
            Response.Redirect(s);
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
                            DataBaseContext db = new DataBaseContext();
                            db.Tikets.Where(c => c.ID == ID).Load();
                            if (db.Tikets.Local.Count != -1)
                            {
                                db.Tikets.Local[0].Status = "حذف شده";
                                db.SaveChanges();
                            }
                        }
                    }
                }
            }
            Response.Redirect("AdminKartable.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();
            Tabels.Folders fl = new Tabels.Folders();
            fl.Name = txtFoderAd.Text;
            fl.UserID = 0;
            fl.UserStatus = "Admin";
            db.Folders.Add(fl);
            db.SaveChanges();
            Response.Redirect("AdminKartable.aspx");
        }

        protected void btnShowFolder_Click(object sender, EventArgs e)
        {
            if (drpShowFolder.SelectedValue != "-1")
            {
                Response.Redirect("AdminKartable.aspx?Folder=" + drpShowFolder.SelectedValue);
            }
            else
            {
                Response.Redirect("AdminKartable.aspx");
            }
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
                            DataBaseContext db = new DataBaseContext();
                            db.Tikets.Where(c => c.ID == ID).Load();
                            if (db.Tikets.Local.Count != -1)
                            {
                                Int32 ID2 = Int32.Parse(drpSendTo.SelectedValue);
                                db.Tikets.Local[0].FolderId = ID2;
                                db.SaveChanges();
                                Response.Write("<script>alert('عملیات با موفقیت انجام شد')</script>");
                            }
                        }
                    }
                }
            }
        }
    }
}