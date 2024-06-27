using Microsoft.EntityFrameworkCore;
using OtoServis.DataAccess;
using OtoServis.DataAccess.Context;
using OtoServis.DataAccess.Entities;
using OtoServis.Dto;
using OtoServis.Helper;

namespace OtoServis
{
    public partial class FrmParcaPaneli : Form
    {
        private readonly AppDbContext dbContext;
        private bool isSaving = true;
        public bool GoruntulemeYetkisiVarmi { get; set; }
        public bool DuzenlemeYetkisiVarmi { get; set; }
        public bool EklemeYetkisiVarmi { get; set; }
        public bool SilmeYetkisiVarmi { get; set; }

        public FrmParcaPaneli()
        {
            InitializeComponent();
            dbContext = DbContextBuilder.Build();
        }

        void ParcalariYukle()
        {
            if (!GoruntulemeYetkisiVarmi) return;

            var parcalar = dbContext.Parcalar.Where(x => !x.Silindimi).Select(x => new ParcaDto
            {
                Fiyat = x.Fiyat,
                ParcaAdi = x.ParcaAdi,
                StokAdet = x.StokAdet,
                Data = x
            }).ToList();
            DataGridViewHelper.LoadData<ParcaDto>(dgvParca, parcalar);
        }

        void ParcaEkle()
        {
            if (!EklemeYetkisiVarmi) return;
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
            isSaving = true;
        }

        void ParcaGuncelle()
        {
            if (!DuzenlemeYetkisiVarmi) return;

            var (ok, parca) = DataGridViewHelper.GetSelectedValue<ParcaDto>(dgvParca);

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

            bool parcaEklenmismi = dbContext.Parcalar.Any(x => x.ParcaID != parca.Data.ParcaID && x.ParcaAdi == parcaAdi);

            if (parcaEklenmismi)
            {
                MessageBox.Show("Bu parça daha önce eklenmiş", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            parca.Data.ParcaAdi = parcaAdi;
            parca.Data.StokAdet = stok;
            parca.Data.Fiyat = fiyat;

            dbContext.Entry<Parca>(parca.Data).State = EntityState.Modified;
            dbContext.SaveChanges();
            InputlariTemizle();
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
            if (!DuzenlemeYetkisiVarmi) return;

            var (ok, data) = DataGridViewHelper.GetSelectedValue<ParcaDto>(dgvParca);

            if (!ok) return;

            txtParcaAdi.Text = data.ParcaAdi;
            txtStok.Text = data.StokAdet.ToString();
            txtFiyat.Text = data.Fiyat.ToString();

            isSaving = false;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (!SilmeYetkisiVarmi) return;

            if (isSaving)
            {
                MessageBox.Show("Silmek için kayıt seçin", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var (ok, parca) = DataGridViewHelper.GetSelectedValue<ParcaDto>(dgvParca);

            if (!ok)
            {
                MessageBox.Show("Silmek için kayıt seçin", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bu kaydı silmek istediğinize emin misiniz ?", "OtoServis", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            parca.Data.Silindimi = true;

            dbContext.Entry<Parca>(parca.Data).State = EntityState.Modified;
            dbContext.SaveChanges();
            InputlariTemizle();
            ParcalariYukle();
            MessageBox.Show("Kayıt silindi", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
