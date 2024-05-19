using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Traking
{
  public  class DataBaseContext : System.Data.Entity.DbContext
    {
        /// <summary>
        /// سازنده پیشفرض کلاسمون
        /// درصورت ایجاد تغییر در پراپرتی های کلاس های موجودیت بانک اطلاعاتی بازسازی خواهد شد
        /// </summary>
        static DataBaseContext()
        {
            //System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<DataBaseContext>());
            //System.Data.Entity.Database.SetInitializer(new dbInitial());
        }

        public System.Data.Entity.DbSet<Tabels.Tikets> Tikets { get; set; }
        public System.Data.Entity.DbSet<Tabels.Projects> Projects { get; set; }
        public System.Data.Entity.DbSet<Tabels.Category> Category { get; set; }
        public System.Data.Entity.DbSet<Tabels.Parts> Parts { get; set; }
        public System.Data.Entity.DbSet<Tabels.Service> Service { get; set; }
        public System.Data.Entity.DbSet<Tabels.Ssystem> Ssystem { get; set; }
        public System.Data.Entity.DbSet<Tabels.User> Users { get; set; }
        public System.Data.Entity.DbSet<Tabels.Folders> Folders { get; set; }
        public System.Data.Entity.DbSet<Tabels.Priority> Priority { get; set; }
        public System.Data.Entity.DbSet<Tabels.TicketSupport> TikSupport { get; set; }
        public System.Data.Entity.DbSet<Tabels.Support> Support { get; set; }
        public System.Data.Entity.DbSet<Tabels.Comment> Comment { get; set; }
        public System.Data.Entity.DbSet<Tabels.TiketOK> TiketOK { get; set; }
        public System.Data.Entity.DbSet<Tabels.Profile> Profile { get; set; }
        public System.Data.Entity.DbSet<Tabels.Shedat> Shedat { get; set; }
        public System.Data.Entity.DbSet<Tabels.Position> Position { get; set; }
        public System.Data.Entity.DbSet<Tabels.KeyWords> KeyWords { get; set; }
    }
}
