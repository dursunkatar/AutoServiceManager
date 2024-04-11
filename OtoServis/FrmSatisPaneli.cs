using Microsoft.EntityFrameworkCore;
using OtoServis.DataAccess;
using OtoServis.DataAccess.Context;
using OtoServis.DataAccess.Entities;
using OtoServis.Dto;
using OtoServis.Helper;
using System.Data;
using System.Globalization;

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

        void SatisEkle()
        {
            var secilenMusteri = cmbMusteri.SelectedItem as TextValueDto<int>;
            var secilenArac = cmbArac.SelectedItem as TextValueDto<int>;
            var secilenParca = cmbParca.SelectedItem as TextValueDto<int>;
            var secilenSatisPersonel = cmbSatisPersonel.SelectedItem as TextValueDto<int>;

            string miktarBilgisi = txtMiktar.Text.Trim();
            string tutarBilgisi = txtTutar.Text.Trim().TrimStart('₺');

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

            if (!int.TryParse(miktarBilgisi, out int miktar))
            {
                MessageBox.Show("Miktar bilgisi geçersiz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(tutarBilgisi, out decimal tutar))
            {
                MessageBox.Show("Tutar bilgisi geçersiz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var parca = dbContext.Parcalar.Where(p => p.ParcaID == secilenArac.Value).First();

            if (miktar > parca.StokAdet)
            {
                MessageBox.Show($"Girilen miktar, parçanın stok miktarından fazla!  Stok: {parca.StokAdet}", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

            parca.StokAdet -= miktar;
            dbContext.Entry<Parca>(parca).State = EntityState.Modified;
            dbContext.SaveChanges();

            InputlariTemizle();
            MessageBox.Show("Kayıt başarılı", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        void InputlariTemizle()
        {
            txtMiktar.Clear();
            txtTutar.Clear();
            cmbMusteri.SelectedIndex = 0;
            cmbArac.SelectedIndex = 0;
            cmbParca.SelectedIndex = 0;
            cmbMusteri.Enabled = true;
            cmbArac.Enabled = true;
            isSaving = true;
            btnKaydet.Text = "Kaydet";
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

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SatisEkle();
        }

        void txtToplamTutarHesapla()
        {
            var secilenParca = cmbParca.SelectedItem as TextValueDto<int>;

            if (secilenParca is null || secilenParca.Value == -1) return;

            string miktarStr = txtMiktar.Text.Trim();

            if (miktarStr == string.Empty) return;

            if (!int.TryParse(miktarStr, out int miktar))
            {
                return;
            }

            var parca = dbContext.Parcalar.First(p => p.ParcaID == secilenParca.Value);

            decimal toplamTutar = parca.Fiyat * miktar;
            string toplamTutarStr = toplamTutar.ToString("C2", CultureInfo.CreateSpecificCulture("tr-TR"));
            txtTutar.Text = toplamTutarStr;
        }
        private void txtMiktar_TextChanged(object sender, EventArgs e)
        {
            txtToplamTutarHesapla();
        }

        private void cmbParca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtToplamTutarHesapla();
        }
    }
}
