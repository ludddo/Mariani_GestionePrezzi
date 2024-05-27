/*
 * 
 * In questa struttura un "Ingredient" é un componente base, un "Product" é un composite di "Ingredient"
 * e un "Recipe" é un composite di "Product". Infine, un "Menu" é un composite di "Recipe". 
 * 
 */



using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

public class Ingredient
{
    [JsonProperty("nome")]
    public string Name { get; set; }

    [JsonProperty("quantita")]
    public int Quantity { get; set; }

    [JsonProperty("prezzo")]
    public decimal Price { get; set; }

    public Ingredient(string name, int quantity, decimal price)
    {
        Name = name;
        Quantity = quantity;
        Price = price;
    }
}

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public List<Ingredient> Ingredients { get; set; }

    public Product()
    {
        Ingredients = new List<Ingredient>();
    }

    public void AddIngredient(Ingredient ingredient)
    {
        Ingredients.Add(ingredient);
    }
}

public class Recipe
{
    public string Name { get; set; }
    public List<Product> Products { get; set; }

    public Recipe(string name)
    {
        Name = name;
        Products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }
}

public class MyMenu
{
    public List<Recipe> Recipes { get; set; }

    public MyMenu()
    {
        Recipes = new List<Recipe>();
    }

    public void AddRecipe(Recipe recipe)
    {
        Recipes.Add(recipe);
    }

    public void SaveToFile(string filePath)
    {
        string json = JsonConvert.SerializeObject(Recipes, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    public static MyMenu LoadFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("Il file specificato non esiste.", filePath);
        }

        string json = File.ReadAllText(filePath);
        List<Recipe> recipes = JsonConvert.DeserializeObject<List<Recipe>>(json);

        MyMenu menu = new MyMenu();
        menu.Recipes.AddRange(recipes);

        return menu;
    }
}
