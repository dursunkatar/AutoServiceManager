using OtoServis.DataAccess.Entities;

namespace OtoServis.Dto
{
    public class SatisDto
    {
        public string Musteri { get; set; }
        public string Parca { get; set; }
        public int Miktar { get; set; }
        public decimal ToplamTutar { get; set; }
        public DateTime Tarih { get; set; }
        public string SatisPersonel { get; set; }
        public Satis Data { get; set; }
    }
}
