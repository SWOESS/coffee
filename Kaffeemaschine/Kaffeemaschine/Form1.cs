using ProduktverwaltungmitLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kaffeemaschine
{
    public partial class Form1 : Form
    {
        //Instanz der Klasse, über Globals.XYZ kann man die einzelnen Produkte ansprechen
        public globalVarsAndObjects Globals = new globalVarsAndObjects();
        public Form1()
        {
            InitializeComponent();
            lCredit.Text = "€2.00";
        }

        public void ProductIconClicked(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new VerwaltungsForm();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            //frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            this.Hide();
        }
    }
}
