using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Mariani_GestionePrezzi
{
    public partial class FormMenu : Form
    {
        private MyMenu menu;
        private List<Ingredient> listaIngredienti;

        public FormMenu()
        {
            InitializeComponent();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            menu = new MyMenu();
            listaIngredienti = DeserializzaDaJSON("magazzino.json");

            // Popola il ComboBox con gli ingredienti disponibili
            foreach (var ingrediente in listaIngredienti)
            {
                comboBox1.Items.Add(ingrediente.Name);
            }

            // Imposta la DataGridView per le selezioni degli ingredienti
            dataGridView1.Columns.Add("Ingrediente", "Ingrediente");
            dataGridView1.Columns.Add("Quantita", "Quantità");
        }

        private List<Ingredient> DeserializzaDaJSON(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Ingredient>>(json);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product nuovoProdotto = new Product();
            nuovoProdotto.Name = textBox1.Text;
            nuovoProdotto.Price = decimal.Parse(textBox2.Text);

            // Aggiungi gli ingredienti selezionati con le rispettive quantità al nuovo prodotto
            foreach (DataGridViewRow riga in dataGridView1.Rows)
            {
                if (!riga.IsNewRow)
                {
                    string nomeIngrediente = riga.Cells["Ingrediente"].Value.ToString();
                    int quantita = Convert.ToInt32(riga.Cells["Quantita"].Value);

                    if (quantita > 0)
                    {
                        // Cerca l'ingrediente nella listaIngredienti per ottenere il prezzo
                        var ingrediente = listaIngredienti.FirstOrDefault(i => i.Name == nomeIngrediente);
                        if (ingrediente != null)
                        {
                            Ingredient ingredient = new Ingredient(ingrediente.Name, quantita, ingrediente.Price);
                            nuovoProdotto.Ingredients.Add(ingredient);
                        }
                    }
                }
            }

            // Aggiungi il nuovo prodotto a una ricetta
            Recipe recipe = new Recipe("Nuova Ricetta");
            recipe.AddProduct(nuovoProdotto);

            // Aggiungi la nuova ricetta al menu
            menu.AddRecipe(recipe);

            // Salva il menu aggiornato su file JSON
            menu.SaveToFile("menu.json");

            MessageBox.Show("Prodotto aggiunto con successo!", "Brew Bucks");
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.Text = string.Empty;
            dataGridView1.Rows.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Aggiungi l'ingrediente selezionato con la quantità alla DataGridView
            string nomeIngrediente = comboBox1.SelectedItem.ToString();
            int quantita = Convert.ToInt32(textBox2.Text);

            if (quantita > 0)
            {
                dataGridView1.Rows.Add(nomeIngrediente, quantita);
            }
        }
    }
}
