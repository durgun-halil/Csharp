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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Fabrika_otomasyon1
{
    public partial class Depo : Form
    {
        public Depo()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-65N694M;Initial Catalog=fab;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Depo_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'fabDataSet.Depostok' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.depostokTableAdapter.Fill(this.fabDataSet.Depostok);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.depostokTableAdapter.Fill(this.fabDataSet.Depostok);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1ad.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";











        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("DELETE FROM Depostok where ID=@p1 ", baglanti);
            sil.Parameters.AddWithValue("@p1", textBox1ad.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme işlemi Başarılı");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            textBox1ad.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secim].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[secim].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[secim].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.Rows[secim].Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.Rows[secim].Cells[8].Value.ToString();
            textBox10.Text = dataGridView1.Rows[secim].Cells[9].Value.ToString();
            textBox11.Text = dataGridView1.Rows[secim].Cells[10].Value.ToString();









        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand kaydet = new SqlCommand("INSERT INTO Depostok (HamMaddeadi,HamMaddekodu,Stokmiktarı,minstokmiktarı,maxstokmiktarı,Birimfiyat,depokonumu,guncellemetarihi,uretimtarihi,sonkullanmatarihi) VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", baglanti);
                kaydet.Parameters.AddWithValue("@p1", textBox2.Text);
                kaydet.Parameters.AddWithValue("@p2", textBox3.Text);
                kaydet.Parameters.AddWithValue("@p3", textBox4.Text);
                kaydet.Parameters.AddWithValue("@p4", textBox5.Text);
                kaydet.Parameters.AddWithValue("@p5", textBox6.Text);
                kaydet.Parameters.AddWithValue("@p6", textBox7.Text);
                kaydet.Parameters.AddWithValue("@p7", textBox8.Text);
                kaydet.Parameters.AddWithValue("@p8", textBox9.Text);
                kaydet.Parameters.AddWithValue("@p9", textBox10.Text);
                kaydet.Parameters.AddWithValue("@p10", textBox11.Text);
                kaydet.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Başarılı");








            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata :" + ex.Message);

            }





        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand guncelle = new SqlCommand("UPDATE Depostok SET HamMaddeadi=@p1, HamMaddekodu=@p2, Stokmiktarı=@p3, minstokmiktarı=@p4, maxstokmiktarı=@p5, Birimfiyat=@p6, depokonumu=@p7, guncellemetarihi=@p8, uretimtarihi=@p9, sonkullanmatarihi=@p10 WHERE ID=@p11" , baglanti);

                guncelle.Parameters.AddWithValue("@p1", textBox2);
                guncelle.Parameters.AddWithValue("@p2", textBox3.Text);
                guncelle.Parameters.AddWithValue("@p3", textBox4.Text);
                guncelle.Parameters.AddWithValue("@p4", textBox5.Text);
                guncelle.Parameters.AddWithValue("@p5", textBox6.Text);


                guncelle.Parameters.AddWithValue("@p6", textBox7.Text);
                guncelle.Parameters.AddWithValue("@p7", textBox8.Text);
                guncelle.Parameters.AddWithValue("@p8", textBox9.Text);
                guncelle.Parameters.AddWithValue("@p9", textBox10.Text);
                guncelle.Parameters.AddWithValue("@p10", textBox11.Text);
                guncelle.Parameters.AddWithValue("@p11", textBox1ad.Text); 

                guncelle.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Güncelleme başarılı");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

    }
}

//UPDATE Depostok SET HamMaddeadi=@p1, HamMaddekodu=@p2, Stokmiktarı=@p3, minstokmiktarı=@p4, maxstokmiktarı=@p5, Birimfiyat=@p6, depokonumu=@p7, guncellemetarihi=@p8, uretimtarihi=@p9, sonkullanmatarihi=@p10", baglanti

