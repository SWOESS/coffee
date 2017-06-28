using System;
using ProduktverwaltungmitLog;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Kaffeemaschine
{
    public partial class VerwaltungsForm : Form
    {
        globalVarsAndObjects Globals;
        public VerwaltungsForm(globalVarsAndObjects globals)
        {
            InitializeComponent();
            Globals = globals;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new Form1(false);
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.Show();
            this.Hide();
        }

        private void chart1_Click(object sender, EventArgs e)
        {
        }

        private void VerwaltungsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name != this.Name)
                    f.Close();
            }
        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }

        private void VerwaltungsForm_Load(object sender, EventArgs e)
        {
            Series series = chart1.Series.Add("Füllstand");
            series.ChartType = SeriesChartType.Bar;
            series.ChartArea = "FillChartArea";
            // Data arrays.
            string[] seriesArray = Globals.getIngredientNames();
            int[] pointsArray = Globals.getIngredientIndexes();
            double[] fillArray = Globals.getIngredientFill();
            // Set title.
            this.chart1.Titles.Add("Füllstände");
            chart1.Titles[0].Text = "test";
            // Add series.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                series.Points.AddXY(i, fillArray[i]);
                /*
                DataPoint p = new DataPoint(series);
                p.Label = seriesArray[i];
                p.SetValueXY(i, 4);
                */        
            }
        }
    }
}
