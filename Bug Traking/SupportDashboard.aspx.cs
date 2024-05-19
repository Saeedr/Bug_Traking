using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Bug_Traking
{
    public partial class SupportDashboard : System.Web.UI.Page
    {
        string ChartItem = @"<script type='text/javascript'>
$(function () {
    $('#container').highcharts({
         colors: ['#FF0000', '#F9BF3B', '#2ECC71'],
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false,
            backgroundColor:'transparent'
        },
        title: {
            text: 'خطاهایی که گزارش شده اند'
        },
        tooltip: {
            pointFormat: '<br />{series.name}: <b>{point.percentage:.1f}%</b>'
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                    }
                }
            }
        },
        series: [{type: 'pie',name: 'خطاها',data: [['خطاهای جدید',#1#],['در حال بررسی',#2#],['بسته شده',#3#]]}]
    });
});
</script>";

        string Chart2 = @"    		<script type='text/javascript'>
    		    $(function () {
    		        $('#container1').highcharts({
    		            chart: {
    		                type: 'column',
                            backgroundColor:'transparent'
    		            },
    		            title: {
    		                text: 'میزان خطاهای گزارش شده'
    		            },
    		            subtitle: {
    		                text: 'خطاهای گزارش شده توسط مراکز'
    		            },
                        plotOptions:{
                            area: {
                                    marker: {
                                        lineColor:'#f0f20a'
                                    }
                            }
                        },
    		            xAxis: {
    		                type: 'category',
    		                labels: {
    		                    rotation: -45,
    		                    style: {
    		                        fontSize: '13px'
    		                    }
    		                }
    		            },
    		            yAxis: {
    		                min: 0,
    		                title: {
    		                    text: 'تعداد خطاها'
    		                }
    		            },
    		            legend: {
    		                enabled: false
    		            },
    		            tooltip: {
                            usehtml:true,
                        formatter: function () {
                            return 'تعداد خطاها : <b>'+this.y+'</b>';
                        }
    		            },
    		            series: [{
    		                name: 'Population',
    		                data: [
                                #inja#
    		                ],
    		                dataLabels: {
    		                    enabled: true,
    		                    rotation: -90,
    		                    color: '#FFFFFF',
    		                    align: 'right',
    		                    format: '{point.y:.1f}', // one decimal
    		                    y: 10, // 10 pixels down from the top
    		                    style: {
    		                        fontSize: '13px',
    		                    }
    		                }
    		            }]
    		        });
    		    });
		</script>";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["support"] != null)
            {
                /////////////////////////////////////////////////////////////////
                DataBaseContext db = new DataBaseContext();
                Tabels.Support sp = Session["support"] as Tabels.Support;
                db.TikSupport.Where(c => c.SupportID == sp.ID).Load();
                int num1 = 0, num2 = 0, num3 = 0;
                foreach (var obj in db.TikSupport.Local)
                {
                    DataBaseContext db2 = new DataBaseContext();
                    TimeSpan span = new TimeSpan(31);
                    db2.Tikets.Where(c => c.ID == obj.TikID && c.Status != "حذف شده").Load();
                    try
                    {
                        int Datee = int.Parse((DateTime.Now - db2.Tikets.Local[0].SendData).Days.ToString());
                        if (Datee < 31)
                        {
                            if (obj.Status == "جدید")
                                num1++;
                            if (obj.Status == "در حال بررسی")
                                num2++;
                            if (obj.Status == "بسته شده")
                                num3++;
                        }
                    }
                    catch { }
                }
                ChartItem = ChartItem.Replace("#1#", num1.ToString());
                ChartItem = ChartItem.Replace("#2#", num2.ToString());
                ChartItem = ChartItem.Replace("#3#", num3.ToString());
                Literal1.Text = ChartItem;
                ////////////////////////////////////////////////////////////////
                List<string> name = new List<string>();
                List<int> num = new List<int>();
                foreach (var obj in db.TikSupport.Local)
                {
                    DataBaseContext db2 = new DataBaseContext();
                    TimeSpan span = new TimeSpan(31);
                    db2.Tikets.Where(c => c.ID == obj.TikID).Load();
                    int Datee = int.Parse((DateTime.Now - db2.Tikets.Local[0].SendData).Days.ToString());
                    if (name.IndexOf(db2.Tikets.Local[0].UniName) != -1)
                    {
                        if (Datee < 31)
                            num[name.IndexOf(db2.Tikets.Local[0].UniName)]++;
                    }
                    else
                    {
                        if (Datee < 31)
                        {
                            name.Add(db2.Tikets.Local[0].UniName);
                            num.Add(1);
                        }
                    }
                }
                string s = "";
                int i = 0;
                foreach (string s2 in name)
                {
                    s += "['" + s2 + "', " + num[i].ToString() + "],";
                    i++;
                }
                if (s.Length > 0)
                    s = s.Substring(0, s.Length - 1);
                Literal2.Text = Chart2.Replace("#inja#", s);

            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}