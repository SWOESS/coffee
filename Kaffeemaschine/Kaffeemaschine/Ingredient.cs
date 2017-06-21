using System;

namespace ProduktverwaltungmitLog
{
    public class Ingredient
    {
        /// <summary>
        /// Create a new Instance of the Class.
        /// </summary>
        /// <param name="ingredientname">Name of the Ingredient</param>
        /// <param name="ingredientmaxfill">Maximum Fill of Ingredient (Units)</param>
        /// <param name="depleteUnits">Units depleted per use</param>
        public Ingredient(string ingredientname, double ingredientmaxfill, int depleteUnits)
        {
            this.Name = ingredientname;
            this.LvlMax = ingredientmaxfill;
            this.Level = LvlMax;
            this.depleteunits = depleteUnits;
            this.Refill();
        }

        public Ingredient(string ingredientname, int level, double ingredientmaxfill, int depleteUnits)
        {
            this.Name = ingredientname;
            this.LvlMax = ingredientmaxfill;
            this.Level = level;
            this.depleteunits = depleteUnits;
            this.Refill();
        }
        
        //fields
        private int depleteunits;
        private Logger IngredientLogger = new Logger("IngredientLog");
        public int Depleteunits { get { return depleteunits; } set { this.depleteunits = value; } }
        public double Level { get; set; }

        public string Name { get; set; }

        public double LvlMax { get; set; }
        //TODO: Add ProgressBar for reference
        //Methods

        /// <summary>
        /// drain the Fill of the Ingredient by Depleteunits Value
        /// also checks if the Fill is low or empty and logs as such
        /// </summary>
        public void DepleteLevel()
        {
            if (this.Level <= 10 && this.Level > 1)
            {
                IngredientLogger.Information("Füllstand von " + this.Name + " auf unter 10%.");
            }
            else if (this.Level <= 0)
            {
                throw new IngredientEmptyException(this);
            }
            if (this.Level - this.depleteunits >= 0)
            {
                this.Level -= depleteunits;
            }
            else
            {
                this.Level = 0;
            }
        }

        /// <summary>
        /// completely refill the Ingredient to the maximum.
        /// </summary>
        public void Refill()
        {
            this.Level = LvlMax;
        }

        /// <summary>
        /// Refill the Ingredient by a percentage
        /// </summary>
        /// <param name="percentage">percentage of maximum to refill</param>
        public void Refill(int percentage)
        {
            this.Level += LvlMax * percentage;
            if (this.Level > LvlMax)
            {
                this.Level = LvlMax;
            }
        }

        /// <summary>
        /// Refill the Ingredient by an amount of Units
        /// </summary>
        /// <param name="units">Amount of Units to refill</param>
        public void Refill(double units)
        {
            this.Level += units;
            if (this.Level > LvlMax)
            {
                this.Level = LvlMax;
            }
        }

        public override string ToString()
        {
            return this.Name + ";" + this.Level + ";" + this.LvlMax + ";" + this.depleteunits + ";";
        }
    }
    public class IngredientEmptyException : Exception
    {
        public Ingredient Ing { get; set; }

        public IngredientEmptyException(Ingredient i)
        {
            this.Ing = i;
        }
    }
}
