using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.DataAccess.Entities
{
    [Table("Rol")]
    public class Rol
    {
        [Key]
        public int RolID { get; set; }
        public string RolAdi { get; set; }
        public virtual ICollection<Personel> Personeller { get; set; }
    }
}
