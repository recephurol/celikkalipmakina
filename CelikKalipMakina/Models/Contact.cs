using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CelikKalipMakina.Models
{
    [Table("Contact")]
    public class Contact
    {
        public string AdiSoyadi { get; set; }
        
        public string EMail { get; set; }

        public string Konu { get; set; }

        public string Telefon { get; set; }

        public string Mesaj { get; set; }
    }
}