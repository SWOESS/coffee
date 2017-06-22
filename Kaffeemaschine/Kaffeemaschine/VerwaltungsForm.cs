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
            var frm = new Form1();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.Show();
            this.Hide();
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            // Data arrays.
            string[] seriesArray = Globals.getIngredientNames();
            int[] pointsArray = Globals.getIngredientIndexes();

            // Set title.
            this.ingredients.Titles.Add("Ingredients");

            // Add series.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                // Add series.
                Series series = this.ingredients.Series.Add(seriesArray[i]);

                // Add point.
                series.Points.Add(pointsArray[i]);
            }
        }
    }
}
