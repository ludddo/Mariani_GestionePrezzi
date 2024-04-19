using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;

public class Ingredient<T>
{
    public string Name { get; set; }
    public T Quantity { get; set; }
}

public class Recipe<T>
{
    public string Name { get; set; }
    public List<Ingredient<T>> Ingredients { get; set; }

    public Recipe(string name)
    {
        Name = name;
        Ingredients = new List<Ingredient<T>>();
    }

    public void AddIngredient(string name, T quantity)
    {
        Ingredients.Add(new Ingredient<T> { Name = name, Quantity = quantity });
    }

    public override string ToString()
    {
        return Name;
    }
}

public class RecipeManager<T>
{
    public List<Recipe<T>> Recipes { get; set; }

    public RecipeManager()
    {
        Recipes = new List<Recipe<T>>();
    }

    public void AddRecipe(Recipe<T> recipe)
    {
        Recipes.Add(recipe);
    }

    public void RemoveRecipe(Recipe<T> recipe)
    {
        Recipes.Remove(recipe);
    }

    public void SaveRecipesToFile(string filePath)
    {
        string json = JsonConvert.SerializeObject(Recipes, Formatting.Indented);
        File.WriteAllText(filePath, json);
        MessageBox.Show($"\nRicette salvate su '{filePath}'.");
    }

    public void LoadRecipesFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            Recipes = JsonConvert.DeserializeObject<List<Recipe<T>>>(json);
            MessageBox.Show($"\nRicette caricate da '{filePath}'.");
        }
        else
        {
            MessageBox.Show($"\nIl file '{filePath}' non esiste. Nessuna ricetta caricata.");
            Recipes = new List<Recipe<T>>(); // Imposta la lista di ricette su vuota
        }
    }

    public void DisplayAllRecipes()
    {
        MessageBox.Show("Elenco delle ricette:");
        foreach (var recipe in Recipes)
        {
            MessageBox.Show(recipe.Name);
            foreach (var ingredient in recipe.Ingredients)
            {
                MessageBox.Show($"- {ingredient.Name}: {ingredient.Quantity}");
            }
            MessageBox.Show("");
        }
    }
}
