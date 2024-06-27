using Microsoft.EntityFrameworkCore;
using OtoServis.DataAccess;
using OtoServis.DataAccess.Context;

namespace OtoServis
{
    public partial class FrmMain : Form
    {
        private readonly MenuStrip menuStrip;
        public int PersonelId { get; set; } = 7;
        private readonly AppDbContext dbContext;
        public FrmMain()
        {
            InitializeComponent();
            dbContext = DbContextBuilder.Build();
            menuStrip = new MenuStrip();
            CreateDynamicMenu();
        }



        private void CreateDynamicMenu()
        {

            // Ana menü öðesini oluþtur
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("Ekranlar");

            var data = dbContext.Personeller
                 .Include(p => p.Rol)
                 .ThenInclude(p => p.RolYetkileri)
                 .Where(p => p.PersonelID == PersonelId).ToList();

            bool aracPaneliGoruntulemeYetkisiVarmi = data.Any(p => p.Rol.RolYetkileri.Any(r => r.YetkiId == 4 && r.FormId == 1));
            bool musteriPaneliGoruntulemeYetkisiVarmi = data.Any(p => p.Rol.RolYetkileri.Any(r => r.YetkiId == 4 && r.FormId == 2));
            bool parcaPaneliGoruntulemeYetkisiVarmi = data.Any(p => p.Rol.RolYetkileri.Any(r => r.YetkiId == 4 && r.FormId == 3));
            bool personelPaneliGoruntulemeYetkisiVarmi = data.Any(p => p.Rol.RolYetkileri.Any(r => r.YetkiId == 4 && r.FormId == 4));
            bool satisPaneliGoruntulemeYetkisiVarmi = data.Any(p => p.Rol.RolYetkileri.Any(r => r.YetkiId == 4 && r.FormId == 5));
            bool tamirPaneliGoruntulemeYetkisiVarmi = data.Any(p => p.Rol.RolYetkileri.Any(r => r.YetkiId == 4 && r.FormId == 6));
            bool raporPaneliGoruntulemeYetkisiVarmi = data.Any(p => p.Rol.RolYetkileri.Any(r => r.YetkiId == 4 && r.FormId == 7));
            bool yetkilendirmePaneliGoruntulemeYetkisiVarmi = data.Any(p => p.Rol.RolYetkileri.Any(r => r.YetkiId == 4 && r.FormId == 8));

            if (aracPaneliGoruntulemeYetkisiVarmi)
            {
                ToolStripMenuItem aracItem = new ToolStripMenuItem("Araç", null, AracPaneli_Click);
                fileMenu.DropDownItems.Add(aracItem);
            }
            if (musteriPaneliGoruntulemeYetkisiVarmi)
            {
                ToolStripMenuItem musteriItem = new ToolStripMenuItem("Müþteri", null, MusteriPaneli_Click);
                fileMenu.DropDownItems.Add(musteriItem);
            }
            if (parcaPaneliGoruntulemeYetkisiVarmi)
            {
                ToolStripMenuItem parcaItem = new ToolStripMenuItem("Parça", null, ParcaPaneli_Click);
                fileMenu.DropDownItems.Add(parcaItem);
            }
            if (personelPaneliGoruntulemeYetkisiVarmi)
            {
                ToolStripMenuItem personelItem = new ToolStripMenuItem("Personel", null, PersonelPaneli_Click);
                fileMenu.DropDownItems.Add(personelItem);
            }

            if (satisPaneliGoruntulemeYetkisiVarmi)
            {
                ToolStripMenuItem satisItem = new ToolStripMenuItem("Satýþ", null, SatisPaneli_Click);
                fileMenu.DropDownItems.Add(satisItem);
            }

            if (tamirPaneliGoruntulemeYetkisiVarmi)
            {
                ToolStripMenuItem tamirItem = new ToolStripMenuItem("Tamir", null, TamirPaneli_Click);
                fileMenu.DropDownItems.Add(tamirItem);
            }

            if (yetkilendirmePaneliGoruntulemeYetkisiVarmi)
            {
                ToolStripMenuItem yetkilendirmeItem = new ToolStripMenuItem("Yetkilendirme", null, YetkilendirmePaneli_Click);
                fileMenu.DropDownItems.Add(yetkilendirmeItem);
            }

            if (raporPaneliGoruntulemeYetkisiVarmi)
            {
                ToolStripMenuItem raporItem = new ToolStripMenuItem("Rapor", null, RaporPaneli_Click);
                fileMenu.DropDownItems.Add(raporItem);
            }



            menuStrip.Items.Add(fileMenu);

            this.Controls.Add(menuStrip);
            this.MainMenuStrip = menuStrip;
        }

        private void AracPaneli_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yeni öðe oluþturuldu.");
        }

        private void RaporPaneli_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yeni öðe oluþturuldu.");
        }

        private void YetkilendirmePaneli_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yeni öðe oluþturuldu.");
        }

        private void TamirPaneli_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yeni öðe oluþturuldu.");
        }

        private void PersonelPaneli_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yeni öðe oluþturuldu.");
        }

        private void SatisPaneli_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yeni öðe oluþturuldu.");
        }

        private void MusteriPaneli_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Öðe açýldý.");
        }

        private void ParcaPaneli_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Öðe kaydedildi.");
        }

        private void pictureBoxMusteriPaneli_Click(object sender, EventArgs e)
        {
            var form = new FrmMusteriPaneli();
            form.Show();
        }

        private void pictureBoxTamirPaneli_Click(object sender, EventArgs e)
        {
            var form = new FrmTamirPaneli();
            form.Show();
        }

        private void pictureBoxParcaPaneli_Click(object sender, EventArgs e)
        {
            var form = new FrmParcaPaneli();
            form.Show();
        }

        private void pictureBoxSatisPaneli_Click(object sender, EventArgs e)
        {
            var form = new FrmSatisPaneli();
            form.Show();
        }

        private void pictureBoxPersonelPaneli_Click(object sender, EventArgs e)
        {
            var form = new FrmPersonelPaneli();
            form.Show();
        }

        private void pictureBoxAracPaneli_Click(object sender, EventArgs e)
        {
            var form = new FrmAracPaneli();
            form.Show();
        }

        private void pictureBoxRapor_Click(object sender, EventArgs e)
        {
            var form = new FrmRapor();
            form.Show();
        }
    }
}
