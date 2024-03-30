using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.DataAccess.Entities
{
    public class Marka
    {
        [Key]
        public int MarkaID { get; set; }
    
        public string MarkaAdi { get; set; }

        public virtual ICollection<Model> Modeller { get; set; }
    }
}
