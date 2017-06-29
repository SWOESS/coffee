using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProduktverwaltungmitLog
{
     public class Coin
    {
        public Coin()
        {
            textFileToStock();
        }
        public int Coin01Stock { get; set; }
        public int Coin02Stock { get; set; }
        public int Coin05Stock { get; set; }
        public int Coin1Stock { get; set; }
        public int Coin2Stock { get; set; }

        public void stockToTextFile()
        {
            string path = "..\\magazin.txt";
            File.WriteAllText(path, string.Empty);
            string lines = Coin01Stock + "\r\n" + Coin02Stock + "\r\n" + Coin05Stock + "\r\n" + Coin1Stock + "\r\n" + Coin2Stock;
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
                this.Coin01Stock = Convert.ToInt32(sr.ReadLine());
                this.Coin02Stock = Convert.ToInt32(sr.ReadLine());
                this.Coin05Stock = Convert.ToInt32(sr.ReadLine());
                this.Coin1Stock = Convert.ToInt32(sr.ReadLine());
                this.Coin2Stock = Convert.ToInt32(sr.ReadLine());

                sr.Close();
            }
            catch (Exception e)
            {
                Logger l = new Logger("ChangeIO");
                l.Error(e.Message);
            }
        }

    }
      
    }
