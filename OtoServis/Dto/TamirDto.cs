using OtoServis.DataAccess.Entities;

namespace OtoServis.Dto
{
    public class TamirDto
    {
        public string Musteri { get; set; }
        public string Arac { get; set; }
        public string Usta { get; set; }
        public string Durum { get; set; }
        public DateTime TamirTarihi { get; set; }
        public string Aciklama { get; set; }
        public Tamir Data { get; set; }
    }
}
