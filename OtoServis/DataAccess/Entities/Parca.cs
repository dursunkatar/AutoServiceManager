using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.DataAccess.Entities
{
    public class Parca
    {
        [Key]
        public int ParcaID { get; set; }
        public string ParcaAdi { get; set; }
        public int StokAdet { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Fiyat { get; set; }
    }
}
