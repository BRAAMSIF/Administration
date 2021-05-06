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
            bunifuLabel1.Text = "COPYRIGHT © " + DateTime.Now.Year + " ABHGZR, ";
            RemplireLesGrid();
        }

        private void RemplireLesGrid()
        {
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

            var rhs = (from rh in db.RelativeHumidities
                       select new
                       {
                           ID = rh.RelativeHumidityId,
                           Sec = rh.Sec,
                           Mou = rh.Mou,
                           Hum = rh.Hum,
                           Heure = rh.Heur,
                           MAX = rh.ThermometreMax,
                           MIN = rh.ThermometreMin,
                           MOY = Math.Round(rh.ThermometreMoyMaxMin, 2),
                           MA = rh.ThermometreMA,
                           MI = rh.ThermometreMI,
                           Date = rh.DateObservation
                       });
            datagridvHumidity.DataSource = rhs.ToList();
            foreach (var ob in obser)
            {
                comboBoxObs.Items.Add(ob.ID + " " + ob.NomPrenom);
            }
            foreach (var st in sta)
            {
                comboBoxStat.Items.Add(st.ID + " " + st.NomStation);
            }
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bunifuPages1.SetPage("Contact");
        }

        private void datagridvObs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBoxCodeObs.Text = datagridvObs.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBoxNomObs.Text = datagridvObs.Rows[e.RowIndex].Cells[1].Value == null ? "" : datagridvObs.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void datagridvStat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBoxNomStat.Text = datagridvStat.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBoxCodeStat.Text = datagridvStat.Rows[e.RowIndex].Cells[0].Value.ToString();
        
            }
        }

        private void datagridvB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBoxNomBas.Text = datagridvB.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBoxCodeBas.Text = datagridvB.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void BtnAjObs_Click(object sender, EventArgs e)
        {
            Observateur observateur = new Observateur();
            try
            {
                observateur.NomPrenomObservateur = textBoxNomObs.Text;
                observateur.StationId = Convert.ToInt32(textBoxCodeStat.Text);
                db.Observateurs.Add(observateur);
                db.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Vous devez selectioné un station");
            }
            RemplireLesGrid();
        }

        private void BtnSObs_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxCodeObs.Text);
            Observateur observateur = db.Observateurs.SingleOrDefault(ob => ob.ObservateurId == id);
            db.Observateurs.Remove(observateur);
            db.SaveChanges();
            RemplireLesGrid();
        }

        private void BtnMObs_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxCodeObs.Text);
            Observateur observateur = db.Observateurs.SingleOrDefault(ob => ob.ObservateurId == id);
            observateur.NomPrenomObservateur = textBoxNomObs.Text;
            db.SaveChanges();
            RemplireLesGrid();
        }

        private void BtnReObs_Click(object sender, EventArgs e)
        {
            RemplireLesGrid();
            string txt = textBoxNomObs.Text.ToLower();
            if (txt != "" || txt != null)
            {
                for (int i = 0; i < datagridvObs.Rows.Count; i++)
                {
                    if (datagridvObs.Rows[i].Cells[1].Value != null && datagridvObs.Rows[i].Cells[1].Value.ToString().ToLower().Contains(txt.ToLower()))
                    {
                        datagridvObs.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(39, 174, 96);
                        break;
                    }
                }
            }
        }

        private void BtnAStat_Click(object sender, EventArgs e)
        {
            Station station = new Station();
            try
            {
                station.NomStation = textBoxNomStat.Text;
                station.BassinId = Convert.ToInt32(textBoxCodeBas.Text);
                db.Stations.Add(station);
                db.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Vous devez selectioné un Bassin");
            }
            RemplireLesGrid();
        }

        private void BtnMStat_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxCodeStat.Text);
            Station station = db.Stations.SingleOrDefault(st => st.StationId == id);
            station.NomStation = textBoxNomStat.Text;
            db.SaveChanges();
            RemplireLesGrid();
        }

        private void BtnSuprStat_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxCodeStat.Text);
            Station station = db.Stations.SingleOrDefault(st => st.StationId == id);
            db.Stations.Remove(station);
            db.SaveChanges();
            RemplireLesGrid();
        }

        private void BtnReStat_Click(object sender, EventArgs e)
        {
            RemplireLesGrid();
            string txt = textBoxNomStat.Text.ToLower();
            if (txt != "" || txt != null)
            {
                for (int i = 0; i < datagridvStat.Rows.Count; i++)
                {
                    if (datagridvStat.Rows[i].Cells[1].Value != null && datagridvStat.Rows[i].Cells[1].Value.ToString().ToLower().Contains(txt.ToLower()))
                    {
                        datagridvStat.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(39, 174, 96);
                        break;
                    }
                }
            }
        }
        
        private void BtnAjB_Click(object sender, EventArgs e)
        {
            Bassin bassin = new Bassin();
            try
            {
                bassin.NomBassin = textBoxNomBas.Text;
                db.Bassins.Add(bassin);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            RemplireLesGrid();
        }

        private void BtnMB_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxCodeBas.Text);
            Bassin bassin = db.Bassins.SingleOrDefault(bs => bs.BassinId == id);
            bassin.NomBassin = textBoxNomBas.Text;
            db.SaveChanges();
            RemplireLesGrid();
        }

        private void BtnSB_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxCodeBas.Text);
            Bassin bassin = db.Bassins.SingleOrDefault(bs => bs.BassinId == id);
            db.Bassins.Remove(bassin);
            db.SaveChanges();
            RemplireLesGrid();
        }

        private void BtnReB_Click(object sender, EventArgs e)
        {
            RemplireLesGrid();
            string txt = textBoxNomBas.Text.ToLower();
            if (txt != "" || txt != null)
            {
                for (int i = 0; i < datagridvB.Rows.Count; i++)
                {
                    if (datagridvB.Rows[i].Cells[1].Value != null && datagridvB.Rows[i].Cells[1].Value.ToString().ToLower().Contains(txt.ToLower()))
                    {
                        datagridvB.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(39, 174, 96);
                        break;
                    }
                }
            }
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            RelativeHumidity humidity = new RelativeHumidity();
            try
            {
                humidity.DateObservation = datePicker.Value;
                humidity.Heur = Convert.ToInt32(comboBoxHeur.SelectedItem.ToString());
                humidity.Sec = (float)Convert.ToDouble(txtSec.Text);
                humidity.Mou = (float)Convert.ToDouble(txtMou.Text);
                humidity.Hum = (float)Convert.ToDouble(txtHum.Text);
                humidity.ThermometreMA = (float)Convert.ToDouble(txtMa.Text);
                humidity.ThermometreMax = (float)Convert.ToDouble(txtMax.Text);
                humidity.ThermometreMoyMaxMin = (float)Convert.ToDouble(txtMoy.Text);
                humidity.ThermometreMin = (float)Convert.ToDouble(txtMin.Text);
                humidity.ThermometreMI = (float)Convert.ToDouble(txtMi.Text);
                humidity.ObservateurId = Convert.ToInt32(comboBoxObs.SelectedItem.ToString().Split(' ')[0]);
                humidity.StationId = Convert.ToInt32(comboBoxStat.SelectedItem.ToString().Split(' ')[0]);

                db.RelativeHumidities.Add(humidity);
                db.SaveChanges();
                RemplireLesGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Vous devez selectionné un station et un observateure");
            }
        }

        private void datagridvHumidity_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtID.Text = datagridvHumidity.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtSec.Text = datagridvHumidity.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtMou.Text = datagridvHumidity.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtHum.Text = datagridvHumidity.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboBoxHeur.Text = datagridvHumidity.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtMax.Text = datagridvHumidity.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtMin.Text = datagridvHumidity.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtMoy.Text = datagridvHumidity.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtMa.Text = datagridvHumidity.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtMi.Text = datagridvHumidity.Rows[e.RowIndex].Cells[9].Value.ToString();
                datePicker.Text = datagridvHumidity.Rows[e.RowIndex].Cells[10].Value.ToString();
            }
        }

        private void BtnModifier_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            RelativeHumidity humidity = db.RelativeHumidities.SingleOrDefault(h => h.RelativeHumidityId == id);
            try
            {
                humidity.DateObservation = datePicker.Value;
                humidity.Heur = Convert.ToInt32(comboBoxHeur.SelectedItem.ToString());
                humidity.Sec = (float)Convert.ToDouble(txtSec.Text);
                humidity.Mou = (float)Convert.ToDouble(txtMou.Text);
                humidity.Hum = (float)Convert.ToDouble(txtHum.Text);
                humidity.ThermometreMA = (float)Convert.ToDouble(txtMa.Text);
                humidity.ThermometreMax = (float)Convert.ToDouble(txtMax.Text);
                humidity.ThermometreMoyMaxMin = (float)Convert.ToDouble(txtMoy.Text);
                humidity.ThermometreMin = (float)Convert.ToDouble(txtMin.Text);
                humidity.ThermometreMI = (float)Convert.ToDouble(txtMi.Text);
                humidity.ObservateurId = Convert.ToInt32(comboBoxObs.SelectedItem.ToString().Split(' ')[0]);
                humidity.StationId = Convert.ToInt32(comboBoxStat.SelectedItem.ToString().Split(' ')[0]);
                db.SaveChanges();
                RemplireLesGrid();
            }
            catch (Exception)
            {

                MessageBox.Show("Vous devez selectionné un station et un observateure");
            }
        }
    }
}
