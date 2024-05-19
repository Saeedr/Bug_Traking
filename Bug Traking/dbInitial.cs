using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Bug_Traking
{
    public class dbInitial : System.Data.Entity.DropCreateDatabaseIfModelChanges<DataBaseContext>
    {
        public dbInitial()
        {
            
        }

        protected override void Seed(DataBaseContext dbc)
        {
            base.Seed(dbc);
        }
    }
}