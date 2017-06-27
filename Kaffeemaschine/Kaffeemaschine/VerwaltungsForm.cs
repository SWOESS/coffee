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
            Series series = new Series();
            ingredients.Series.Add(series);
            // Data arrays.
            string[] seriesArray = Globals.getIngredientNames();
            int[] pointsArray = Globals.getIngredientIndexes();

            // Set title.
            this.ingredients.Titles.Add("Füllstände");

            // Add series.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                DataPoint p = new DataPoint(series);
                p.Label = seriesArray[i];
                p.SetValueXY(i, 4);
            }
            ingredients.Update();
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
    }
}
