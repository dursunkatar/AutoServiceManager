﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OtoServis.DataAccess.Entities
{
    [Table("Parcalar")]
    public class Parca
    {
        [Key]
        public int ParcaID { get; set; }
        public string ParcaAdi { get; set; }
        public int StokAdet { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Fiyat { get; set; }
        public bool Silindimi { get; set; }
    }
}
