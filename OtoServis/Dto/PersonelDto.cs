using OtoServis.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Dto
{
    public class PersonelDto
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Durum { get; set; }
        public string Rol { get; set; }
        public Personel Data { get; set; }
    }
}
