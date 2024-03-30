using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.DataAccess.Entities
{
    [Table("Yetkiler")]
    public class Yetki
    {
        [Key]
        public int Id { get; set; }
        public string Baslik { get; set; }
        public virtual ICollection<RolYetkisi> RolYetkileri { get; set; }
    }
}
