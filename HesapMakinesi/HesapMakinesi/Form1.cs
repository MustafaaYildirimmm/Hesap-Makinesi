using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HesapMakinesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRakam_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            rakamEkleme(btn.Text);
        }
        private void rakamEkleme(string rakam)
        {
            if (txtSonuc.Text == "0")
            {
                txtSonuc.Text = rakam;
            }
            else
                txtSonuc.Text += rakam;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtSonuc.Text.Length == 1) txtSonuc.Text = "0";
            else txtSonuc.Text= txtSonuc.Text.Substring(0, txtSonuc.Text.Length - 1);
        }
       
        private void islemYapma(string islemTipi)
        {
            if (txtSonuc.Text == "0")
                return;
            if (txtSonuc.Text.Substring(0, txtSonuc.Text.Length - 1) == ",")
                txtSonuc.Text.Replace(",", " ");

            lstIslem.Items.Add(txtSonuc.Text);
            lstIslem.Items.Add(islemTipi);
            txtSonuc.Text = "0";
        }

        private void btnIslem_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            islemYapma(btn.Text);
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtSonuc.Text = "0";
            lstIslem.Items.Clear();
        }

        private void btnVirgül_Click(object sender, EventArgs e)
        {
            if (!txtSonuc.Text.Contains(','))
                txtSonuc.Text = txtSonuc.Text.PadRight(txtSonuc.Text.Length + 1, ',');
        }

        private void btnEsittir_Click(object sender, EventArgs e)
        {
            lstIslem.Items.Add(txtSonuc.Text);
            string islemTipi = "";
            double? sonuc = null;

            foreach (string item in lstIslem.Items)
            {
                if (sonuc == null) sonuc = Convert.ToDouble(item);
                else if (islemTipi != "")
                {
                    switch (islemTipi)
                    {
                        case "+": sonuc += Convert.ToDouble(item); break;
                        case "*": sonuc *= Convert.ToDouble(item); break;
                        case "/": sonuc /= Convert.ToDouble(item); break;
                        case "-": sonuc -= Convert.ToDouble(item); break;

                    }
                    islemTipi = "";
                }
                else
                    islemTipi = item;
            }
            txtSonuc.Text = sonuc.ToString();
        }

       
    }
}
