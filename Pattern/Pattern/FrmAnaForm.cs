using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pattern
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        private void FrmAnaForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LblTarih.Text = DateTime.Now.ToLongDateString();
            LblSaat.Text = DateTime.Now.ToLongTimeString();
        }

        private void BtnKullaniciGiris_Click(object sender, EventArgs e)
        {
            //frm adında bir nesne oluşturdum.
            //Admin Giriş butonuna tıklandığında FrmAdminGiris Formuna gidilmesini sağladım.
            FrmGiris frm = new FrmGiris();
            frm.Show();
            this.Hide();
        }
        private void BtnUrunEkle_Click(object sender, EventArgs e)
        {
            FrmUrunEkle frm = new FrmUrunEkle();
            frm.Show();
        }

        private void BtnStokIslemleri_Click(object sender, EventArgs e)
        {
            FrmStok frm = new FrmStok();
            frm.Show();
        }

        private void BtnKadinGiyim_Click(object sender, EventArgs e)
        {
            FrmKadin frm = new FrmKadin();
            frm.Show();
        }

        private void BtnErkekGiyim_Click(object sender, EventArgs e)
        {
            FrmErkek frm = new FrmErkek();
            frm.Show();
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMusteriGorusleri_Click(object sender, EventArgs e)
        {
            FrmMusteriGorusleri frm = new FrmMusteriGorusleri();
            frm.Show();

        }
    }
}
