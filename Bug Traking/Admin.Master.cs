using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Bug_Traking
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                litTopHalNashode.Text = "";
                DataBaseContext db = new DataBaseContext();
                db.Priority.Load();
                List<string> pri = new List<string>();
                List<int> prit = new List<int>();
                foreach (var obj in db.Priority.Local)
                {
                    pri.Add(obj.ID.ToString());
                    prit.Add(obj.Timee);
                }
                db.Tikets.Where(c => c.Status != "حذف شده").Load();
                List<Tabels.Tikets> lisTik = new List<Tabels.Tikets>();
                int i = 0;
                foreach (var obj in db.Tikets.Local)
                {
                    try
                    {
                        int Time = prit[pri.IndexOf(obj.Priority)];
                        if ((DateTime.Now - obj.SendData).TotalHours >= Time)
                        {
                            DataBaseContext db2 = new DataBaseContext();
                            db2.TikSupport.Where(c => c.TikID == obj.ID && (c.Status == "جدید" || c.Status == "در حال بررسی")).Load();
                            if (db2.TikSupport.Local.Count > 0)
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
                                    litTopHalNashode.Text += "<a href='AdminTiketShow.aspx?id=" + obj.ID + "'><div class='ButtonTopSearchItem'><div class='ButtonTopSearchItemTitle'>" + tik.Title + "</div><div class='ButtonTopSearchItemWho'>" + tik.UniName + "</div><div class='ButtonTopSearchItemDate'>" + tik.SendDataReport + "</div></div></a>";
                                lisTik.Add(tik);
                                i++;
                            }
                        }
                    }
                    catch { }
                }
                if (i > 0)
                    litTikCount.Text = "<div class='HowIs'>" + i.ToString() + "</div>";
                Repeater3.DataSource = lisTik;
                Repeater3.DataBind();
            }
        }
    }
}