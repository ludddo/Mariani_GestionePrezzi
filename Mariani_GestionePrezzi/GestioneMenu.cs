using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariani_GestionePrezzi
{
    internal class GestioneMenu
    {
        public class ProductIngredient
        {
            public string IngredientName { get; set; }
            public int Quantity { get; set; }
        }

        public class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public List<ProductIngredient> Ingredients { get; set; }

            public Product()
            {
                Ingredients = new List<ProductIngredient>();
            }
        }

        public class Menu
        {
            public List<Product> Products { get; set; }

            public Menu()
            {
                Products = new List<Product>();
            }

            public void AddProduct(Product product)
            {
                Products.Add(product);
            }

            public void SaveToFile(string filePath)
            {
                string json = JsonConvert.SerializeObject(Products, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }

            public static Menu LoadFromFile(string filePath)
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("Il file specificato non esiste.", filePath);
                }

                string json = File.ReadAllText(filePath);
                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);

                Menu menu = new Menu();
                menu.Products.AddRange(products);

                return menu;
            }
        }
    }
}
