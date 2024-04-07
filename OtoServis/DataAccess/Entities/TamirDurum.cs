using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OtoServis.DataAccess.Entities
{
    [Table("TamirDurum")]
    public class TamirDurum
    {
        [Key]
        public int Id { get; set; }
        public string Durum { get; set; }
    }
}
