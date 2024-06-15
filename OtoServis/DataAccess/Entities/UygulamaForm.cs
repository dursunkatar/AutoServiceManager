using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OtoServis.DataAccess.Entities
{
    [Table("UygulamaFormlari")]
    public class UygulamaForm
    {
        [Key]
        public int Id { get; set; }
        public string FormAdi { get; set; }
        public string FormAciklama { get; set; }
    }
}
