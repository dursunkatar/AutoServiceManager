using OtoServis.DataAccess.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace OtoServis.Dto
{
    public class ParcaDto
    {
        public string ParcaAdi { get; set; }
        public int StokAdet { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Fiyat { get; set; }
        public Parca Data { get; set; }
    }
}
