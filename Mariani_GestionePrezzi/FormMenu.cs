using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Mariani_GestionePrezzi
{
    // Definizione della classe parziale FormMenu che eredita da Form
    public partial class FormMenu : Form
    {
        // Dichiarazioni delle variabili
        private MyMenu menu;  // Oggetto per gestire il menu
        private List<Ingredient> listaIngredienti;  // Lista degli ingredienti disponibili

        // Costruttore della form
        public FormMenu()
        {
            InitializeComponent();
        }

        // Evento che si verifica quando la form viene caricata
        private void FormMenu_Load(object sender, EventArgs e)
        {
            menu = new MyMenu();  // Inizializza il menu
            listaIngredienti = DeserializzaDaJSON("magazzino.json");  // Carica gli ingredienti dal file JSON

            // Popola il ComboBox con i nomi degli ingredienti disponibili
            foreach (var ingrediente in listaIngredienti)
            {
                comboBox1.Items.Add(ingrediente.Name);
            }

            // Imposta le colonne della DataGridView per gli ingredienti e le quantità
            dataGridView1.Columns.Add("Ingrediente", "Ingrediente");
            dataGridView1.Columns.Add("Quantita", "Quantità");

            // Carica il menu dal file JSON se esiste, altrimenti crea un nuovo menu
            string filePath = "menu.json";
            if (File.Exists(filePath))
            {
                menu = MyMenu.LoadFromFile(filePath);
            }
            else
            {
                menu = new MyMenu();
            }
        }

        // Metodo per deserializzare la lista degli ingredienti da un file JSON
        private List<Ingredient> DeserializzaDaJSON(string filePath)
        {
            string json = File.ReadAllText(filePath);  // Legge il contenuto del file
            return JsonConvert.DeserializeObject<List<Ingredient>>(json);  // Deserializza il contenuto in una lista di Ingredient
        }

        // Evento che si verifica quando il bottone per aggiungere un prodotto viene cliccato
        private void button1_Click(object sender, EventArgs e)
        {
            Product nuovoProdotto = new Product();  // Crea un nuovo prodotto
            nuovoProdotto.Name = textBox1.Text;  // Imposta il nome del prodotto
            nuovoProdotto.Price = decimal.Parse(textBox2.Text);  // Imposta il prezzo del prodotto

            // Aggiungi gli ingredienti selezionati con le rispettive quantità al nuovo prodotto
            foreach (DataGridViewRow riga in dataGridView1.Rows)
            {
                if (!riga.IsNewRow)
                {
                    string nomeIngrediente = riga.Cells["Ingrediente"].Value.ToString();  // Nome dell'ingrediente
                    int quantita = Convert.ToInt32(riga.Cells["Quantita"].Value);  // Quantità dell'ingrediente

                    if (quantita > 0)
                    {
                        // Cerca l'ingrediente nella listaIngredienti per ottenere il prezzo
                        var ingrediente = listaIngredienti.FirstOrDefault(i => i.Name == nomeIngrediente);
                        if (ingrediente != null)
                        {
                            // Crea un nuovo oggetto Ingredient con i dati dell'ingrediente e aggiungilo al prodotto
                            Ingredient ingredient = new Ingredient(ingrediente.Name, quantita, ingrediente.Price);
                            nuovoProdotto.Ingredients.Add(ingredient);
                        }
                    }
                }
            }

            // Crea una nuova ricetta e aggiungi il prodotto
            Recipe recipe = new Recipe("Ricetta");
            recipe.AddProduct(nuovoProdotto);

            // Aggiungi la nuova ricetta al menu
            menu.AddRecipe(recipe);

            // Salva il menu aggiornato su file JSON
            menu.SaveToFile("menu.json");

            // Mostra un messaggio di conferma
            MessageBox.Show("Prodotto aggiunto con successo!", "Brew Bucks");

            // Pulisce i campi di input
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.Text = string.Empty;
            dataGridView1.Rows.Clear();
        }

        // Evento che si verifica quando il bottone per aggiungere un ingrediente alla lista viene cliccato
        private void button2_Click(object sender, EventArgs e)
        {
            // Aggiungi l'ingrediente selezionato con la quantità alla DataGridView
            string nomeIngrediente = comboBox1.SelectedItem.ToString();  // Nome dell'ingrediente selezionato
            int quantita = Convert.ToInt32(textBox2.Text);  // Quantità dell'ingrediente

            if (quantita > 0)
            {
                // Aggiungi una nuova riga alla DataGridView con il nome e la quantità dell'ingrediente
                dataGridView1.Rows.Add(nomeIngrediente, quantita);
            }
        }
    }
}
