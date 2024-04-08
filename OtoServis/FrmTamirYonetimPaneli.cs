using Microsoft.EntityFrameworkCore;
using OtoServis.DataAccess;
using OtoServis.DataAccess.Context;
using OtoServis.DataAccess.Entities;
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

        void TamirDurumlariYukle()
        {
            var data = dbContext.TamirDurum.Select(x => new TextValueDto<int>
            {
                Text = x.Durum,
                Value = x.Id
            }).ToList();

            data.Insert(0, new TextValueDto<int>
            {
                Text = "Seçiniz",
                Value = -1
            });

            ComboBoxHelper.LoadData(cmbDurum, data, "Text", "Value");
        }

        void UstalariYukle()
        {
            const int MEKANIK_USTA = 3;
            var data = dbContext.Personeller
                .Where(x => x.RolID == MEKANIK_USTA)
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

            ComboBoxHelper.LoadData(cmbUsta, data, "Text", "Value");
        }

        void TamirKayitlariniYukle(int musteriId = -1)
        {
            var data = dbContext.Tamirler
                .Include(x => x.Arac)
                .ThenInclude(x => x.Musteri)
                .Include(x => x.Arac)
                .ThenInclude(x => x.Model)
                .Include(x => x.Arac)
                .ThenInclude(x => x.Marka)
                .Include(x => x.TamirDurum)
                .Include(x => x.MekanikUsta)
                .Where(x => (musteriId == -1 || x.Arac.MusteriID == musteriId) && !x.Silindimi)
                .Select(x => new TamirDto
                {
                    Aciklama = x.Aciklama,
                    Arac = $"{x.Arac.Plaka} - ({x.Arac.Marka.MarkaAdi}  {x.Arac.Model.ModelAdi})",
                    Musteri = $"{x.Arac.Musteri.Ad} {x.Arac.Musteri.Soyad} - ({x.Arac.Musteri.Telefon})",
                    Durum = x.TamirDurum.Durum,
                    TamirTarihi = x.TamirTarihi,
                    Usta = $"{x.MekanikUsta.Ad} {x.MekanikUsta.Soyad}",
                    Data = x
                }).ToList();

            DataGridViewHelper.LoadData<TamirDto>(dgvTamir, data);
        }
        void TamirEkle()
        {
            string aciklama = txtAciklama.Text.Trim();
            var secilenMusteri = cmbMusteri.SelectedItem as TextValueDto<int>;
            var secilenArac = cmbArac.SelectedItem as TextValueDto<int>;
            var secilenDurum = cmbDurum.SelectedItem as TextValueDto<int>;
            var secilenUsta = cmbUsta.SelectedItem as TextValueDto<int>;

            if (secilenMusteri.Value == -1)
            {
                MessageBox.Show("Müşteri seçiniz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (secilenArac.Value == -1)
            {
                MessageBox.Show("Araç seçiniz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (secilenDurum.Value == -1)
            {
                MessageBox.Show("Durum seçiniz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (secilenUsta.Value == -1)
            {
                MessageBox.Show("Usta seçiniz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            dbContext.Tamirler.Add(new Tamir
            {
                AracID = secilenArac.Value,
                Aciklama = aciklama,
                TamirDurumId = secilenDurum.Value,
                MekanikUstaID = secilenUsta.Value,
                TamirTarihi = dtpTamirTarihi.Value,
                Silindimi = false
            });

            dbContext.SaveChanges();
            InputlariTemizle();
            MessageBox.Show("Kayıt başarılı", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void TamirGuncelle()
        {
            var (ok, tamir) = DataGridViewHelper.GetSelectedValue<TamirDto>(dgvTamir);

            if (!ok)
            {
                MessageBox.Show("Güncellenecek Kayıt Yok", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string aciklama = txtAciklama.Text.Trim();
            var secilenMusteri = cmbMusteri.SelectedItem as TextValueDto<int>;
            var secilenArac = cmbArac.SelectedItem as TextValueDto<int>;
            var secilenDurum = cmbDurum.SelectedItem as TextValueDto<int>;
            var secilenUsta = cmbUsta.SelectedItem as TextValueDto<int>;

            if (secilenMusteri.Value == -1)
            {
                MessageBox.Show("Müşteri seçiniz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (secilenArac.Value == -1)
            {
                MessageBox.Show("Araç seçiniz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (secilenDurum.Value == -1)
            {
                MessageBox.Show("Durum seçiniz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (secilenUsta.Value == -1)
            {
                MessageBox.Show("Usta seçiniz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            tamir.Data.AracID = secilenArac.Value;
            tamir.Data.Aciklama = aciklama;
            tamir.Data.TamirDurumId = secilenDurum.Value;
            tamir.Data.MekanikUstaID = secilenUsta.Value;
            tamir.Data.TamirTarihi = dtpTamirTarihi.Value;

            dbContext.Entry<Tamir>(tamir.Data).State = EntityState.Modified;
            dbContext.SaveChanges();
            MessageBox.Show("Güncelleme başarılı", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        void InputlariTemizle()
        {
            txtAciklama.Clear();
            cmbMusteri.SelectedIndex = 0;
            cmbDurum.SelectedIndex = 0;
            cmbUsta.SelectedIndex = 0;
            cmbMusteri.Enabled = true;
            cmbArac.Enabled = true;
            isSaving = true;
            btnKaydet.Text = "Kaydet";
            TamirKayitlariniYukle();
        }
        private void FrmTamirYonetimPaneli_Load(object sender, EventArgs e)
        {
            MusterileriYukle();
            TamirDurumlariYukle();
            UstalariYukle();
            TamirKayitlariniYukle();
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
            try
            {
                if (isSaving)
                {
                    TamirEkle();
                }
                else
                {
                    TamirGuncelle();
                }

                var secilenMusteri = cmbMusteri.SelectedItem as TextValueDto<int>;
                TamirKayitlariniYukle(secilenMusteri.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTamir_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var (ok, tamir) = DataGridViewHelper.GetSelectedValue<TamirDto>(dgvTamir);

            if (!ok) return;

            ComboBoxHelper.SelectItemByValue(cmbMusteri, tamir.Data.Arac.MusteriID);
            ComboBoxHelper.SelectItemByValue(cmbArac, tamir.Data.AracID);
            ComboBoxHelper.SelectItemByValue(cmbDurum, tamir.Data.TamirDurumId);
            ComboBoxHelper.SelectItemByValue(cmbUsta, tamir.Data.MekanikUstaID);
            cmbMusteri.Enabled = false;
            cmbArac.Enabled = false;
            dtpTamirTarihi.Value = tamir.TamirTarihi;
            txtAciklama.Text = tamir.Aciklama;
            btnKaydet.Text = "Güncelle";
            isSaving = false;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            InputlariTemizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (isSaving)
            {
                MessageBox.Show("Silmek için kayıt seçin", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var (ok, tamir) = DataGridViewHelper.GetSelectedValue<TamirDto>(dgvTamir);

            if (!ok)
            {
                MessageBox.Show("Silmek için kayıt seçin", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            tamir.Data.Silindimi = true;

            dbContext.Entry<Tamir>(tamir.Data).State = EntityState.Modified;
            dbContext.SaveChanges();
            InputlariTemizle();
            MessageBox.Show("Kayıt silindi", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
