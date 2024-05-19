using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Bug_Traking
{
    public partial class Support : System.Web.UI.MasterPage
    {

        private void FillEtelaiie()
        {
            litTopHalNashode.Text = "";
            DataBaseContext db2 = new DataBaseContext();
            Tabels.Support sp2 = Session["support"] as Tabels.Support;
            db2.Priority.Load();
            List<string> pri = new List<string>();
            List<int> prit = new List<int>();
            foreach (var obj in db2.Priority.Local)
            {
                pri.Add(obj.ID.ToString());
                prit.Add(obj.Timee);
            }
            db2.Tikets.Where(c => c.Status != "حذف شده").Load();
            List<Tabels.Tikets> lisTik = new List<Tabels.Tikets>();
            int i = 0;
            foreach (var obj in db2.Tikets.Local)
            {
                int Time = prit[pri.IndexOf(obj.Priority)];
                if ((DateTime.Now - obj.SendData).TotalHours >= Time)
                {
                    DataBaseContext db = new DataBaseContext();
                    db.TikSupport.Where(c => c.TikID == obj.ID && c.SupportID == sp2.ID && (c.Status == "جدید" || c.Status == "در حال بررسی")).Load();
                    if (db.TikSupport.Local.Count > 0)
                    {
                        System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                        string ss = pc.GetYear(obj.SendData) + "/" + pc.GetMonth(obj.SendData) + "/" + pc.GetDayOfMonth(obj.SendData);
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
                            tik.Part = "font-weight:bold;color:#000;";
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
                        if (i <= 4)
                            litTopHalNashode.Text += "<a href='SupportTiketShow.aspx?id=" + obj.ID + "'><div class='ButtonTopSearchItem'><div class='ButtonTopSearchItemTitle'>" + tik.Title + "</div><div class='ButtonTopSearchItemWho'>" + tik.UniName + "</div><div class='ButtonTopSearchItemDate'>" + tik.SendDataReport + "</div></div></a>";
                        lisTik.Add(tik);
                        i++;
                    }
                }
            }
            if (i > 0)
                litTikCount.Text = "<div class='HowIs'>" + i.ToString() + "</div>";
            Repeater3.DataSource = lisTik;
            Repeater3.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["support"] != null)
            {
                Response.Cache.SetExpires(DateTime.Now);
                Response.Cache.SetNoServerCaching();
                Response.Cache.SetNoStore();
                Tabels.Support sp = Session["support"] as Tabels.Support;
                Literal1.Text = "<img src='pic/" + sp.PicUrl + "' width='60' height='60' />";
                litTopProp.Text = "<span style='display:block;float:right;margin-right:10px;color:#FFF;margin-top:25px;'>" + sp.Name + " " + sp.Family + " خوش آمدید</span>";

                if (!IsPostBack)
                {
                    System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                    liDate.Text = "امروز : " + pc.GetYear(DateTime.Now) + "/" + pc.GetMonth(DateTime.Now) + "/" + pc.GetDayOfMonth(DateTime.Now);
                    DataBaseContext db = new DataBaseContext();
                    db.Folders.Where(c => c.UserStatus == "Admin").Load();
                    db.Folders.Where(c => c.UserID == sp.ID && c.UserStatus != "User").Load();
                    foreach (var obj in db.Folders.Local)
                    {
                        liFolder.Text += "<a href='SupportSearch.aspx?FolderID=" + obj.ID + "'>◄ " + obj.Name + "</a>";
                    }
                }
                FillEtelaiie();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}