using OtoServis.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Dto
{
    public class MusteriDto
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public DateTime KayitTarihi { get; set; }
        public Musteri Data { get; set; }
    }
}
