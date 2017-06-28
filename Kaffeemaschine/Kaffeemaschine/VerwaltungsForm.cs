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
            //Serie = Reihe von Datenpunkten, die in gewählter Formatierung in einer Chartarea angezeigt werden
            //Serie für Datenanzeige wird erstellt, mit dem namen Füllstand
            Series series = chart1.Series.Add("Füllstand");
            //Die Serie soll ein Balkendiagramm sein
            series.ChartType = SeriesChartType.StackedBar;
            //Die Serie wird zur im Designer erstellen ChartArea per Name hinzugefügt.
            series.ChartArea = "FillChartArea";
            // Data arrays.
            //Arrays mit den Daten zu den Ingredients
            string[] seriesArray = Globals.getIngredientNames();
            int[] pointsArray = Globals.getIngredientIndexes();
            double[] fillArray = Globals.getIngredientFill();
            series.IsValueShownAsLabel = true;

            // Set title
            this.chart1.Titles.Add("Füllstände");
            chart1.Titles[0].Text = "test";
            // Add series.
            //Es wird durch das array geloopt und für jeden Ingredient wird ein Datenpunkt in die Serie eingefügt
            for (int i = 0; i < seriesArray.Length; i++)
            {
                DataPoint p = new DataPoint();
                p.XValue = i;
                p.YValues = fillArray;
                p.Label = seriesArray[i];
                //i ist quasi der Index des Ingredients, die X Achse im Diagramm (immer um eins höher)
                //fillArray[i] ist der Y-Wert des Datenpunkts, Der Füllstand der Ingredients. Dies ist die Länge des Balkens.
                series.Points.AddXY(i, fillArray[i]);        
            }
        }
    }
}
