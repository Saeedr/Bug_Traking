using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Bug_Traking.Tabels
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tblProfile")]
    public class Profile
    {
        public Profile()
        {

        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Schema.Column("ID")]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Tell1 { get; set; }
        public string Tell2 { get; set; }
        public string UniName { get; set; }
        public string ShahrestanName { get; set; }
        public string MarkazeBehdasht { get; set; }
        public string KhaneBehdast { get; set; }
        public string Code8Raghami { get; set; }
        public string Ostan { get; set; }
        public string Shahrestan { get; set; }
        public string Bakhsh { get; set; }
        public string Shahr { get; set; }
        public string Dehestan { get; set; }
        public string Rosta { get; set; }
        public string Sex { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string getName()
        {
            return Name + " " + Family;
        }
    }
}