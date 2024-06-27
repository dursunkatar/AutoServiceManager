using Microsoft.EntityFrameworkCore;
using OtoServis.DataAccess;
using OtoServis.DataAccess.Context;
using OtoServis.DataAccess.Entities;
using OtoServis.Dto;
using OtoServis.Helper;

namespace OtoServis
{
    public partial class FrmYetkilendirme : Form
    {
        private readonly AppDbContext dbContext;
        public FrmYetkilendirme()
        {
            InitializeComponent();
            dbContext = DbContextBuilder.Build();
        }

        void RolleriYukle()
        {
            var roller = dbContext.Roller.Where(p => p.RolID != 1).ToList();
            roller.Insert(0, new Rol
            {
                RolAdi = "Seçiniz",
                RolID = -1
            });

            ComboBoxHelper.LoadData(cmbRol, roller, "RolAdi", "RolID");
        }

        void ekranlariYukle()
        {
            var forms = dbContext.UygulamaFormlari.Select(p => new UygulamaFormDto
            {
                ID = p.Id,
                FormAciklama = p.FormAciklama,
            }).ToList();

            foreach (var form in forms)
            {
                checkedListBoxEkranlar.Items.Add(form);
            }
        }

        void yetkileriYukle()
        {
            var data = dbContext.Yetkiler.Select(p => new YetkiDto
            {
                Id = p.Id,
                YetkiAdi = p.YetkiAdi
            }).ToList();

            foreach (var item in data)
            {
                checkedListBoxYetkiler.Items.Add(item);
            }
        }

        void rolYetkileriniYukle()
        {
            var data = dbContext.RolYetkiler
                  .Include(p => p.Rol)
                  .Include(p => p.UygulamaForm)
                  .Include(p => p.Yetki)
                  .Select(p => new RolYetkiDto
                  {
                      Rol = p.Rol.RolAdi,
                      Form = p.UygulamaForm.FormAdi,
                      Yetki = p.Yetki.YetkiAdi,
                      Data = p
                  }).ToList();
            DataGridViewHelper.LoadData<RolYetkiDto>(dgvYetkiler, data);
        }

        void secilmisYetkileriIsaretle()
        {
            if (checkedListBoxEkranlar.CheckedItems is null || checkedListBoxEkranlar.CheckedItems.Count == 0) return;
            if (cmbRol.SelectedIndex == 0) return;
            var form = checkedListBoxEkranlar.CheckedItems[0] as UygulamaFormDto;
            var rol = cmbRol.SelectedItem as Rol;

            var rolYetkiler = dbContext.RolYetkiler.Where(p => p.RolId == rol.RolID && p.FormId == form.ID).Select(p => p.YetkiId).ToList();

            for (int i = 0; i < checkedListBoxYetkiler.Items.Count; i++)
            {
                var item = checkedListBoxYetkiler.Items[i] as YetkiDto;
                checkedListBoxYetkiler.SetItemChecked(i, rolYetkiler.Contains(item.Id));
            }
        }

        private void FrmYetkilendirme_Load(object sender, EventArgs e)
        {
            RolleriYukle();
            ekranlariYukle();
            yetkileriYukle();
            rolYetkileriniYukle();
        }

        private void checkedListBoxEkranlar_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < checkedListBoxEkranlar.Items.Count; i++)
                {
                    if (i != e.Index)
                    {
                        checkedListBoxEkranlar.SetItemChecked(i, false);
                    }
                }
            }
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            secilmisYetkileriIsaretle();
        }

        private void checkedListBoxEkranlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            secilmisYetkileriIsaretle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cmbRol.SelectedIndex == 0)
            {
                MessageBox.Show("Rol Seçiniz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (checkedListBoxEkranlar.CheckedItems is null || checkedListBoxEkranlar.CheckedItems.Count == 0)
            {
                MessageBox.Show("Ekran seçiniz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (checkedListBoxYetkiler.CheckedItems is null || checkedListBoxYetkiler.CheckedItems.Count == 0)
            {
                MessageBox.Show("Yetki seçiniz", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var rol = cmbRol.SelectedItem as Rol;
            var form = checkedListBoxEkranlar.CheckedItems[0] as UygulamaFormDto;
            var rolYetkiler = dbContext.RolYetkiler.Where(p => p.RolId == rol.RolID && p.FormId == form.ID).ToList();
            dbContext.RolYetkiler.RemoveRange(rolYetkiler);

            foreach (var item in checkedListBoxYetkiler.CheckedItems)
            {
                var yetki = item as YetkiDto;
                dbContext.RolYetkiler.Add(new RolYetkisi
                {
                    FormId = form.ID,
                    RolId = rol.RolID,
                    YetkiId = yetki.Id
                });
            }

            dbContext.SaveChanges();
            rolYetkileriniYukle();
            MessageBox.Show("Kaydedildi", "OtoServis", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void checkedListBoxYetkiler_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            const int YETKI_DUZENLE_ID = 2;
            const int YETKI_GORUNTULE_ID = 4;
            const int YETKI_SIL_ID = 3;

            var yetki = checkedListBoxYetkiler.Items[e.Index] as YetkiDto;
            if ((yetki.Id == YETKI_DUZENLE_ID || yetki.Id == YETKI_SIL_ID) && e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < checkedListBoxYetkiler.Items.Count; i++)
                {
                    if (i != e.Index)
                    {
                        var item = checkedListBoxYetkiler.Items[i] as YetkiDto;
                        if (item.Id == YETKI_GORUNTULE_ID)
                        {
                            checkedListBoxYetkiler.SetItemChecked(i, true);
                            break;
                        }

                    }
                }
            }

            if (yetki.Id == YETKI_GORUNTULE_ID && e.NewValue == CheckState.Unchecked)
            {
                for (int i = 0; i < checkedListBoxYetkiler.Items.Count; i++)
                {
                    if (i != e.Index)
                    {
                        var item = checkedListBoxYetkiler.Items[i] as YetkiDto;
                        if (item.Id == YETKI_SIL_ID || item.Id == YETKI_DUZENLE_ID)
                        {
                            checkedListBoxYetkiler.SetItemChecked(i, false);
                        }

                    }
                }
            }


        }
    }
}
