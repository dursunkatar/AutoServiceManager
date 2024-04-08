using Microsoft.EntityFrameworkCore;
using OtoServis.DataAccess;
using OtoServis.DataAccess.Context;
using OtoServis.DataAccess.Entities;
using OtoServis.Helper;

namespace OtoServis
{
    public partial class FrmParcaPaneli : Form
    {
        private readonly AppDbContext dbContext;
        private bool isSaving = true;
        public FrmParcaPaneli()
        {
            InitializeComponent();
            dbContext = DbContextBuilder.Build();
        }

        void ParcalariYukle()
        {
            var parcalar = dbContext.Parcalar.ToList();
            DataGridViewHelper.LoadData<Parca>(dgvParca, parcalar);
        }

        void ParcaEkle()
        {
            string parcaAdi = txtParcaAdi.Text.Trim();
            string stokBilgisi = txtStok.Text.Trim();
            string fiyatBilgisi = txtFiyat.Text.Trim();

            if (parcaAdi == string.Empty || stokBilgisi == string.Empty || fiyatBilgisi == string.Empty)
            {
                MessageBox.Show("Boş alan bırakmayınız", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(fiyatBilgisi, out decimal fiyat))
            {
                MessageBox.Show("Fiyat bilgisi geçersiz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(stokBilgisi, out int stok))
            {
                MessageBox.Show("Stok bilgisi geçersiz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool parcaEklenmismi = dbContext.Parcalar.Any(x => x.ParcaAdi == parcaAdi);

            if (parcaEklenmismi)
            {
                MessageBox.Show("Bu parça daha önce eklenmiş", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            dbContext.Parcalar.Add(new Parca
            {
                Fiyat = fiyat,
                ParcaAdi = parcaAdi,
                StokAdet = stok
            });

            dbContext.SaveChanges();
            InputlariTemizle();
            MessageBox.Show("Kaydedildi", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void InputlariTemizle()
        {
            txtParcaAdi.Clear();
            txtStok.Clear();
            txtFiyat.Clear();
        }

        void ParcaGuncelle()
        {
            var (ok, data) = DataGridViewHelper.GetSelectedValue<Parca>(dgvParca);

            if (!ok)
            {
                MessageBox.Show("Güncellenecek Kayıt Yok", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string parcaAdi = txtParcaAdi.Text.Trim();
            string stokBilgisi = txtStok.Text.Trim();
            string fiyatBilgisi = txtFiyat.Text.Trim();

            if (parcaAdi == string.Empty || stokBilgisi == string.Empty || fiyatBilgisi == string.Empty)
            {
                MessageBox.Show("Boş alan bırakmayınız", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(fiyatBilgisi, out decimal fiyat))
            {
                MessageBox.Show("Fiyat bilgisi geçersiz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(stokBilgisi, out int stok))
            {
                MessageBox.Show("Stok bilgisi geçersiz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool parcaEklenmismi = dbContext.Parcalar.Any(x => x.ParcaID != data.ParcaID && x.ParcaAdi == parcaAdi);

            if (parcaEklenmismi)
            {
                MessageBox.Show("Bu parça daha önce eklenmiş", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            data.ParcaAdi = parcaAdi;
            data.StokAdet = stok;
            data.Fiyat = fiyat;

            dbContext.Entry<Parca>(data).State = EntityState.Modified;
            dbContext.SaveChanges();
            isSaving = true;
            MessageBox.Show("Kaydedildi", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (isSaving)
                {
                    ParcaEkle();
                }
                else
                {
                    ParcaGuncelle();
                }


                ParcalariYukle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmParcaYonetimPaneli_Load(object sender, EventArgs e)
        {
            ParcalariYukle();
        }

        private void dgvParca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var (ok, data) = DataGridViewHelper.GetSelectedValue<Parca>(dgvParca);

            if (!ok) return;

            txtParcaAdi.Text = data.ParcaAdi;
            txtStok.Text = data.StokAdet.ToString();
            txtFiyat.Text = data.Fiyat.ToString();

            isSaving = false;
        }
    }
}
