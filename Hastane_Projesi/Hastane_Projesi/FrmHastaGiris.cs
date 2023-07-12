using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace Hastane_Projesi
{
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();
        private void LnkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayıt fr =new FrmHastaKayıt();
            fr.Show();
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
           SqlCommand komut = new SqlCommand("Select * from Hastalar Where HastaTc=@p1 and HastaSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTc.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text); 
            SqlDataReader dr = komut.ExecuteReader();
           if (dr.Read())
            {
                FrmHastaDetay fr = new FrmHastaDetay();
                fr.tc=MskTc.Text;
                fr.Show();
                this.Hide();
            }
            else {
                MessageBox.Show("Yanlış giriş yaptınız! Tekrar deneyiniz.");
            };
           bgl.baglanti().Close();
        }
    }
}
