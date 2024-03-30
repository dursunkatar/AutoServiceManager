using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.DataAccess.Entities
{
    [Table("Tamir")]
    public class Tamir
    {
        [Key]
        public int TamirID { get; set; }

        [ForeignKey("Arac")]
        public int AracID { get; set; }

        [ForeignKey("Personel")]
        public int MekanikUstaID { get; set; }
        public DateTime TamirTarihi { get; set; }
        public string Aciklama { get; set; }
        public string Durum { get; set; }
        public virtual Arac Arac { get; set; }
        public virtual Personel Personel { get; set; }
    }
}
