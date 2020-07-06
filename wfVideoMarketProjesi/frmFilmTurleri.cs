using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfVideoMarketProjesi
{
    public partial class frmFilmTurleri : Form
    {
        public frmFilmTurleri()
        {
            InitializeComponent();
        }
        private void frmFilmTurleri_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            cFilmTuru ft = new cFilmTuru();
            ft.FilmTurleriGetir(lvFilmTurleri);
        }
        private void btnYeni_Click(object sender, EventArgs e)
        {
            btnKaydet.Enabled = true;
            btnDegistir.Enabled = false;
            btnSil.Enabled = false;
            Temizle();
        }
        private void Temizle()
        {
            txtFilmTuru.Clear();
            txtAciklama.Clear();
            txtFilmTuru.Focus();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if(txtFilmTuru.Text.Trim() != "")
            {
                cFilmTuru ft = new cFilmTuru();
                bool Sonuc = ft.FilmTuruKontrol(txtFilmTuru.Text);
                if(Sonuc)
                {
                    MessageBox.Show("Bu Film Türü önceden kayıtlı!");
                    txtFilmTuru.Focus();
                }
                else
                {
                    //Sonuc = ft.FilmTuruEkle(txtFilmTuru.Text, txtAciklama.Text);
                    ft.TurAd = txtFilmTuru.Text;
                    ft.Aciklama = txtAciklama.Text;
                    Sonuc = ft.FilmTuruEkle(ft);
                    if(Sonuc)
                    {
                        MessageBox.Show("Film Türü bilgileri kayıt edildi.");
                        Temizle();
                        ft.FilmTurleriGetir(lvFilmTurleri);
                    }
                }
            }else { MessageBox.Show("Film Türü girmelisiniz!", "Eksik Bilgi!"); }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

        }
    }
}
