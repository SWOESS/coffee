using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProduktverwaltungmitLog
{
    public class globalVarsAndObjects
    {
        Logger FileIOLogger;
        public List<Ingredient> listOfIngredients;
        private List<Product> listOfProducts;
        public Ingredient Sugar;
        public Ingredient Coffee;
        public Ingredient TeaPowder;
        public Ingredient MilkPowder;
        public Ingredient Cocoa;
        public Product Latte;
        public Product Black;
        public Product Tea;
        public Product Chocochhino;
        public void Init()
        {
            listOfIngredients = new List<Ingredient>();
            listOfProducts = new List<Product>();
            Sugar = new Ingredient("Sugar", 100, 2);
            listOfIngredients.Add(Sugar);
            Coffee = new Ingredient("Coffee", 100.00, 1);
            listOfIngredients.Add(Coffee);
            TeaPowder = new Ingredient("TeaPowder", 100.00, 1);
            listOfIngredients.Add(TeaPowder);
            MilkPowder = new Ingredient("MilkPowder", 100.00, 1);
            listOfIngredients.Add(MilkPowder);
            Cocoa = new Ingredient("Cocoa", 100.00, 1);
            listOfIngredients.Add(Cocoa);
            Latte = new Product("Latte", 0.50, new List<Ingredient> { Sugar, Coffee, MilkPowder });
            listOfProducts.Add(Latte);
            Black = new Product("Schwarz", 0.60, new List<Ingredient> {Sugar, Coffee });
            listOfProducts.Add(Black);
            Tea = new Product("Früchtetee", 0.50, new List<Ingredient> {Sugar, TeaPowder });
            listOfProducts.Add(Tea);
            Chocochhino = new Product("ChocoChino", 0.60, new List<Ingredient> {Coffee, Sugar, Cocoa});
            listOfProducts.Add(Chocochhino);
        }

        public void SaveToFile()
        {
            FileIOLogger = new Logger("FileSaveLog");
            string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\saves\\Ingredients.txt";
            FileIOLogger.Information("Saving Ingredient info to \\saves\\Ingredients.txt");
            File.Delete(path);
            (new FileInfo(path)).Directory.Create();
            
            using (StreamWriter w = File.AppendText(path))
            {
                
                foreach (var ing in listOfIngredients)
                {
                    string text = ing.ToString();
                    w.WriteLine(text);
                }
            }


            path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\saves\\Products.txt";
            FileIOLogger.Information("Saving Product info to \\saves\\Products.txt");
            File.Delete(path);
            using (StreamWriter w = File.AppendText(path))
            {

                foreach (var prod in listOfProducts)
                {
                    string text = prod.ToString();
                    w.WriteLine(text);
                }
            }
            
        }
        
        /// <summary>
        /// Loads Ingredients and Products from the file if possible
        /// </summary>
        public void LoadFromFile()
        {
            FileIOLogger = new Logger("FileReadLog");
            //read from file
            string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\saves\\Ingredients.txt";
            if (!File.Exists(path))
            {
                return;
            }
            var lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                listOfIngredients = lines.Select(o => o.Split(';'))
                    .Select(o => new Ingredient(o[0].Trim(),Convert.ToInt32(o[1].Trim()),Convert.ToDouble(o[2].Trim()), Convert.ToInt32(o[3].Trim()))).ToList();
            }
           
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


