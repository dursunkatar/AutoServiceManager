using OtoServis.DataAccess.Entities;

namespace OtoServis.Dto
{
    public class RolYetkiDto
    {
        public string Rol { get; set; }
        public string Form { get; set; }
        public string Yetki { get; set; }
        public RolYetkisi Data { get; set; }
    }
}
