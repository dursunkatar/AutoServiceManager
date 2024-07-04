using Microsoft.EntityFrameworkCore;
using OtoServis.DataAccess;
using OtoServis.DataAccess.Context;
using OtoServis.DataAccess.Entities;

namespace OtoServis
{
    public partial class FrmMain : Form
    {
        private MenuStrip menuStrip;
        public int PersonelId { get; set; } 
        private AppDbContext dbContext;
        private Personel personel;
        public FrmMain()
        {
            InitializeComponent();
        }



        private void CreateDynamicMenu()
        {
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("Ekranlar");


            bool aracPaneliGoruntulemeYetkisiVarmi = personel.Rol.RolYetkileri.Any(r => r.FormId == 1);
            bool musteriPaneliGoruntulemeYetkisiVarmi = personel.Rol.RolYetkileri.Any(r => r.FormId == 2);
            bool parcaPaneliGoruntulemeYetkisiVarmi = personel.Rol.RolYetkileri.Any(r => r.FormId == 3);
            bool personelPaneliGoruntulemeYetkisiVarmi = personel.Rol.RolYetkileri.Any(r => r.FormId == 4);
            bool satisPaneliGoruntulemeYetkisiVarmi = personel.Rol.RolYetkileri.Any(r => r.FormId == 5);
            bool tamirPaneliGoruntulemeYetkisiVarmi = personel.Rol.RolYetkileri.Any(r => r.FormId == 6);

            if (aracPaneliGoruntulemeYetkisiVarmi || personel.RolID == 1)
            {
                ToolStripMenuItem aracItem = new ToolStripMenuItem("Araç", null, AracPaneli_Click);
                fileMenu.DropDownItems.Add(aracItem);
            }
            if (musteriPaneliGoruntulemeYetkisiVarmi || personel.RolID == 1)
            {
                ToolStripMenuItem musteriItem = new ToolStripMenuItem("Müþteri", null, MusteriPaneli_Click);
                fileMenu.DropDownItems.Add(musteriItem);
            }
            if (parcaPaneliGoruntulemeYetkisiVarmi || personel.RolID == 1)
            {
                ToolStripMenuItem parcaItem = new ToolStripMenuItem("Parça", null, ParcaPaneli_Click);
                fileMenu.DropDownItems.Add(parcaItem);
            }
            if (personelPaneliGoruntulemeYetkisiVarmi || personel.RolID == 1)
            {
                ToolStripMenuItem personelItem = new ToolStripMenuItem("Personel", null, PersonelPaneli_Click);
                fileMenu.DropDownItems.Add(personelItem);
            }

            if (satisPaneliGoruntulemeYetkisiVarmi || personel.RolID == 1)
            {
                ToolStripMenuItem satisItem = new ToolStripMenuItem("Satýþ", null, SatisPaneli_Click);
                fileMenu.DropDownItems.Add(satisItem);
            }

            if (tamirPaneliGoruntulemeYetkisiVarmi || personel.RolID == 1)
            {
                ToolStripMenuItem tamirItem = new ToolStripMenuItem("Tamir", null, TamirPaneli_Click);
                fileMenu.DropDownItems.Add(tamirItem);
            }

            if (personel.RolID == 1)
            {
                ToolStripMenuItem yetkilendirmeItem = new ToolStripMenuItem("Yetkilendirme", null, YetkilendirmePaneli_Click);
                fileMenu.DropDownItems.Add(yetkilendirmeItem);

                ToolStripMenuItem raporItem = new ToolStripMenuItem("Rapor", null, RaporPaneli_Click);
                fileMenu.DropDownItems.Add(raporItem);
            }

            menuStrip.Items.Add(fileMenu);

            this.Controls.Add(menuStrip);
            this.MainMenuStrip = menuStrip;
        }

        private void AracPaneli_Click(object sender, EventArgs e)
        {
            var form = new FrmAracPaneli
            {
                GoruntulemeYetkisiVarmi = personel.RolID == 1 || personel.Rol.RolYetkileri.Any(p => p.FormId == 1 && p.YetkiId == 4),
                EklemeYetkisiVarmi = personel.RolID == 1 || personel.Rol.RolYetkileri.Any(p => p.FormId == 1 && p.YetkiId == 1),
                DuzenlemeYetkisiVarmi = personel.RolID == 1 || personel.Rol.RolYetkileri.Any(p => p.FormId == 1 && p.YetkiId == 2),
                SilmeYetkisiVarmi = personel.RolID == 1 || personel.Rol.RolYetkileri.Any(p => p.FormId == 1 && p.YetkiId == 3),
            };
            form.Show();
        }

        private void RaporPaneli_Click(object sender, EventArgs e)
        {
            var form = new FrmRapor();
            form.Show();
        }

