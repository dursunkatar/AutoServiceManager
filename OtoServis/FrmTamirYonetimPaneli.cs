using Microsoft.EntityFrameworkCore;
using OtoServis.DataAccess;
using OtoServis.DataAccess.Context;
using OtoServis.Dto;
using OtoServis.Helper;
using System.Data;

namespace OtoServis
{
    public partial class FrmTamirYonetimPaneli : Form
    {
        private readonly AppDbContext dbContext;
        private bool isSaving = true;
        public FrmTamirYonetimPaneli()
        {
            InitializeComponent();
            dbContext = DbContextBuilder.Build();
        }


        void MusterileriYukle()
        {
            var data = dbContext.Musteriler.Where(x => !x.Silindimi).Select(x => new TextValueDto<int>
            {
                Text = $"{x.Ad} {x.Soyad} - ({x.Telefon})",
                Value = x.MusteriID

            }).ToList();

            data.Insert(0, new TextValueDto<int>
            {
                Text = "Seçiniz",
                Value = -1
            });

            ComboBoxHelper.LoadData(cmbMusteri, data, "Text", "Value");
        }

        void AraclariYukle(int musteriId)
        {
            var data = dbContext.Araclar
                .Include(x => x.Marka)
                .Include(x => x.Model)
                .Where(x => x.MusteriID == musteriId)
                .Select(x => new TextValueDto<int>
                {
                    Text = $"{x.Plaka} - ({x.Marka.MarkaAdi}  {x.Model.ModelAdi})",
                    Value = x.AracID

                }).ToList();


            data.Insert(0, new TextValueDto<int>
            {
                Text = "Seçiniz",
                Value = -1
            });

            ComboBoxHelper.LoadData(cmbArac, data, "Text", "Value");
        }

        private void FrmTamirYonetimPaneli_Load(object sender, EventArgs e)
        {
            MusterileriYukle();
        }

        private void cmbMusteri_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextValueDto<int> selectedData = cmbMusteri.SelectedItem as TextValueDto<int>;

            if (selectedData != null)
            {
                AraclariYukle(selectedData.Value);
            }
        }
    }
}
