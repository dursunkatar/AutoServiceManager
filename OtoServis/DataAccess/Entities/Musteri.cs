using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.DataAccess.Entities
{
    [Table("Musteriler")]
    public class Musteri
    {
        [Key]
        public int MusteriID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public bool Silindimi { get; set; }
        public DateTime KayitTarihi { get; set; }
        public virtual ICollection<Arac> Araclar { get; set; }
    }
}
