using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
namespace Pattern
{
    public partial class FrmMusteriGorusleri : Form
    {
        public FrmMusteriGorusleri()
        {
            InitializeComponent();
        }
        Database db = new Database();
        private void verileriGoster()
        {
            //Verileri Göster butonuna tıklanıldığında her defasında ekleme yapmaması için listView1'in içini temizledim.
            listView1.Items.Clear();
            db.baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from MusteriGorusleri", db.baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Mesajid"].ToString();
                ekle.SubItems.Add(oku["AdSoyad"].ToString());
                ekle.SubItems.Add(oku["Mesaj"].ToString());
                listView1.Items.Add(ekle);
            }
            db.baglanti.Close();
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            db.baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into MusteriGorusleri(AdSoyad,Mesaj) " +
                               "values('" + TxtAdSoyad.Text + "','" + RtbMesaj.Text + "')", db.baglanti);
            komut.ExecuteNonQuery();
            db.baglanti.Close();
            verileriGoster();
        }

        private void FrmMusteriGorusleri_Load_1(object sender, EventArgs e)
        {
            verileriGoster();
        }
        int id = 0;
        //Listview' a çift tıklanınca listviewdaki verileri textboxa richttextboxa geri yükler.
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            TxtAdSoyad.Text = listView1.SelectedItems[0].SubItems[1].Text;
            RtbMesaj.Text = listView1.SelectedItems[0].SubItems[2].Text;
        }

       
    }
}