        private void YetkilendirmePaneli_Click(object sender, EventArgs e)
        {
            var form = new FrmYetkilendirme();
            form.Show();
        }

        private void TamirPaneli_Click(object sender, EventArgs e)
        {
            var form = new FrmTamirPaneli
            {
                GoruntulemeYetkisiVarmi = personel.RolID == 1 || personel.Rol.RolYetkileri.Any(p => p.FormId == 6 && p.YetkiId == 4),
                EklemeYetkisiVarmi = personel.RolID == 1 || personel.Rol.RolYetkileri.Any(p => p.FormId == 6 && p.YetkiId == 1),
                DuzenlemeYetkisiVarmi = personel.RolID == 1 || personel.Rol.RolYetkileri.Any(p => p.FormId == 6 && p.YetkiId == 2),
                SilmeYetkisiVarmi = personel.RolID == 1 || personel.Rol.RolYetkileri.Any(p => p.FormId == 6 && p.YetkiId == 3),
            };
            form.Show();
        }

        private void PersonelPaneli_Click(object sender, EventArgs e)
        {
            var form = new FrmPersonelPaneli
            {
                GoruntulemeYetkisiVarmi = personel.RolID == 1 || personel.Rol.RolYetkileri.Any(p => p.FormId == 2 && p.YetkiId == 4),
                EklemeYetkisiVarmi = personel.RolID == 1 || personel.Rol.RolYetkileri.Any(p => p.FormId == 2 && p.YetkiId == 1),
                DuzenlemeYetkisiVarmi = personel.RolID == 1 || personel.Rol.RolYetkileri.Any(p => p.FormId == 2 && p.YetkiId == 2),
                SilmeYetkisiVarmi = personel.RolID == 1 || personel.Rol.RolYetkileri.Any(p => p.FormId == 2 && p.YetkiId == 3),
            };
            form.Show();
        }

        private void SatisPaneli_Click(object sender, EventArgs e)
        {
            var form = new FrmSatisPaneli
            {
                GoruntulemeYetkisiVarmi = personel.RolID == 1 || personel.Rol.RolYetkileri.Any(p => p.FormId == 5 && p.YetkiId == 4),
                EklemeYetkisiVarmi = personel.RolID == 1 || personel.Rol.RolYetkileri.Any(p => p.FormId == 5 && p.YetkiId == 1),
                DuzenlemeYetkisiVarmi = personel.RolID == 1 || personel.Rol.RolYetkileri.Any(p => p.FormId == 5 && p.YetkiId == 2),
                SilmeYetkisiVarmi = personel.RolID == 1 || personel.Rol.RolYetkileri.Any(p => p.FormId == 5 && p.YetkiId == 3),
            };
            form.Show();
        }

        private void MusteriPaneli_Click(object sender, EventArgs e)
        {
            var form = new FrmMusteriPaneli
            {
                GoruntulemeYetkisiVarmi = personel.RolID == 1 || personel.Rol.RolYetkileri.Any(p => p.FormId == 2 && p.YetkiId == 4),
                EklemeYetkisiVarmi = personel.RolID == 1 || personel.Rol.RolYetkileri.Any(p => p.FormId == 2 && p.YetkiId == 1),
                DuzenlemeYetkisiVarmi = personel.RolID == 1 || personel.Rol.RolYetkileri.Any(p => p.FormId == 2 && p.YetkiId == 2),
                SilmeYetkisiVarmi = personel.RolID == 1 || personel.Rol.RolYetkileri.Any(p => p.FormId == 2 && p.YetkiId == 3),
            };
            form.Show();
        }

        private void ParcaPaneli_Click(object sender, EventArgs e)
        {
            var form = new FrmParcaPaneli
            {
                GoruntulemeYetkisiVarmi = personel.RolID == 1 || personel.Rol.RolYetkileri.Any(p => p.FormId == 3 && p.YetkiId == 4),
                EklemeYetkisiVarmi = personel.RolID == 1 || personel.Rol.RolYetkileri.Any(p => p.FormId == 3 && p.YetkiId == 1),
                DuzenlemeYetkisiVarmi = personel.RolID == 1 || personel.Rol.RolYetkileri.Any(p => p.FormId == 3 && p.YetkiId == 2),
                SilmeYetkisiVarmi = personel.RolID == 1 || personel.Rol.RolYetkileri.Any(p => p.FormId == 3 && p.YetkiId == 3),
            };
            form.Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            dbContext = DbContextBuilder.Build();
            personel = dbContext.Personeller
                .Include(p => p.Rol)
                .ThenInclude(p => p.RolYetkileri)
                .Where(p => p.PersonelID == PersonelId).First();
            menuStrip = new MenuStrip();
            CreateDynamicMenu();
        }
    }
}
