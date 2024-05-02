using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;

public class Ingredient<T>
{
    [JsonProperty("nome")]
    public string Name { get; set; }

    [JsonProperty("quantita")]
    public T Quantity { get; set; }

    [JsonProperty("prezzo")]
    public decimal Prezzo { get; set; }

    
    public Ingredient() { }

    // Costruttore per inizializzare l'oggetto Ingrediente con i valori desiderati
    public Ingredient(string nome, T quantita, decimal prezzo)
    {
        Name = nome;
        Quantity = quantita;
        Prezzo = prezzo;
    }

    // Metodo per serializzare l'oggetto in formato JSON
    public void SerializzaInJSON(string percorsoFile)
    {
        List<Ingredient<T>> listaIngredienti;

        // Se il file JSON esiste, leggi il contenuto e deserializzalo
        if (File.Exists(percorsoFile))
        {
            string json = File.ReadAllText(percorsoFile);
            listaIngredienti = JsonConvert.DeserializeObject<List<Ingredient<T>>>(json);
        }
        else
        {
            listaIngredienti = new List<Ingredient<T>>();
        }

        // Aggiungi il nuovo ingrediente alla lista
        listaIngredienti.Add(this);

        // Serializza la lista degli ingredienti in formato JSON indentato
        string jsonIndentato = JsonConvert.SerializeObject(listaIngredienti, Formatting.Indented);

        // Scrivi il JSON indentato nel file
        File.WriteAllText(percorsoFile, jsonIndentato);
    }

    // Metodo statico per deserializzare un'istanza di Ingrediente da una stringa JSON
    public static Ingredient<T> DeserializzaDaJSON(string percorsoFile)
    {
        string json = File.ReadAllText(percorsoFile);
        return JsonConvert.DeserializeObject<Ingredient<T>>(json);
    }

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

    public void AddIngredient(string name, T quantity, decimal prezzo)
    {
        Ingredients.Add(new Ingredient<T> { Name = name, Quantity = quantity, Prezzo = prezzo});
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
