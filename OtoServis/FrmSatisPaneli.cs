﻿using Microsoft.EntityFrameworkCore;
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
        public bool GoruntulemeYetkisiVarmi { get; set; }
        public bool DuzenlemeYetkisiVarmi { get; set; }
        public bool EklemeYetkisiVarmi { get; set; }
        public bool SilmeYetkisiVarmi { get; set; }
        public FrmSatisPaneli()
        {
            InitializeComponent();
            dbContext = DbContextBuilder.Build();
        }

        void SatislariYukle(int musteriId = -1)
        {
            if (!GoruntulemeYetkisiVarmi) return;

            var data = dbContext.Satislar
                .Include(x => x.Musteri)
                .Include(x => x.SatisPersonel)
                .Include(x => x.Arac)
                .ThenInclude(x => x.Model)
                .Include(x => x.Arac)
                .ThenInclude(x => x.Marka)
                .Where(x => (musteriId == -1 || x.MusteriID == musteriId) && !x.Silindimi)
                .Select(x => new SatisDto
                {
                    Musteri = $"{x.Musteri.Ad} {x.Musteri.Soyad}",
                    Arac = $"{x.Arac.Plaka} - ({x.Arac.Marka.MarkaAdi}  {x.Arac.Model.ModelAdi})",
                    Miktar = x.Miktar,
                    SatisPersonel = $"{x.SatisPersonel.Ad} {x.SatisPersonel.Soyad}",
                    Parca = x.Parca.ParcaAdi,
                    Tarih = x.Tarih,
                    ToplamTutar = x.ToplamTutar,
                    Data = x
                }).ToList();

            DataGridViewHelper.LoadData<SatisDto>(dgvSatis, data);
        }

        void SatisGuncelle()
        {
            if (!DuzenlemeYetkisiVarmi) return;

            var (ok, satis) = DataGridViewHelper.GetSelectedValue<SatisDto>(dgvSatis);

            if (!ok)
            {
                MessageBox.Show("Güncellenecek Kayıt Yok", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

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

            if (miktar <= 0)
            {
                MessageBox.Show("Miktar en az 1 olabilir", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(tutarBilgisi, out decimal tutar))
            {
                MessageBox.Show("Tutar bilgisi geçersiz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var parca = dbContext.Parcalar.Where(p => p.ParcaID == secilenParca.Value).First();


            if (secilenParca.Value == satis.Data.ParcaID)
            {
                if (miktar > satis.Data.Miktar)
                {
                    int artanMiktar = miktar - satis.Data.Miktar;

                    if (artanMiktar > parca.StokAdet)
                    {
                        MessageBox.Show($"Girilen miktar, parçanın stok miktarından fazla!  Stok: {parca.StokAdet}", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    parca.StokAdet -= artanMiktar;
                }
                else if (miktar < satis.Data.Miktar)
                {
                    int eksilenMiktar = satis.Data.Miktar - miktar;
                    parca.StokAdet += eksilenMiktar;
                }
            }
            else
            {
                if (miktar > parca.StokAdet)
                {
                    MessageBox.Show($"Girilen miktar, parçanın stok miktarından fazla!  Stok: {parca.StokAdet}", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                satis.Data.Parca.StokAdet += satis.Data.Miktar;
                parca.StokAdet -= miktar;
                dbContext.Entry<Parca>(satis.Data.Parca).State = EntityState.Modified;

            }

            dbContext.Entry<Parca>(parca).State = EntityState.Modified;

            satis.Data.AracId = secilenArac.Value;
            satis.Data.Miktar = miktar;
            satis.Data.MusteriID = secilenMusteri.Value;
            satis.Data.ParcaID = secilenParca.Value;
            satis.Data.SatisPersonelID = secilenSatisPersonel.Value;
            satis.Data.Tarih = dtpSatisTarihi.Value;
            satis.Data.ToplamTutar = tutar;
            dbContext.Entry<Satis>(satis.Data).State = EntityState.Modified;
            dbContext.SaveChanges();
            SatislariYukle();
            MessageBox.Show("Güncelleme başarılı", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        void SatisEkle()
        {
            if (!EklemeYetkisiVarmi) return;

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

            if (miktar <= 0)
            {
                MessageBox.Show("Miktar en az 1 olabilir", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                AracId = secilenArac.Value,
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
            SatislariYukle();
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
            SatislariYukle();
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
                    SatisEkle();
                }
                else
                {
                    SatisGuncelle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void dgvSatis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!DuzenlemeYetkisiVarmi) return;

            var (ok, satis) = DataGridViewHelper.GetSelectedValue<SatisDto>(dgvSatis);

            if (!ok) return;

            ComboBoxHelper.SelectItemByValue(cmbMusteri, satis.Data.MusteriID);
            ComboBoxHelper.SelectItemByValue(cmbArac, satis.Data.AracId);
            ComboBoxHelper.SelectItemByValue(cmbSatisPersonel, satis.Data.SatisPersonelID);
            ComboBoxHelper.SelectItemByValue(cmbParca, satis.Data.ParcaID);

            dtpSatisTarihi.Value = satis.Tarih;
            txtMiktar.Text = satis.Miktar.ToString();

            string toplamTutarStr = satis.ToplamTutar.ToString("C2", CultureInfo.CreateSpecificCulture("tr-TR"));
            txtTutar.Text = toplamTutarStr;
            btnKaydet.Text = "Güncelle";
            isSaving = false;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            if (!SilmeYetkisiVarmi) return;

            if (isSaving)
            {
                MessageBox.Show("Silmek için kayıt seçin", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var (ok, satis) = DataGridViewHelper.GetSelectedValue<SatisDto>(dgvSatis);

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

            satis.Data.Silindimi = true;

            dbContext.Entry<Satis>(satis.Data).State = EntityState.Modified;
            dbContext.SaveChanges();
            InputlariTemizle();
            SatislariYukle();
            MessageBox.Show("Kayıt silindi", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
