using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Traking.Tabels
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tblTicketSupport")]

    public class TicketSupport
    {
        public TicketSupport()
        {

        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Schema.Column("ID")]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int TikID { get; set; }

        public int SupportID { get; set; }

        public int FolderID { get; set; }

        public int? PeigiriID { get; set; }

        public string Status { get; set; }

        public string Text { get; set; }
    }
}