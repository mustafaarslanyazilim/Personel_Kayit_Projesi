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

namespace Personel_Kayit
{
    public partial class FrmGrafik : Form
    {
        public FrmGrafik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-657OBKD\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void FrmGrafik_Load(object sender, EventArgs e)
        {
            //GRAFİK 1
            baglanti.Open();
            //bir şehirde kaç kişi var
            SqlCommand komutg1 = new SqlCommand("Select PerSehir,Count(*) From Tbl_Personel GROUP BY PerSehir", baglanti);
            SqlDataReader dr1=komutg1.ExecuteReader();
            while(dr1.Read())
            {

                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }

            baglanti.Close();

            //GRAFİK 2
            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("Select PerMeslek,AVG(PerMaas) From Tbl_Personel GROUP BY PerMeslek",baglanti);
            SqlDataReader dr2=komutg2.ExecuteReader();
            while(dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
