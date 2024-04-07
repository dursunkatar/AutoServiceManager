using OtoServis.DataAccess.Entities;

namespace OtoServis.Dto
{
    public class AracDto
    {
        public string Musteri { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Plaka { get; set; }
        public string Renk { get; set; }
        public int Yil { get; set; }
        public Arac Data { get; set; }
    }
}
