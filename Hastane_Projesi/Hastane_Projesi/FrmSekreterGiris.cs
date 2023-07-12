using System;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Hastane_Projesi
{
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("Select * from Sekreter where SekreterTc=@p1 and SekreterSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTc.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader rd = komut.ExecuteReader();
            if (rd.Read())
            {
                FrmSekreterDetay frs = new FrmSekreterDetay();
                frs.TCnumara=MskTc.Text;
                frs.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre");
            }
            bgl.baglanti().Close();
        }
    }
}
