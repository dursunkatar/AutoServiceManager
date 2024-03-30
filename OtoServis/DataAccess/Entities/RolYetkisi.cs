using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.DataAccess.Entities
{
    [Table("RolYetkisi")]
    public class RolYetkisi
    {
        public int Id { get; set; }

        [ForeignKey("Rol")]
        public int RolId { get; set; }

        [ForeignKey("Yetki")]
        public int YetkiId { get; set; }
        public Yetki Yetki { get; set; }
        public Rol Rol { get; set; }
    }
}
