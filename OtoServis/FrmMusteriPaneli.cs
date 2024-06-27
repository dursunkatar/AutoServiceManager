using Microsoft.EntityFrameworkCore;
using OtoServis.DataAccess;
using OtoServis.DataAccess.Context;
using OtoServis.DataAccess.Entities;
using OtoServis.Dto;
using OtoServis.Helper;
using System.Data;

namespace OtoServis
{
    public partial class FrmMusteriPaneli : Form
    {
        private readonly AppDbContext dbContext;
        private bool isSaving = true;
        public bool GoruntulemeYetkisiVarmi { get; set; }
        public bool DuzenlemeYetkisiVarmi { get; set; }
        public bool EklemeYetkisiVarmi { get; set; }
        public bool SilmeYetkisiVarmi { get; set; }
        public FrmMusteriPaneli()
        {
            InitializeComponent();
            dbContext = DbContextBuilder.Build();
        }

        private void MusteriYonetimPaneli_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbContext.Dispose();
        }

        void MusteriEkle()
        {
            if (!EklemeYetkisiVarmi) return;

            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            string email = txtEmail.Text;
            string telefon = txtTelefon.Text;

            if (dbContext.Musteriler.Any(p => p.Telefon == telefon || p.Email == email))
            {
                MessageBox.Show("Bu müşteri daha önce kaydedilmiş", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            dbContext.Musteriler.Add(new Musteri
            {
                Ad = ad,
                Email = email,
                Telefon = telefon,
                Soyad = soyad,
                Silindimi = false,
                KayitTarihi = DateTime.Now
            });
            dbContext.SaveChanges();
            InputlariTemizle();
            MusterileriYukle();
            MessageBox.Show("Kaydedildi", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void MusterileriYukle()
        {
            if (!GoruntulemeYetkisiVarmi) return;
            var musteriler = dbContext.Musteriler
                .Where(p => !p.Silindimi)
               .Select(p => new MusteriDto
               {
                   Ad = p.Ad,
                   Soyad = p.Soyad,
                   Email = p.Email,
                   Telefon = p.Telefon,
                   KayitTarihi = p.KayitTarihi,
                   Data = p
               }).ToList();

            DataGridViewHelper.LoadData<MusteriDto>(dgvMusteri, musteriler);
        }

        void MusteriGuncelle()
        {
            if (!DuzenlemeYetkisiVarmi) return;

            var (ok, musteri) = DataGridViewHelper.GetSelectedValue<MusteriDto>(dgvMusteri);

            if (!ok)
            {
                MessageBox.Show("Güncellenecek Kayıt Yok", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            string email = txtEmail.Text;
            string telefon = txtTelefon.Text;

            if (dbContext.Musteriler.Any(p => musteri.Data.MusteriID != p.MusteriID && (p.Telefon == telefon || p.Email == email)))
            {
                MessageBox.Show("Bu bilgiler başka bir müşteride kullanılıyor", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            musteri.Data.Ad = ad;
            musteri.Data.Soyad = soyad;
            musteri.Data.Email = email;
            musteri.Data.Telefon = telefon;

            dbContext.Entry<Musteri>(musteri.Data).State = EntityState.Modified;

            dbContext.SaveChanges();

            isSaving = true;
            InputlariTemizle();
            MusterileriYukle();

            MessageBox.Show("Kaydedildi", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void MusteriSil()
        {
            if (!SilmeYetkisiVarmi) return;
            var (ok, musteri) = DataGridViewHelper.GetSelectedValue<MusteriDto>(dgvMusteri);

            if (!ok) return;

            musteri.Data.Silindimi = true;
            dbContext.Entry<Musteri>(musteri.Data).State = EntityState.Modified;
            dbContext.SaveChanges();
            isSaving = true;
            InputlariTemizle();
            MusterileriYukle();

            MessageBox.Show("Müşteri Silindi", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void InputlariTemizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtEmail.Clear();
            txtTelefon.Clear();
            isSaving = true;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {

                if (isSaving) MusteriEkle(); else MusteriGuncelle();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MusteriYonetimPaneli_Load(object sender, EventArgs e)
        {
            MusterileriYukle();
        }

        private void dgvMusteri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!DuzenlemeYetkisiVarmi) return;

            var (ok, musteri) = DataGridViewHelper.GetSelectedValue<MusteriDto>(dgvMusteri);

            if (!ok) return;

            txtAd.Text = musteri.Ad;
            txtSoyad.Text = musteri.Soyad;
            txtEmail.Text = musteri.Email;
            txtTelefon.Text = musteri.Telefon;
            isSaving = false;
        }

        private void toolStripMenuMusteriSil_Click(object sender, EventArgs e)
        {
            MusteriSil();
        }
    }
}
