using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mariani_GestionePrezzi
{
    public partial class FormAggiuntaMagazzino : Form
    {
        private string ingredientName;
        private string filePath = "magazzino.json";

        public FormAggiuntaMagazzino()
        {
            InitializeComponent();

            dataGridView1.Columns.Add("Nome", "Nome");
            dataGridView1.Columns.Add("Quantita", "Quantità");
            dataGridView1.Columns.Add("Prezzo", "Prezzo");
        }

        private void FormAggiuntaMagazzino_Load(object sender, EventArgs e)
        {
            CaricaIngredienti();
        }

        private void CaricaIngredienti()
        {
            // Leggi gli ingredienti dal file JSON
            var ingredienti = Ingredient<string>.DeserializzaDaJSON(filePath);

            // Popola la DataGridView con gli ingredienti
            dataGridView1.Rows.Clear();
            foreach (var ingrediente in ingredienti)
            {
                dataGridView1.Rows.Add(ingrediente.Name, ingrediente.Quantity, ingrediente.Prezzo);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

        private void button2_Click(object sender, EventArgs e)
        {
            FormInput ingredientForm = new FormInput();
            if (ingredientForm.ShowDialog() == DialogResult.OK)
            {
                // Se l'utente ha confermato il nome dell'ingrediente
                ingredientName = ingredientForm.IngredientName;
                // Rimuovi l'ingrediente dal file JSON
                Ingredient<string>.RimuoviDaJSON(filePath, ingredientName);

                // Aggiorna la visualizzazione degli ingredienti
                CaricaIngredienti();
            }

            
        }
    }
}
