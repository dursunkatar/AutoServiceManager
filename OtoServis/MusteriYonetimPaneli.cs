using Microsoft.EntityFrameworkCore;
using OtoServis.DataAccess;
using OtoServis.DataAccess.Context;
using OtoServis.DataAccess.Entities;
using OtoServis.Dto;
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

namespace OtoServis
{
    public partial class MusteriYonetimPaneli : Form
    {
        private readonly AppDbContext dbContext;
        private bool isSaving = true;
        public MusteriYonetimPaneli()
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
        }
        void MusteriGuncelle()
        {

        }

        void MusterileriYukle()
        {
            var musteriler = dbContext.Musteriler
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

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            MusteriEkle();
        }

        private void MusteriYonetimPaneli_Load(object sender, EventArgs e)
        {
            MusterileriYukle();
        }
    }
}
