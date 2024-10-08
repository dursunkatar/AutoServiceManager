﻿using Microsoft.EntityFrameworkCore;
using OtoServis.DataAccess;
using OtoServis.DataAccess.Context;
using OtoServis.DataAccess.Entities;
using OtoServis.Dto;
using OtoServis.Helper;

namespace OtoServis
{
    public partial class FrmAracPaneli : Form
    {
        private readonly AppDbContext dbContext;
        private bool isSaving = true;
        public bool GoruntulemeYetkisiVarmi { get; set; }
        public bool DuzenlemeYetkisiVarmi { get; set; }
        public bool EklemeYetkisiVarmi { get; set; }
        public bool SilmeYetkisiVarmi { get; set; }

        public FrmAracPaneli()
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

        void InputlariTemizle()
        {
            txtYil.Clear();
            txtPlaka.Clear();
            txtRenk.Clear();
            cmbMarka.SelectedIndex = 0;
            cmbMusteri.SelectedIndex = 0;
            isSaving = true;
            cmbMusteri.Enabled = true;
            btnKaydet.Text = "Kaydet";
        }
        void AraclariYukle(int musteriId = -1)
        {
            if (!GoruntulemeYetkisiVarmi) return;

            var data = dbContext.Araclar
                .Include(x => x.Musteri)
                .Include(x => x.Marka)
                .Include(x => x.Model)
                .Where(x => (musteriId == -1 || x.MusteriID == musteriId) && !x.Silindimi)
                .OrderByDescending(x => x.AracID)
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

        void AracGuncelle()
        {

            var (ok, arac) = DataGridViewHelper.GetSelectedValue<AracDto>(dgvArac);

            if (!ok)
            {
                MessageBox.Show("Güncellenecek Kayıt Yok", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

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

            bool aracEklenmismi = dbContext.Araclar.Any(x => x.AracID != arac.Data.AracID && x.Plaka == plaka);

            if (aracEklenmismi)
            {
                MessageBox.Show("Bu palaka başka bir araçta kullanılmış", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            arac.Data.Plaka = plaka;
            arac.Data.Yil = aracYil;
            arac.Data.AracRenk = renk;
            arac.Data.MarkaID = secilenMarka.Value;
            arac.Data.ModelID = secilenModel.Value;
            arac.Data.MusteriID = secilenMusteri.Value;

            dbContext.Entry<Arac>(arac.Data).State = EntityState.Modified;
            dbContext.SaveChanges();
            MessageBox.Show("Güncelleme başarılı", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void AracEkle()
        {
            if (!EklemeYetkisiVarmi) return;

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
            InputlariTemizle();
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
            try
            {
                if (isSaving)
                {
                    AracEkle();

                }
                else
                {
                    AracGuncelle();
                }

                var secilenMusteri = cmbMusteri.SelectedItem as TextValueDto<int>;
                AraclariYukle(secilenMusteri.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvArac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!DuzenlemeYetkisiVarmi) return;

            var (ok, data) = DataGridViewHelper.GetSelectedValue<AracDto>(dgvArac);

            if (!ok) return;

            ComboBoxHelper.SelectItemByValue(cmbMusteri, data.Data.MusteriID);
            ComboBoxHelper.SelectItemByValue(cmbMarka, data.Data.MarkaID);
            ComboBoxHelper.SelectItemByValue(cmbModel, data.Data.ModelID);

            txtPlaka.Text = data.Plaka;
            txtRenk.Text = data.Renk;
            txtYil.Text = data.Yil.ToString();
            cmbMusteri.Enabled = false;
            btnKaydet.Text = "Güncelle";
            isSaving = false;
        }

        private void cmbMusteri_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextValueDto<int> selectedData = cmbMusteri.SelectedItem as TextValueDto<int>;

            if (selectedData != null)
            {
                AraclariYukle(selectedData.Value);
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            InputlariTemizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (!SilmeYetkisiVarmi) return;

            if (isSaving)
            {
                MessageBox.Show("Silmek için kayıt seçin", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var (ok, arac) = DataGridViewHelper.GetSelectedValue<AracDto>(dgvArac);

            if (!ok)
            {
                MessageBox.Show("Silmek için kayıt seçin", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bu kaydı silmek istediğinize emin misiniz ?", "OtoServis", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            arac.Data.Silindimi = true;

            dbContext.Entry<Arac>(arac.Data).State = EntityState.Modified;
            dbContext.SaveChanges();
            InputlariTemizle();
            AraclariYukle();
            MessageBox.Show("Kayıt silindi", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
