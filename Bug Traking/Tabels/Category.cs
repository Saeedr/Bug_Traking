using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Traking.Tabels
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tblCategory")]
    public class Category 
    {
        /// <summary>
        /// سازنده پیشفرض جدول دسته بندی ها
        /// </summary>
        public Category()
        {
            ID = Guid.NewGuid();
        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Schema.Column("ID")]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        public Guid ID { get; set; }

        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        public Guid PartsID { get; set; }
    }
}