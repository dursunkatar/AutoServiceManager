using Microsoft.EntityFrameworkCore;
using OtoServis.DataAccess;
using OtoServis.DataAccess.Context;
using OtoServis.DataAccess.Entities;
using OtoServis.Dto;
using OtoServis.Helper;

namespace OtoServis
{
    public partial class FrmAracYonetimPaneli : Form
    {
        private readonly AppDbContext dbContext;
        private bool isSaving = true;
        public FrmAracYonetimPaneli()
        {
            InitializeComponent();
            dbContext = DbContextBuilder.Build();
        }


        void MusterileriYukle()
        {
            var data = dbContext.Musteriler.Select(x => new TextValueDto<int>
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
        void AraclariYukle()
        {
            var data = dbContext.Araclar
                .Include(x => x.Musteri)
                .Include(x => x.Marka)
                .Include(x => x.Model)
                .Select(x => new AracDto
                {
                    Musteri = $"{x.Musteri.Ad} {x.Musteri.Soyad} - ({x.Musteri.Telefon})",
                    Marka = x.Marka.MarkaAdi,
                    Model = x.Model.ModelAdi,
                    Plaka = x.Plaka,
                    Renk = x.AracRenk,
                    Yil = x.Yil,
                    Data = x
                }).ToList();
            DataGridViewHelper.LoadData<AracDto>(dgvArac, data);
        }


        void AracEkle()
        {
            string plaka = txtPlaka.Text.Trim();
            string renk = txtRenk.Text.Trim();
            string yil = txtYil.Text.Trim();
            var secilenMusteri = cmbMusteri.SelectedItem as TextValueDto<int>;
            var secilenMarka = cmbMarka.SelectedItem as TextValueDto<int>;
            var secilenModel = cmbModel.SelectedItem as TextValueDto<int>;


            if (secilenMusteri.Value == -1)
            {
                MessageBox.Show("Müşteri seçiniz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (secilenMarka.Value == -1)
            {
                MessageBox.Show("Marka seçiniz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (secilenModel.Value == -1)
            {
                MessageBox.Show("Model seçiniz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (plaka == string.Empty || renk == string.Empty || yil == string.Empty)
            {
                MessageBox.Show("Tüm alanları doldurunuz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!int.TryParse(yil, out int aracYil))
            {
                MessageBox.Show("Yıl bilgisi geçersiz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            bool aracEklenmismi = dbContext.Araclar.Any(x => x.Plaka == plaka);

            if (aracEklenmismi)
            {
                MessageBox.Show("Bu palaka daha önce eklenmiş", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            dbContext.Araclar.Add(new Arac
            {
                Plaka = plaka,
                Yil = aracYil,
                AracRenk = renk,
                MarkaID = secilenMarka.Value,
                ModelID = secilenModel.Value,
                MusteriID = secilenMusteri.Value
            });

            dbContext.SaveChanges();

            MessageBox.Show("Kayıt başarılı", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void MarkalariYukle()
        {
            var data = dbContext.Markalar.Select(x => new TextValueDto<int>
            {
                Text = x.MarkaAdi,
                Value = x.MarkaID
            }).ToList();


            data.Insert(0, new TextValueDto<int>
            {
                Text = "Seçiniz",
                Value = -1
            });

            ComboBoxHelper.LoadData(cmbMarka, data, "Text", "Value");
        }

        void ModelleriYukle(int markaId)
        {
            var data = dbContext.Modeller
                .Where(x => x.MarkaID == markaId)
                .Select(x => new TextValueDto<int>
                {
                    Text = x.ModelAdi,
                    Value = x.ModelID
                }).ToList();

            data.Insert(0, new TextValueDto<int>
            {
                Text = "Seçiniz",
                Value = -1
            });

            ComboBoxHelper.LoadData(cmbModel, data, "Text", "Value");
        }

        private void FrmAracYonetimPaneli_Load(object sender, EventArgs e)
        {
            MusterileriYukle();
            MarkalariYukle();
            AraclariYukle();
        }

        private void cmbMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextValueDto<int> selectedData = cmbMarka.SelectedItem as TextValueDto<int>;

            if (selectedData != null)
            {
                ModelleriYukle(selectedData.Value);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            AracEkle();
        }
    }
}
