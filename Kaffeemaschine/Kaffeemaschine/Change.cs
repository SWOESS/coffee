using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduktverwaltungmitLog
{
    public class Change
    {
        public Change(double startingAmount)
        {
            Credit = startingAmount;
        }
        public double Credit { get; private set; }
        
        public void Increase(double amount)
        {
            this.Credit += amount;
        }
        /// <summary>
        /// Tries to Deplete the Credit by an amount, return true if successful and false if the Credit is insufficient
        /// </summary>
        /// <param name="amount">Amount to deplete</param>
        /// <returns></returns>
        public bool Deplete(double amount)
        {
            if (this.Credit < amount)
            {
                return false;
            }
            else
            {
                this.Credit -= amount;
                return true;
            }
        }
    }
}
