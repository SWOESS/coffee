using System.Collections.Generic;

namespace ProduktverwaltungmitLog
{
    /// <summary>
    /// Klasse Product
    /// </summary>
    public class Product
    {
        private Logger ProductLogger = new Logger("ProductLog");
        /// <summary>
        /// Erstellt eine neue Instanz der Klasse Product
        /// </summary>
        /// <param name="pName">gewünschter Name des Products</param>
        /// <param name="price">ewünschter Preis des Products in Euro</param>
        /// <param name="ListOfIngredients">Eine Liste der Zutaten, die das Product enthalten soll</param>
        public Product(string pName, double price, List<Ingredient> ListOfIngredients)
        {
            this.Name = pName;
            this.price = price;
            this.Ingredients = ListOfIngredients;

            
        }

        public List<Ingredient> Ingredients = new List<Ingredient>();
        private double price;
        public string Name;

        /// <summary>
        /// "macht" eine Einheit des Products, und zieht dabei den Füllstand aller Ingredients ab.
        /// </summary>
        public void Make()
        {
            try
            {
                foreach (var ing in Ingredients)
                {
                    if (ing.Depleteunits > 0)
                    {
                        //Vom Ingredient Füllstand wird abgezogen.
                        ing.DepleteLevel();
                    }
                }
            }
            catch (IngredientEmptyException IngEmptyExc)
            {
                string error = IngEmptyExc.Ing.Name + " empty";
                ProductLogger.Error(error);
                throw IngEmptyExc;
            }
        }

        public override string ToString()
        {
            string returnValue = this.Name + ";" + this.price.ToString() + ";";
            foreach (var ing in this.Ingredients)
            {
                returnValue += "," + ing.Name;
            }
            return returnValue;
        }
    }
}
