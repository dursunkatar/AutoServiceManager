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

            bool personelVarmi = dbContext.Personeller.Any(p => p.Email == email && p.Sifre == sifre && !p.Silindimi);

            if (!personelVarmi)
            {
                MessageBox.Show("Personel email veya şifre yanlış", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var frmMain = new FrmMain();
            frmMain.Show();

            this.Hide();
        }
    }
}
