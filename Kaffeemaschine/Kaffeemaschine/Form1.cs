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
        PictureBox loadingGif;
        bool bSLG;
        Timer t;
        public Form1(bool showLoadingGif)
        {
            bSLG = showLoadingGif;
            InitializeComponent();
            Globals.Init();
            lCredit.Text = Globals.UserChange.Credit.ToString() + "€";
        }

        public void ProductIconClicked(object sender, EventArgs e)
        {
            foreach (Product item in Globals.listOfProducts)
            {
                if (item.Name == (sender as PictureBox).Tag.ToString())
                {
                    MessageBox.Show(item.Name + " wird gemacht");
                    //item.Make();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new VerwaltungsForm(Globals);
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            //frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            this.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name != this.Name)
                    f.Close();
            }
        }
        //adds a picturebox to the form and initializes a timer to hide the gif after x time and show the panel
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!bSLG)
            {
                return;
            }
            this.BackColor = Color.FromArgb(241,250,254);
            tableLayoutPanel1.BackColor = Color.FromArgb(241, 250, 254);
            tableLayoutPanel1.Visible = false;
            loadingGif = new PictureBox();
            loadingGif.Location = new Point(0, 0);
           
            loadingGif.Image = Properties.Resources.loading;
            loadingGif.SizeMode = PictureBoxSizeMode.Zoom;
            loadingGif.Size = new Size(this.Width,this.Height);
            this.Controls.Add(loadingGif);
            t = new Timer();
            t.Interval = 2500;
            t.Tick += t_tick;
            t.Start();
        }
        private void t_tick(object sender, EventArgs e)
        {
            loadingGif.Visible = false;
            tableLayoutPanel1.Visible = true;
            t.Stop();
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }
    }
}
