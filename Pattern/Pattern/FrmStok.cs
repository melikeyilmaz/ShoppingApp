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
    public partial class FrmStok : Form
    {
        private Observer observer;

        public FrmStok()
        {
            InitializeComponent();
        }

        private void FrmStok_Load(object sender, EventArgs e)
        {
            Stok stok = new Stok(); //Stok sınıfından stok adında nesne oluşturma.
            dataGridView1.DataSource = stok.Tablolar(); //dataGridView'ın içine aktarma.
        }

        //Verileri dataGridView'ın içine aktarma.
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString());
            TxtAdi.Text = dataGridView1.Rows[e.RowIndex].Cells["UrunAdi"].Value.ToString();
            TxtKod.Text = dataGridView1.Rows[e.RowIndex].Cells["UrunKodu"].Value.ToString();
            CmbKategori.Text = dataGridView1.Rows[e.RowIndex].Cells["Kategori"].Value.ToString();
            TxtFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells["Fiyat"].Value.ToString();
            TxtAdet.Text = dataGridView1.Rows[e.RowIndex].Cells["Adet"].Value.ToString();
            CmbPazarlik.Text = dataGridView1.Rows[e.RowIndex].Cells["PazarlikBilgisi"].Value.ToString();
            CmbYipranma.Text = dataGridView1.Rows[e.RowIndex].Cells["YipranmaPayi"].Value.ToString();            
        }

        private void BtnVerileriGoster_Click(object sender, EventArgs e)
        {
            Stok stok = new Stok(); //Stok sınıfından stok adında nesne oluşturma.
            dataGridView1.DataSource = stok.Tablolar(); //dataGridView'ın içine aktarma.
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtAdi.Text = "";
            TxtKod.Text = "";
            CmbKategori.Text = "";
            TxtFiyat.Text = "";
            TxtAdet.Text = "";
            CmbPazarlik.Text = "";
            CmbYipranma.Text = "";
        }

        //public string alanKisi { get; set; }
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            Database db = new Database();
           
            int id = Convert.ToInt16(lblID.Text);
            Stok stok = new Stok();
            stok.UrunGuncelle(id, TxtAdi.Text, TxtKod.Text, CmbKategori.Text, TxtFiyat.Text, TxtAdet.Text,
                                CmbPazarlik.Text, CmbYipranma.Text);
            dataGridView1.DataSource = stok.Tablolar();
            db.baglanti.Open();
            SqlCommand komut = new SqlCommand("update Urun set urunAdi=@urunadi where " +
                                               "durumu = 'Dolu' AND urunAdi=@urunadi ", db.baglanti);           
            komut.Parameters.AddWithValue("@urunadi", TxtAdi.Text);
            komut.ExecuteNonQuery();
            db.baglanti.Close();

            ConcreteSubject s = new ConcreteSubject();

            s.Attach(new ConcreteObserver(s,"stoktaki bilgilerinde"));

            //Gözlemcileri bilgilendirme.      
            s.SubjectState ="güncelleme ";
            s.Notify();

        }
       
        //Sil butonuna basınca calısan metod.
        private void BtnSil_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            int id = Convert.ToInt16(lblID.Text);
            Stok stok = new Stok();
            stok.UrunSil(id);
            dataGridView1.DataSource = stok.Tablolar();
            db.baglanti.Open();
            SqlCommand komut = new SqlCommand("update Urun set durumu = 'Bos', urunuAlan = NULL  where " +
                                               "urunAdi=@urunadi", db.baglanti);
            komut.Parameters.AddWithValue("@urunadi", TxtAdi.Text);
            komut.ExecuteNonQuery();
            db.baglanti.Close();

            //Subject product = new Subject();
            //product.Detach(observer);

        }
        //Ara butonuna basınca calısan metod.
        private void BtnAra_Click(object sender, EventArgs e)
        {
            Stok stok = new Stok();
            dataGridView1.DataSource = stok.UrunAra(TxtAra.Text);
        }
        //Kullanıcının anlamsız bir veri girmesini ve boş geçmesini engellemek için.
        private void SadeceHarf_BoslukGirilemez(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
            if ((int)e.KeyChar == 32)
            {
                e.Handled = true;
            }
        }

        //Kullanıcının anlamsız bir veri girmesini ve boş geçmesini engellemek için.
        private void SadeceSayi_BoslukGirilemez(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 32)
            {
                e.Handled = true;
            }
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        
    }
}
