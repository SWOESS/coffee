using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProduktverwaltungmitLog
{
    class Coin
    {
        public double Value { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public Bitmap CoinPicture { get; set; }

        public Coin(double val, int startingStock, string desc, Bitmap valPic)
        {
            this.Value = val;
            this.Stock = startingStock;
            this.Description = desc;
            this.CoinPicture = valPic;
        }
        public void stockToTextFile()
        {
            string path = "..\\magazin.txt";
            File.WriteAllText(path, string.Empty);
            string lines = Value + "\r\n" + Stock + "\r\n" + Description;
            StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine(lines);
            sw.Close();
        }
        public void textFileToStock()
        {
            string path = "..\\magazin.txt";
            try
            {
                StreamReader sr = new StreamReader(path);
                Value = Convert.ToDouble(sr.ReadLine());
                Stock = Convert.ToInt32(sr.ReadLine());
                Description = Convert.ToString(sr.ReadLine());
                sr.Close();
            }
            catch (Exception e)
            {
                ProduktverwaltungmitLog.Logger l = new ProduktverwaltungmitLog.Logger("ChangeIO");
                l.Error(e.Message);
            }
        }
    }
}
