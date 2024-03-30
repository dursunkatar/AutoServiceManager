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

        void LoadData()
        {
            var roller = dbContext.Roller.ToList();
            ComboBoxHelper.LoadData(cmbRol, roller, "RolAdi", "RolID");
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            string email = txtEmail.Text;
            string sifre = txtSifre.Text;
            var rol = cmbRol.SelectedItem as Rol;

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

        private void FrmPersonelYonetim_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbContext.Dispose();
        }

        private void FrmPersonelYonetim_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
