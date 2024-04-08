using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OtoServis.DataAccess.Entities
{
    [Table("Tamir")]
    public class Tamir
    {
        [Key]
        public int TamirID { get; set; }

        [ForeignKey("Arac")]
        public int AracID { get; set; }

        [ForeignKey("MekanikUsta")]
        public int MekanikUstaID { get; set; }
        public DateTime TamirTarihi { get; set; }
        public string Aciklama { get; set; }

        [ForeignKey("TamirDurum")]
        public int TamirDurumId { get; set; }
        public virtual Arac Arac { get; set; }
        public virtual Personel MekanikUsta { get; set; }
        public virtual TamirDurum TamirDurum { get; set; }
    }
}
