using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Mariani_GestionePrezzi
{
    public partial class FormAggiuntaMagazzino : Form
    {
        // Variabile per memorizzare il nome dell'ingrediente
        private string ingredientName;
        // Percorso del file JSON che contiene i dati del magazzino
        private string filePath = "magazzino.json";

        // Costruttore della form
        public FormAggiuntaMagazzino()
        {
            InitializeComponent();

            // Aggiunge le colonne alla DataGridView per visualizzare gli ingredienti
            dataGridView1.Columns.Add("Nome", "Nome");
            dataGridView1.Columns.Add("Quantita", "Quantità");
            dataGridView1.Columns.Add("Prezzo", "Prezzo");
        }

        // Evento che si verifica quando la form viene caricata
        private void FormAggiuntaMagazzino_Load(object sender, EventArgs e)
        {
            // Carica gli ingredienti dal file JSON e li visualizza nella DataGridView
            CaricaIngredienti();
        }

        // Metodo per caricare gli ingredienti dal file JSON e popolare la DataGridView
        private void CaricaIngredienti()
        {
            // Leggi gli ingredienti dal file JSON
            var ingredienti = DeserializzaDaJSON(filePath);

            // Pulisce le righe esistenti nella DataGridView
            dataGridView1.Rows.Clear();
            // Aggiunge ogni ingrediente come una nuova riga nella DataGridView
            foreach (var ingrediente in ingredienti)
            {
                dataGridView1.Rows.Add(ingrediente.Name, ingrediente.Quantity, ingrediente.Price);
            }
        }

        // Metodo per deserializzare gli ingredienti dal file JSON
        private List<Ingredient> DeserializzaDaJSON(string filePath)
        {
            // Legge tutto il contenuto del file JSON
            string json = File.ReadAllText(filePath);
            // Deserializza il contenuto JSON in una lista di oggetti Ingredient
            return JsonConvert.DeserializeObject<List<Ingredient>>(json);
        }

        // Evento che si verifica quando il bottone per aggiungere un ingrediente viene cliccato
        private void button1_Click(object sender, EventArgs e)
        {
            // Legge i valori dai campi di input
            string nome = textBox1.Text;
            string quantita = textBox2.Text;
            decimal prezzo = decimal.Parse(textBox3.Text);

            // Aggiungi l'ingrediente al file JSON
            Ingredient<string> nuovoIngrediente = new Ingredient<string>(nome, quantita, prezzo);
            nuovoIngrediente.SerializzaInJSON(filePath);

            // Aggiorna la visualizzazione degli ingredienti
            CaricaIngredienti();

            // Cancella i dati inseriti nei campi di input
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        // Evento che si verifica quando il bottone per rimuovere un ingrediente viene cliccato
        private void button2_Click(object sender, EventArgs e)
        {
            // Mostra una nuova form per inserire il nome dell'ingrediente da rimuovere
            FormInput ingredientForm = new FormInput();
            if (ingredientForm.ShowDialog() == DialogResult.OK)
            {
                // Se l'utente ha confermato il nome dell'ingrediente
                ingredientName = ingredientForm.IngredientName;
                // Rimuove l'ingrediente dal file JSON
                Ingredient<string>.RimuoviDaJSON(filePath, ingredientName);

                // Aggiorna la visualizzazione degli ingredienti
                CaricaIngredienti();
            }
        }
    }
}
