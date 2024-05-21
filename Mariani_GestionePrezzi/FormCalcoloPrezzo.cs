using Newtonsoft.Json;
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
    public partial class FormCalcoloPrezzo : Form
    {

        private GestioneMenu.Menu menu;
        private List<Ingredient<string>> listaIngredienti;

        public FormCalcoloPrezzo()
        {
            InitializeComponent();
            CaricaIngredienti();
        }

        private void CaricaIngredienti()
        {
            // Carica la lista degli ingredienti dal file JSON
            string json = File.ReadAllText("magazzino.json");
            listaIngredienti = JsonConvert.DeserializeObject<List<Ingredient<string>>>(json);
        }

        private void FormCalcoloPrezzo_Load(object sender, EventArgs e)
        {
            // Carica il menu dal file JSON
            menu = GestioneMenu.Menu.LoadFromFile("menu.json");

            // Popola il ComboBox con i nomi dei prodotti disponibili
            foreach (var prodotto in menu.Products)
            {
                comboBoxProdotti.Items.Add(prodotto.Name);
            }
        }

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
            var prodotto = menu.Products.FirstOrDefault(p => p.Name == nomeProdotto);

            if (prodotto == null)
            {
                MessageBox.Show("Prodotto non trovato.");
                return;
            }

            // Calcola il costo totale degli ingredienti
            decimal costoTotale = 0;
            foreach (var ingrediente in prodotto.Ingredients)
            {
                var ingredientInfo = listaIngredienti.FirstOrDefault(i => i.Name == ingrediente.IngredientName);
                if (ingredientInfo != null)
                {
                    // Calcola il costo proporzionale dell'ingrediente
                    decimal costoIngrediente = ingredientInfo.Prezzo * (ingrediente.Quantity / decimal.Parse(ingredientInfo.Quantity));

                    costoTotale += costoIngrediente;
                }
            }

            // Calcola il prezzo finale applicando il margine di guadagno
            decimal prezzoFinale = costoTotale * (1 + margine / 100);
            labelPrezzoFinale.Text = $"Prezzo finale: {prezzoFinale:C}";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Verifica che il prezzo finale sia stato calcolato
            if (string.IsNullOrWhiteSpace(labelPrezzoFinale.Text))
            {
                MessageBox.Show("Devi prima calcolare il prezzo finale del prodotto.");
                return;
            }

            // Crea un nuovo oggetto per il prodotto con il prezzo finale
            ProdottoConPrezzoFinale prodottoConPrezzoFinale = new ProdottoConPrezzoFinale
            {
                Nome = comboBoxProdotti.SelectedItem.ToString(),
                PrezzoFinale = decimal.Parse(labelPrezzoFinale.Text.Replace("Prezzo finale: ", "").Replace("€", ""))
            };

            // Serializza il prodotto con il prezzo finale in formato JSON
            string json = JsonConvert.SerializeObject(prodottoConPrezzoFinale, Formatting.Indented);

            // Salva il JSON in un file
            File.WriteAllText("prodotto_con_prezzo_finale.json", json);

            MessageBox.Show("Prodotto salvato con successo.");
        }
    }
}


public class ProdottoConPrezzoFinale
{
    public string Nome { get; set; }
    public decimal PrezzoFinale { get; set; }
}

