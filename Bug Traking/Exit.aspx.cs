using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bug_Traking
{
    public partial class Exit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("user");
            Session.Remove("support");
            Session.Remove("admin");
            Response.Redirect("Default.aspx");
        }
    }
}