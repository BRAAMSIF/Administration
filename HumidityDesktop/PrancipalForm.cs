using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumidityDesktop
{
    public partial class PrancipalForm : Form
    {
        public PrancipalForm()
        {
            InitializeComponent();
        }

        

        private void PrancipalForm_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'humidityCalculatorDataSet.Observateur' table. You can move, or remove it, as needed.
            this.observateurTableAdapter.Fill(this.humidityCalculatorDataSet.Observateur);
            bunifuLabel1.Text = "COPYRIGHT © " + DateTime.Now.Year + " ABHGZR, ";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("Tableau");
            
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("Humidite");
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("Imprimer"); 
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnSB_Click(object sender, EventArgs e)
        {

        }

        private void BtnAjB_Click(object sender, EventArgs e)
        {

        }

        private void BtnMB_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuPanel4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bunifuPages1.SetPage("Contact");
        }
    }
}
