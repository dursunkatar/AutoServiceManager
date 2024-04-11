using Microsoft.EntityFrameworkCore;
using OtoServis.DataAccess;
using OtoServis.DataAccess.Context;
using OtoServis.DataAccess.Entities;
using OtoServis.Dto;
using OtoServis.Helper;
using System.Data;

namespace OtoServis
{
    public partial class FrmSatisPaneli : Form
    {
        private readonly AppDbContext dbContext;
        private bool isSaving = true;
        public FrmSatisPaneli()
        {
            InitializeComponent();
            dbContext = DbContextBuilder.Build();
        }

        void SaatisEkle()
        {
            var secilenMusteri = cmbMusteri.SelectedItem as TextValueDto<int>;
            var secilenArac = cmbArac.SelectedItem as TextValueDto<int>;
            var secilenParca = cmbParca.SelectedItem as TextValueDto<int>;
            var secilenSatisPersonel = cmbSatisPersonel.SelectedItem as TextValueDto<int>;

            string miktarBilgisi = txtMiktar.Text.Trim();
            string tutarBilgisi = txtTutar.Text.Trim();

            if (secilenMusteri is null || secilenMusteri.Value == -1)
            {
                MessageBox.Show("Müşteri seçiniz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (secilenArac is null || secilenArac.Value == -1)
            {
                MessageBox.Show("Araç seçiniz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (secilenParca is null || secilenParca.Value == -1)
            {
                MessageBox.Show("Parça seçiniz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (secilenSatisPersonel is null || secilenSatisPersonel.Value == -1)
            {
                MessageBox.Show("Satış Personeli seçiniz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(tutarBilgisi, out decimal tutar))
            {
                MessageBox.Show("Tutar bilgisi geçersiz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(miktarBilgisi, out int miktar))
            {
                MessageBox.Show("Miktar bilgisi geçersiz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dbContext.Satislar.Add(new Satis
            {
                AracId = secilenParca.Value,
                Miktar = miktar,
                MusteriID = secilenMusteri.Value,
                ParcaID = secilenParca.Value,
                SatisPersonelID = secilenSatisPersonel.Value,
                Tarih = dtpSatisTarihi.Value,
                ToplamTutar = tutar
            });

            dbContext.SaveChanges();
            InputlariTemizle();
            MessageBox.Show("Kayıt başarılı", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        void InputlariTemizle()
        {

        }

        void ParcalariYukle()
        {
            var data = dbContext.Parcalar
                 .Select(x => new TextValueDto<int>
                 {
                     Text = x.ParcaAdi,
                     Value = x.ParcaID

                 }).ToList();


            data.Insert(0, new TextValueDto<int>
            {
                Text = "Seçiniz",
                Value = -1
            });

            ComboBoxHelper.LoadData(cmbParca, data, "Text", "Value");
        }

        void SatisPersonelYukle()
        {
            const int SATIS_PERSONEL = 4;
            var data = dbContext.Personeller
                .Where(x => x.RolID == SATIS_PERSONEL)
                .Select(x => new TextValueDto<int>
                {
                    Text = $"{x.Ad} {x.Soyad}",
                    Value = x.PersonelID
                }).ToList();

            data.Insert(0, new TextValueDto<int>
            {
                Text = "Seçiniz",
                Value = -1
            });

            ComboBoxHelper.LoadData(cmbSatisPersonel, data, "Text", "Value");
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

        private void FrmSatisPaneli_Load(object sender, EventArgs e)
        {
            MusterileriYukle();
            ParcalariYukle();
            SatisPersonelYukle();
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
