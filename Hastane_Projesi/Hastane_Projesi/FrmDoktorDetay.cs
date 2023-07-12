using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Hastane_Projesi
{
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl=new sqlBaglantisi();
        public string TC;

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            LblTc.Text = TC;

            //Dokor Ad Soyad
            SqlCommand Komut = new SqlCommand("Select DoktorAd, DoktorSoyad from Doktorlar where DoktorTC=@p1", bgl.baglanti());
            Komut.Parameters.AddWithValue("@p1",LblTc.Text);
            SqlDataReader dr= Komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0]+ " " + dr[1];
            }
            bgl.baglanti().Close();


            ///randevular
            DataTable dt= new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Randevu where RandevuDoktor='" + LblAdSoyad.Text + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDuzenle fr = new FrmDoktorBilgiDuzenle();
            fr.TCNO = LblTc.Text;
            fr.Show();

        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular fr = new FrmDuyurular();
            fr.Show();
        }

        private void BtnCıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            RchRandevuSikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
