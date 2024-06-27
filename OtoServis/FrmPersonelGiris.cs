using Microsoft.EntityFrameworkCore;
using OtoServis.DataAccess;
using OtoServis.DataAccess.Context;

namespace OtoServis
{
    public partial class FrmPersonelGiris : Form
    {
        private readonly AppDbContext dbContext;
        public FrmPersonelGiris()
        {
            InitializeComponent();
            dbContext = DbContextBuilder.Build();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string sifre = txtSifre.Text;

            if (email == string.Empty || sifre == string.Empty)
            {
                MessageBox.Show("Giriş bilgilerinizi giriniz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var personelVarmi = dbContext.Personeller.FirstOrDefault(p => p.Email == email && p.Sifre == sifre && !p.Silindimi);

            if (personelVarmi is null)
            {
                MessageBox.Show("Personel email veya şifre yanlış", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            bool yetkiVarmi = dbContext.Personeller
            .Include(p => p.Rol)
                .ThenInclude(p => p.RolYetkileri)
                .Where(p => p.PersonelID == personelVarmi.PersonelID).Any(p => p.Rol.RolYetkileri.Any());

            if (!yetkiVarmi)
            {
                MessageBox.Show("Yetkilendirme işleminiz yapılmamış", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var frmMain = new FrmMain
            {
                PersonelId = personelVarmi.PersonelID
            };
            frmMain.Show();

            this.Hide();
        }
    }
}
