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
        public FrmPersonelYonetim()
        {
            InitializeComponent();

            dbContext = DbContextBuilder.Build();
        }

        void RolleriYukle()
        {
            var roller = dbContext.Roller.ToList();
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

            DataGridViewHelper.InitializeColumns<PersonelDto>(dgvPersonel);
            dgvPersonel.DataSource = personeller;
        }

        void LoadData()
        {
            RolleriYukle();
            PersonelleriYukle();
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
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                PersonelEkle();
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


            cmbPersonelAktifPasif.Items.Add(new { Text = "Aktif", Value = true });
            cmbPersonelAktifPasif.Items.Add(new { Text = "Pasif", Value = false });

            cmbPersonelAktifPasif.DisplayMember = "Text";
            cmbPersonelAktifPasif.ValueMember = "Value";
        }

        private void dgvPersonel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var currentRow = dgvPersonel.CurrentRow;

            if (currentRow == null) return;
            var selectedItem = currentRow.DataBoundItem as PersonelDto;

            if (selectedItem == null) return;

            txtAd.Text = selectedItem.Ad;
            txtSoyad.Text = selectedItem.Soyad;
            txtEmail.Text = selectedItem.Email;
            txtSifre.Text = selectedItem.Data.Sifre;
            cmbRol.SelectedItem = selectedItem.Data.Rol;
        }
    }
}
