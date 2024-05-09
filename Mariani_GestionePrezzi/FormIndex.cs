using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Mariani_GestionePrezzi
{
    public partial class FormIndex : Form
    {
        
        public FormIndex()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RecipeManager<string> recipeManager = new RecipeManager<string>();

            // Caricamento delle ricette dal file, se presente
            string filePath = "ricette.json";
            recipeManager.LoadRecipesFromFile(filePath);

            // Aggiunta di una nuova ricetta
            Recipe<string> newRecipe = new Recipe<string>("Nuova Ricetta");
            newRecipe.AddIngredient("Ingrediente 1", "Quantità 1", 10);
            newRecipe.AddIngredient("Ingrediente 2", "Quantità 2", 20);
            recipeManager.AddRecipe(newRecipe);

            // Rimozione di una ricetta
            if (recipeManager.Recipes.Count > 0)
            {
                recipeManager.RemoveRecipe(recipeManager.Recipes[0]);
            }

            // Salvataggio delle ricette aggiornate su file
            recipeManager.SaveRecipesToFile(filePath);

            // Visualizzazione di tutte le ricette
            //recipeManager.DisplayAllRecipes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAggiuntaMagazzino nuovoForm = new FormAggiuntaMagazzino();

            nuovoForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormMenu nuovoForm = new FormMenu();

            nuovoForm.Show();
        }
    }
}
