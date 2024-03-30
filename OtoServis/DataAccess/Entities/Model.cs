using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.DataAccess.Entities
{
    [Table("Model")]
    public class Model
    {
        [Key]
        public int ModelID { get; set; }

        public string ModelAdi { get; set; }

        public int Yil { get; set; }

        [ForeignKey("Marka")]
        public int MarkaID { get; set; }

        public virtual Marka Marka { get; set; }
        public virtual ICollection<Arac> Araclar { get; set; }
    }
}
