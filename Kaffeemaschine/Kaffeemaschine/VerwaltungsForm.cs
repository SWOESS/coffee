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
            //Series series = chart1.Series.Add("Füllstand");
            //Die Serie soll ein Balkendiagramm sein
            //series.ChartType = SeriesChartType.StackedBar;
            //Die Serie wird zur im Designer erstellen ChartArea per Name hinzugefügt.
            //series.ChartArea = "FillChartArea";
            // Data arrays.
            //Arrays mit den Daten zu den Ingredients
            string[] seriesArray = Globals.getIngredientNames();
            int[] pointsArray = Globals.getIngredientIndexes();
            double[] fillArray = Globals.getIngredientFill();
            //series.IsValueShownAsLabel = true;

            // Liienin in chart ausblenden
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            int i = 0;
            foreach (var ingre in Globals.listOfIngredients)
            {
                Series s = new Series();
                s.IsValueShownAsLabel = true;
                s.IsVisibleInLegend = true;

                chart1.Series.Add(ingre.Name);
                chart1.Series[ingre.Name].ChartType = SeriesChartType.Column;
                chart1.Series[ingre.Name].Points.AddY(100);
                chart1.Series[ingre.Name].ChartArea = "FillChartArea";

                double ymin =0;
                double ymax = Globals.Sugar.LvlMax;

                chart1.ChartAreas[0].AxisY.ScaleView.Position = ymin;
                chart1.ChartAreas[0].AxisY.ScaleView.Size = ymax - ymin;

                DataPoint p = new DataPoint();
                    p.XValue = i;
                    double[] xyz = new double[1];
                    xyz[0] = fillArray[i]; 
                    p.YValues = xyz;
                    p.Label = seriesArray[i];
                    //i ist quasi der Index des Ingredients, die X Achse im Diagramm (immer um eins höher)
                    //fillArray[i] ist der Y-Wert des Datenpunkts, Der Füllstand der Ingredients. Dies ist die Länge des Balkens.
                    s.Points.AddXY(i, fillArray[i]);
                i++;
            }


            //Color change
            chart1.Palette = ChartColorPalette.Pastel;
            // Set title
            this.chart1.Titles.Add("Füllstände");

                // Add series.
                //Es wird durch das array geloopt und für jeden Ingredient wird ein Datenpunkt in die Serie eingefügt
                
            }
        }
}
