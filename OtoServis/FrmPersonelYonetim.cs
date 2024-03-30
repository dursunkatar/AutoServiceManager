using Microsoft.EntityFrameworkCore;
using OtoServis.DataAccess;
using OtoServis.DataAccess.Context;
using OtoServis.DataAccess.Entities;
using OtoServis.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Xml.Linq;
using OtoServis.Dto;

namespace OtoServis
{
    public partial class FrmPersonelYonetim : Form
    {
        private readonly AppDbContext dbContext;
        private bool isSaving = true;

        public FrmPersonelYonetim()
        {
            InitializeComponent();

            dbContext = DbContextBuilder.Build();
        }

        void RolleriYukle()
        {
            var roller = dbContext.Roller.ToList();
            roller.Insert(0, new Rol
            {
                RolAdi = "Seçiniz",
                RolID = -1
            });

            ComboBoxHelper.LoadData(cmbRol, roller, "RolAdi", "RolID");
        }

        void PersonelleriYukle()
        {
            var personeller = dbContext.Personeller
                .Include(p => p.Rol)
                .Select(p => new PersonelDto
                {

                    Ad = p.Ad,
                    Soyad = p.Soyad,
                    Email = p.Email,
                    Durum = p.Aktifmi ? "Aktif" : "Pasif",
                    Rol = p.Rol.RolAdi,
                    Data = p
                }).ToList();

            DataGridViewHelper.LoadData<PersonelDto>(dgvPersonel, personeller);
        }

        void PersonelAktifPasifDurumlariYukle()
        {
            cmbPersonelAktifPasif.Items.Add(new TextValueDto<bool?> { Text = "Seçiniz", Value = null });
            cmbPersonelAktifPasif.Items.Add(new TextValueDto<bool?> { Text = "Aktif", Value = true });
            cmbPersonelAktifPasif.Items.Add(new TextValueDto<bool?> { Text = "Pasif", Value = false });
            cmbPersonelAktifPasif.DisplayMember = "Text";
            cmbPersonelAktifPasif.ValueMember = "Value";
            cmbPersonelAktifPasif.SelectedIndex = 0;
        }
        void LoadData()
        {
            RolleriYukle();
            PersonelleriYukle();
            PersonelAktifPasifDurumlariYukle();
        }

        void PersonelEkle()
        {
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            string email = txtEmail.Text;
            string sifre = txtSifre.Text;
            var rol = cmbRol.SelectedItem as Rol;

            bool emailKayitlimi = dbContext.Personeller.Any(p => p.Email == email);

            if (emailKayitlimi)
            {
                MessageBox.Show("Bu email kullanımda", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            dbContext.Personeller.Add(new Personel
            {
                Ad = ad,
                Soyad = soyad,
                Email = email,
                Sifre = sifre,
                RolID = rol.RolID
            });

            dbContext.SaveChanges();
            inputlariTemizle();
            PersonelleriYukle();
            MessageBox.Show("Kaydedildi", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void PersonelGuncelle()
        {
            var (ok, personel) = DataGridViewHelper.GetSelectedValue<PersonelDto>(dgvPersonel);

            if (!ok)
            {
                MessageBox.Show("Güncellenecek Kayıt Yok", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            string email = txtEmail.Text;
            string sifre = txtSifre.Text;
            var rol = cmbRol.SelectedItem as Rol;
            var aktifPasifDurum = cmbPersonelAktifPasif.SelectedItem as TextValueDto<bool?>;

            bool emailKayitlimi = dbContext.Personeller.Any(p => personel.Data.PersonelID != p.PersonelID && p.Email == email);

            if (emailKayitlimi)
            {
                MessageBox.Show("Bu email kullanımda", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            personel.Data.Ad = ad;
            personel.Data.Soyad = soyad;
            personel.Data.Email = email;
            personel.Data.RolID = rol.RolID;
            personel.Data.Aktifmi = aktifPasifDurum.Value.Value;

            dbContext.Entry<Personel>(personel.Data).State = EntityState.Modified;

            dbContext.SaveChanges();

            isSaving = true;
            inputlariTemizle();
            PersonelleriYukle();
            MessageBox.Show("Kaydedildi", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void inputlariTemizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtEmail.Clear();
            txtSifre.Clear();
            cmbRol.SelectedIndex = 0;
            cmbPersonelAktifPasif.SelectedIndex = 0;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbRol.SelectedIndex == 0)
                {
                    MessageBox.Show("Rol Seçiniz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (cmbPersonelAktifPasif.SelectedIndex == 0)
                {
                    MessageBox.Show("Personel Durum Seçiniz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (isSaving) PersonelEkle(); else PersonelGuncelle();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmPersonelYonetim_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbContext.Dispose();
        }

        private void FrmPersonelYonetim_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvPersonel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var (ok, personel) = DataGridViewHelper.GetSelectedValue<PersonelDto>(dgvPersonel);

            if (!ok) return;

            txtAd.Text = personel.Ad;
            txtSoyad.Text = personel.Soyad;
            txtEmail.Text = personel.Email;
            txtSifre.Text = personel.Data.Sifre;
            cmbRol.SelectedItem = personel.Data.Rol;
            ComboBoxHelper.SelectItemByValue<bool?>(cmbPersonelAktifPasif, personel.Data.Aktifmi);
            isSaving = false;
        }
    }
}
