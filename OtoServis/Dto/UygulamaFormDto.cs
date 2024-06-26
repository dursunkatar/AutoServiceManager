namespace OtoServis.Dto
{
    public class UygulamaFormDto
    {
        public int ID { get; set; }
        public string FormAciklama { get; set; }

        public override string ToString()
        {
            return FormAciklama;
        }
    }
}
