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
using System.Globalization;

namespace Fabrika_otomasyon1
{
    public partial class Uretim : Form
    {
        public Uretim()
        {
            InitializeComponent();
        }
        SqlConnection ubaglanti = new SqlConnection("Data Source=DESKTOP-65N694M;Initial Catalog=fab;Integrated Security=True");

        private void Uretim_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'fabDataSet2.Uretilen' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.uretilenTableAdapter1.Fill(this.fabDataSet2.Uretilen);
            // TODO: Bu kod satırı 'fabDataSet1.Uretilen' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.uretilenTableAdapter.Fill(this.fabDataSet1.Uretilen);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.uretilenTableAdapter1.Fill(this.fabDataSet2.Uretilen);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1u.Text = "";
            textBox2u.Text = "";
            textBox3u.Text = "";
            textBox4u.Text = "";
            textBox5u.Text = "";
            textBox11.Text = "";
            textBox7u.Text = "";
            textBox8u.Text = "";


        }

        private void button3_Click(object sender, EventArgs e)
        {
            ubaglanti.Open();
            SqlCommand sil = new SqlCommand("DELETE FROM Uretilen where ID=@p1 ", ubaglanti);
            sil.Parameters.AddWithValue("@p1", textBox1u.Text);
            sil.ExecuteNonQuery();
            ubaglanti.Close();
            MessageBox.Show("Silme işlemi Başarılı");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ubaglanti.Open();
                SqlCommand uguncelle = new SqlCommand("INSERT INTO Uretilen (Model,Renk,Desen,Ebat,UretimTarihi,Malezeme,Fiyat) VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7) ", ubaglanti);
                uguncelle.Parameters.AddWithValue("@p1", textBox2u.Text);
                uguncelle.Parameters.AddWithValue("@p2", textBox3u.Text);
                uguncelle.Parameters.AddWithValue("@p3", textBox4u.Text);
                uguncelle.Parameters.AddWithValue("@p4", textBox5u.Text);
                uguncelle.Parameters.AddWithValue("@p5", textBox11.Text);
                uguncelle.Parameters.AddWithValue("@p6", textBox7u.Text);
                uguncelle.Parameters.AddWithValue("@p7", textBox8u.Text);
                uguncelle.ExecuteNonQuery();
                ubaglanti.Close();
                MessageBox.Show("KAYIT BAŞARILI");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
           

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int secim = dataGridView1u.SelectedCells[0].RowIndex;
            textBox1u.Text = dataGridView1u.Rows[secim].Cells[0].Value.ToString();
            textBox2u.Text = dataGridView1u.Rows[secim].Cells[1].Value.ToString();
            textBox3u.Text = dataGridView1u.Rows[secim].Cells[2].Value.ToString();
            textBox4u.Text = dataGridView1u.Rows[secim].Cells[3].Value.ToString();
            textBox5u.Text = dataGridView1u.Rows[secim].Cells[4].Value.ToString();
            textBox11.Text = dataGridView1u.Rows[secim].Cells[5].Value.ToString();
            textBox7u.Text = dataGridView1u.Rows[secim].Cells[6].Value.ToString();
            textBox8u.Text = dataGridView1u.Rows[secim].Cells[7].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ubaglanti.Open();
                SqlCommand uguncelle = new SqlCommand("UPDATE Uretilen SET Model=@p1, Renk=@p2, Desen=@p3, Ebat=@p4, UretimTarihi=@p5, Malezeme=@p6, Fiyat=@p7 WHERE ID=@p8", ubaglanti);
                uguncelle.Parameters.AddWithValue("@p1", textBox2u.Text);
                uguncelle.Parameters.AddWithValue("@p2", textBox3u.Text);
                uguncelle.Parameters.AddWithValue("@p3", textBox4u.Text);
                uguncelle.Parameters.AddWithValue("@p4", textBox5u.Text);
                uguncelle.Parameters.AddWithValue("@p5",textBox11.Text);
               

                uguncelle.Parameters.AddWithValue("@p6", textBox7u.Text);
                uguncelle.Parameters.AddWithValue("@p7", textBox8u.Text);
                uguncelle.Parameters.AddWithValue("@p8", textBox1u.Text); // ID parametresini ekledim

                uguncelle.ExecuteNonQuery();
                ubaglanti.Close();
                MessageBox.Show("Güncelleme başarılı");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }


        private void dataGridView1u_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int secim = dataGridView1u.SelectedCells[0].RowIndex;
            textBox1u.Text = dataGridView1u.Rows[secim].Cells[0].Value.ToString();
            textBox2u.Text = dataGridView1u.Rows[secim].Cells[1].Value.ToString();
            textBox3u.Text = dataGridView1u.Rows[secim].Cells[2].Value.ToString();
            textBox4u.Text = dataGridView1u.Rows[secim].Cells[3].Value.ToString();
            textBox5u.Text = dataGridView1u.Rows[secim].Cells[4].Value.ToString();
            textBox11.Text = dataGridView1u.Rows[secim].Cells[5].Value.ToString();
            textBox7u.Text = dataGridView1u.Rows[secim].Cells[6].Value.ToString();
            textBox8u.Text = dataGridView1u.Rows[secim].Cells[7].Value.ToString();
            

        }
    }
}
