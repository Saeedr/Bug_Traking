using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Traking.Tabels
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tblSupport")]
    public class Support
    {
        public Support()
        {

        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Schema.Column("ID")]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Tell { get; set; }
        public string PicUrl { get; set; }

    }
}