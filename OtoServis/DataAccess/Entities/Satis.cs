using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OtoServis.DataAccess.Entities
{
    [Table("Satis")]
    public class Satis
    {
        [Key]
        public int SatisID { get; set; }

        [ForeignKey("Parca")]
        public int ParcaID { get; set; }

        [ForeignKey("SatisPersonel")]
        public int SatisPersonelID { get; set; }

        [ForeignKey("Musteri")]
        public int MusteriID { get; set; }

        [ForeignKey("Arac")]
        public int AracId { get; set; }

        public int Miktar { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal ToplamTutar { get; set; }
        public DateTime Tarih { get; set; }

        public virtual Parca Parca { get; set; }
        public virtual Personel SatisPersonel { get; set; }
        public virtual Musteri Musteri { get; set; }
        public virtual Arac Arac { get; set; }
    }
}
