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
        HumidityCalculatorEntities db = new HumidityCalculatorEntities();

        public PrancipalForm()
        {
            InitializeComponent();
        }

        private void PrancipalForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'humidityCalculatorDataSet.Observateur' table. You can move, or remove it, as needed.
            this.observateurTableAdapter.Fill(this.humidityCalculatorDataSet.Observateur);
            bunifuLabel1.Text = "COPYRIGHT © " + DateTime.Now.Year + " ABHGZR, ";
            var obser = (from o in db.Observateurs
                         select new
                         {
                             ID = o.ObservateurId,
                             NomPrenom = o.NomPrenomObservateur,
                         });
            datagridvObs.DataSource = obser.ToList();
            var Bas = (from b in db.Bassins
                       select new
                       {
                           ID = b.BassinId,
                           NomBassin = b.NomBassin,
                       });
            datagridvB.DataSource = Bas.ToList();
            var sta = (from s in db.Stations
                       select new
                       {
                           ID = s.StationId,
                           NomStation = s.NomStation,
                       });
            datagridvStat.DataSource = sta.ToList();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void BtnSB_Click(object sender, EventArgs e)
        {

        }

        private void BtnAjB_Click(object sender, EventArgs e)
        {

        }

        private void BtnMB_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bunifuPages1.SetPage("Contact");
        }

        private void datagridvObs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxCodeObs.Text = datagridvObs.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxNomObs.Text = datagridvObs.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void datagridvStat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxNomStat.Text = datagridvStat.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxCodeStat.Text = datagridvStat.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void datagridvB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxNomBas.Text = datagridvB.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxCodeBas.Text = datagridvB.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
    }
}
