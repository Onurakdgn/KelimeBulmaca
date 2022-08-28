using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string gizli;
        string kelime;
        string yeni;

        private void button1_Click(object sender, EventArgs e)
        {
            gizli = "";
            SqlConnection bag = new SqlConnection(@"server=DESKTOP-4BELAU0\SQLEXPRESS;initial catalog=kelimeler;integrated security=true");
            Random rnd = new Random();
            string sql = "select tr,en from kelimeler";
            SqlDataAdapter da = new SqlDataAdapter(sql, bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int satirsayisi = dt.Rows.Count;
            int indexnumber = rnd.Next(0, satirsayisi);
            if (checkBox1.Checked)
            {
                kelime = dt.Rows[indexnumber][1].ToString();
            }
            else
            {
                kelime = dt.Rows[indexnumber][0].ToString();
            }


            kelime = kelime.Trim();

            gizli = "";
            foreach (var item in kelime)
            {
                gizli += "*";
            }
            label1.Text = gizli;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yeni = "";
            char karakter = Convert.ToChar(textBox1.Text);
            for (int i = 0; i < kelime.Length; i++)
            {
                if (karakter == kelime[i])
                {
                    yeni += kelime[i];
                }
                else
                {
                    yeni += gizli[i];
                }

            }
            gizli = yeni;
            label1.Text = gizli;
            if (label1.Text == kelime)
                MessageBox.Show("bildiniz");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tahmin = textBox2.Text;
            if (kelime == tahmin)

            {
                MessageBox.Show("bildiniz");
                label1.Text = kelime;

            }
            else
            {
                MessageBox.Show("bilemediniz");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Emin misiniz?","Kapatılıyor",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)//Hatalı Açılmıştır
        {

        }
    }
}
