using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Traking.Tabels
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tblFolders")]
    public class Folders
    {
        public Folders()
        {
        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Schema.Column("ID")]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; }

        public int UserID { get; set; }

        public string UserStatus { get; set; }
    }
}