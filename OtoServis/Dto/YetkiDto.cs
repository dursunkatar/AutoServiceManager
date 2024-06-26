namespace OtoServis.Dto
{
    public class YetkiDto
    {
        public int Id { get; set; }
        public string YetkiAdi { get; set; }

        public override string ToString()
        {
            return YetkiAdi;
        }
    }
}
