using System.ComponentModel.DataAnnotations.Schema;

namespace OtoServis.DataAccess.Entities
{
    [Table("RolYetkisi")]
    public class RolYetkisi
    {
        public int Id { get; set; }

        [ForeignKey("Rol")]
        public int RolId { get; set; }

        [ForeignKey("UygulamaForm")]
        public int FormId { get; set; }

        [ForeignKey("Yetki")]
        public int YetkiId { get; set; }
        public Yetki Yetki { get; set; }
        public UygulamaForm UygulamaForm { get; set; }
        public Rol Rol { get; set; }
    }
}
