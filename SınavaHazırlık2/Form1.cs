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

namespace SınavaHazırlık2
{
    public partial class Form1 : Form
    {
        SqlConnection baglantı = new SqlConnection(@"Data Source=tsomtal.com;Initial Catalog=UyeDb199;Integrated Security=True;");
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try 
            {
                baglantı.Open();
                string squelcum= "INSERT INTO Uyegiris  VALUES('" + txtkullanıcıadı.Text + "','" + txtadsoyad.Text + "','" + txtEposta.Text +"','" +txtSifre.Text+"');";
                SqlCommand cmd = new SqlCommand(squelcum,baglantı);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Veriler kaydedildi...");
            }

            catch (Exception ex) 
            {
                MessageBox.Show("Bağlantı hatası\n" + ex.Message);
            } 
            finally 
            {
                if (baglantı != null)   baglantı.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView1.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'uyedb199DataSet.Uyegiris' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.uyegirisTableAdapter.Fill(this.uyedb199DataSet.Uyegiris);

        }
    }
}
