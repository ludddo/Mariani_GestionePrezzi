using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Mariani_GestionePrezzi
{
    public partial class FormCalcoloPrezzo : Form
    {
        // Variabile per memorizzare il menu
        private MyMenu menu;
        // Lista di ingredienti caricati dal file JSON
        private List<Ingredient> listaIngredienti;
        // Lista di prodotti con i prezzi finali calcolati
        private List<ProdottoConPrezzoFinale> prodottiConPrezzoFinale;

        // Costruttore della form
        public FormCalcoloPrezzo()
        {
            InitializeComponent();
            CaricaIngredienti();
            CaricaProdottiConPrezzoFinale();
        }

        // Metodo per caricare gli ingredienti dal file JSON
        private void CaricaIngredienti()
        {
            // Legge il contenuto del file JSON e deserializza in una lista di Ingredient
            string json = File.ReadAllText("magazzino.json");
            listaIngredienti = JsonConvert.DeserializeObject<List<Ingredient>>(json);
        }

        // Metodo per caricare i prodotti con i prezzi finali dal file JSON
        private void CaricaProdottiConPrezzoFinale()
        {
            string filePath = "prodottiConPrezzoFinale.json";
            // Se il file esiste, legge il contenuto e deserializza in una lista di ProdottoConPrezzoFinale
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                prodottiConPrezzoFinale = JsonConvert.DeserializeObject<List<ProdottoConPrezzoFinale>>(json);
            }
            else
            {
                // Se il file non esiste, inizializza una lista vuota
                prodottiConPrezzoFinale = new List<ProdottoConPrezzoFinale>();
            }
        }

        // Evento che si verifica quando la form viene caricata
        private void FormCalcoloPrezzo_Load(object sender, EventArgs e)
        {
            // Carica il menu dal file JSON
            menu = MyMenu.LoadFromFile("menu.json");

            // Popola il ComboBox con i nomi dei prodotti disponibili
            foreach (var recipe in menu.Recipes)
            {
                foreach (var product in recipe.Products)
                {
                    comboBoxProdotti.Items.Add(product.Name);
                }
            }
        }

        // Evento che si verifica quando il bottone per calcolare il prezzo viene cliccato
        private void buttonCalcolaPrezzo_Click_1(object sender, EventArgs e)
        {
            // Verifica che un prodotto sia selezionato
            if (comboBoxProdotti.SelectedIndex == -1)
            {
                MessageBox.Show("Seleziona un prodotto.");
                return;
            }

            // Verifica che il campo del margine non sia vuoto
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Il campo del margine è vuoto. Inserisci un margine valido.");
                return;
            }

            // Verifica il valore effettivo del testo del TextBox
            string margineText = textBox1.Text.Trim();
            if (!decimal.TryParse(margineText, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out decimal margine))
            {
                MessageBox.Show("Inserisci un margine valido.");
                return;
            }

            // Verifica che il margine sia positivo
            if (margine < 0)
            {
                MessageBox.Show("Il margine deve essere un valore positivo.");
                return;
            }

            // Trova il prodotto selezionato
            string nomeProdotto = comboBoxProdotti.SelectedItem.ToString();
            Product prodotto = null;
            foreach (var recipe in menu.Recipes)
            {
                prodotto = recipe.Products.FirstOrDefault(p => p.Name == nomeProdotto);
                if (prodotto != null)
                {
                    break;
                }
            }

            // Se il prodotto non viene trovato, mostra un messaggio di errore
            if (prodotto == null)
            {
                MessageBox.Show("Prodotto non trovato.");
                return;
            }

            // Calcola il costo totale degli ingredienti
            decimal costoTotale = 0;
            foreach (var ingrediente in prodotto.Ingredients)
            {
                // Trova l'ingrediente nella lista degli ingredienti caricati
                var ingredientInfo = listaIngredienti.FirstOrDefault(i => i.Name == ingrediente.Name);
                if (ingredientInfo != null)
                {
                    // Calcola il costo proporzionale dell'ingrediente
                    decimal costoIngrediente = ingredientInfo.Price * (ingrediente.Quantity / (decimal)ingredientInfo.Quantity);
                    costoTotale += costoIngrediente;
                }
            }

            // Calcola il prezzo finale applicando il margine di guadagno
            decimal prezzoFinale = costoTotale * (1 + margine / 100);
            labelPrezzoFinale.Text = $"Prezzo finale: {prezzoFinale:C}";
        }

        // Evento che si verifica quando il bottone per salvare il prezzo finale viene cliccato
        private void button1_Click(object sender, EventArgs e)
        {
            // Legge il nome del prodotto selezionato
            string nomeProdotto = comboBoxProdotti.SelectedItem.ToString();
            // Estrae il prezzo finale dal label
            decimal prezzoFinale = decimal.Parse(labelPrezzoFinale.Text.Replace("Prezzo finale: ", string.Empty).Replace("€", string.Empty));

            // Crea un nuovo oggetto ProdottoConPrezzoFinale
            ProdottoConPrezzoFinale prodottoConPrezzoFinale = new ProdottoConPrezzoFinale
            {
                Nome = nomeProdotto,
                PrezzoFinale = prezzoFinale
            };

            // Aggiunge il prodotto con il prezzo finale alla lista
            prodottiConPrezzoFinale.Add(prodottoConPrezzoFinale);

            // Serializza la lista aggiornata in JSON e la scrive nel file
            string json = JsonConvert.SerializeObject(prodottiConPrezzoFinale, Formatting.Indented);
            File.WriteAllText("prodottiConPrezzoFinale.json", json);

            // Mostra un messaggio di conferma
            MessageBox.Show("Prodotto salvato con successo.");
        }
    }
}

// Classe per rappresentare un prodotto con il prezzo finale
public class ProdottoConPrezzoFinale
{
    public string Nome { get; set; } // Nome del prodotto
    public decimal PrezzoFinale { get; set; } // Prezzo finale del prodotto
}
