using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public bool Silindimi { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
