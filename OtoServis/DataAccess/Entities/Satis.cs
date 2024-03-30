using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.DataAccess.Entities
{
    public class Satis
    {
        [Key]
        public int SatisID { get; set; }

        [ForeignKey("Parca")]
        public int ParcaID { get; set; }

        [ForeignKey("Personel")]
        public int SatisPersonelID { get; set; }

        [ForeignKey("Musteri")]
        public int MusteriID { get; set; }

        public int Miktar { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal ToplamTutar { get; set; }
        public DateTime Tarih { get; set; }

        public virtual Parca Parca { get; set; }
        public virtual Personel Personel { get; set; }
        public virtual Musteri Musteri { get; set; }
    }
}
