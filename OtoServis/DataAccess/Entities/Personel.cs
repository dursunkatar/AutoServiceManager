using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.DataAccess.Entities
{
    [Table("Personel")]
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public bool Aktifmi { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Maas { get; set; }

        [ForeignKey("Rol")]
        public int RolID { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
