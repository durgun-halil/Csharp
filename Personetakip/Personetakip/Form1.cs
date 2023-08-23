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

namespace Personetakip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-65N694M;Initial Catalog=Personel;Integrated Security=True");

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.persone1TableAdapter.Fill(this.personelDataSet.persone1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.persone1TableAdapter.Fill(this.personelDataSet.persone1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into persone1 (ad, soyad, sehir, maas, medenidurum, meslek) values(@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
                komut.Parameters.AddWithValue("@p1", textad.Text);
                komut.Parameters.AddWithValue("@p2", textsoyad.Text);
                komut.Parameters.AddWithValue("@p3", textsehir.Text);
                komut.Parameters.AddWithValue("@p4", maskedTextmaas.Text);
                komut.Parameters.AddWithValue("@p5", textmedeni.Text);
                komut.Parameters.AddWithValue("@p6", textmeslek.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Personel eklendi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            textid.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            textad.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            textsoyad.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            textsehir.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            maskedTextmaas.Text = dataGridView1.Rows[secim].Cells[4].Value.ToString();
            textmedeni.Text = dataGridView1.Rows[secim].Cells[5].Value.ToString();
            textmeslek.Text = dataGridView1.Rows[secim].Cells[6].Value.ToString();
        }

        private void buttonsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("DELETE FROM persone1 where ıd=@p1", baglanti);
            sil.Parameters.AddWithValue("@p1", textid.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("kayit silindi");
        }

        private void buttontemizle_Click(object sender, EventArgs e)
        {
            textid.Text = "";
            textad.Text = "";
            textsoyad.Text = "";
            textsehir.Text = "";
            maskedTextmaas.Text = "";
            textmedeni.Text = "";
            textmeslek.Text = "";


        }

        private void buttonguncelle_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand guncelle = new SqlCommand("update persone1 set ad=@p1, soyad=@p2, sehir=@p3, maas=@p4, medenidurum=@p5, meslek=@p6 where ıd=@p7", baglanti);
                guncelle.Parameters.AddWithValue("@p1", textad.Text);
                guncelle.Parameters.AddWithValue("@p2", textsoyad.Text);
                guncelle.Parameters.AddWithValue("@p3", textsehir.Text);
                guncelle.Parameters.AddWithValue("@p4", maskedTextmaas.Text);
                guncelle.Parameters.AddWithValue("@p5", textmedeni.Text);
                guncelle.Parameters.AddWithValue("@p6", textmeslek.Text);
                guncelle.Parameters.AddWithValue("@p7", textid.Text); 
                guncelle.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Güncellendi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}


