using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Traking.Tabels
{
    /// <summary>
    /// تعیین نام جدول درون بانک اطلاعاتی
    /// </summary>
    [System.ComponentModel.DataAnnotations.Schema.Table("tblTicket")]
    public class Tikets
    {
        /// <summary>
        /// سازنده پیفرض کلاس
        /// </summary>
        public Tikets()
        {
        }

        /// <summary>
        /// پراپرتی های کلاس را تعریف میکنیم که پراپرتی هایی که هم گت دارند هم ست در جدول به عنوان فیلدها در نظر گرفته میشوند
        /// </summary>

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Schema.Column("ID")]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Schema.Column("SendData", TypeName = "datetime")]
        public DateTime SendData { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.Column("SeenData", TypeName = "datetime")]
        public DateTime? SeenData { get; set; }

        public string Title { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.Column("UserID", Order = 1)]
        public int? UserID { get; set; }

        public int? LastErrorID { get; set; }

        public string Priority { get; set; }

        public int? FolderId { get; set; }

        public string FileName { get; set; }

        public string ProjectName { get; set; }

        public string Ssystem { get; set; }

        public string Service { get; set; }

        public string Part { get; set; }

        public string Category { get; set; }

        public string TicketOK { get; set; }

        public string CatID { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public string UserName { get; set; }

        public string UniName { get; set; }
        public string ShahrestanName { get; set; }
        public string MarkazeBehdasht { get; set; }
        public string KhaneBehdast { get; set; }
        public string Code8Raghami { get; set; }
        public string Shedat { get; set; }


        [System.ComponentModel.DataAnnotations.Schema.Column("KeyWords")]
        public string keyWords { get; set; }
        /// <summary>
        /// روالی برای تفکیک و حصول اطمینان از ارسال صحیح کلمات کلیدی و یکپارچه سازی اصولی آن ها
        /// </summary>
        /// <param name="words">ارایه ای کلمات کلیدی ارسال شده</param>
        public void KeyWords(params string[] words)
        {
            string Res = "";
            foreach (string s in words)
            {
                Res += s + ",";
            }
            Res = Res.Substring(0, Res.Length - 1);
            keyWords = Res;
        }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string SendDataReport { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string HasLastError { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string SeenDataReport { get; set; } 
        
        public string IDName
        {
            get 
            {
                return ID + " - " + Title;
            }
        }
    }
}
