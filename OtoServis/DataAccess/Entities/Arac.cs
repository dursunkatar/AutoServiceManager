using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.DataAccess.Entities
{
    public class Arac
    {
        [Key]
        public int AracID { get; set; }

        [ForeignKey("Musteri")]
        public int MusteriID { get; set; }

        [Required]
        [StringLength(20)]
        public string Plaka { get; set; }

        [StringLength(50)]
        public string AracRenk { get; set; }

        [ForeignKey("Model")]
        public int ModelID { get; set; }

        [ForeignKey("Marka")]
        public int MarkaID { get; set; }

        public int Yil { get; set; }

        public virtual Musteri Musteri { get; set; }
        public virtual Model Model { get; set; }
        public virtual Marka Marka { get; set; }
    }
}
