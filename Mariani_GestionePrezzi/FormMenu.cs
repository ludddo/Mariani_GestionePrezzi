using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Mariani_GestionePrezzi.GestioneMenu;
using System.IO;

namespace Mariani_GestionePrezzi
{
    public partial class FormMenu : Form
    {
        private GestioneMenu.Menu menu;
        private List<Ingredient<string>> listaIngredienti;

        public FormMenu()
        {
            InitializeComponent();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            // Carica il menu e la lista degli ingredienti dal file JSON
            menu = GestioneMenu.Menu.LoadFromFile("menu.json");
            listaIngredienti = Ingredient<string>.DeserializzaDaJSON("magazzino.json");

            // Popola la DataGridView con la lista degli ingredienti
            dataGridView1.Rows.Clear();
            foreach (var ingrediente in listaIngredienti)
            {
                dataGridView1.Rows.Add(ingrediente.Name, ingrediente.Quantity, ingrediente.Prezzo);
            }
        }

        private void buttonAggiungiProdotto_Click(object sender, EventArgs e)
        {
            // Crea un nuovo prodotto
            Product nuovoProdotto = new Product();
            nuovoProdotto.Name = textBox1.Text;
            nuovoProdotto.Price = decimal.Parse(textBox2.Text);

            // Aggiungi gli ingredienti selezionati alla lista degli ingredienti del nuovo prodotto
            foreach (DataGridViewRow riga in dataGridView1.SelectedRows)
            {
                string nomeIngrediente = riga.Cells[0].Value.ToString();
                int quantita = int.Parse(riga.Cells[1].Value.ToString());
                decimal prezzo = decimal.Parse(riga.Cells[2].Value.ToString());

                ProductIngredient ingredient = new ProductIngredient
                {
                    IngredientName = nomeIngrediente,
                    Quantity = quantita
                };

                nuovoProdotto.Ingredients.Add(ingredient);
            }

            // Aggiungi il nuovo prodotto al menu
            menu.AddProduct(nuovoProdotto);

            // Salva il menu aggiornato su file JSON
            menu.SaveToFile("menu.json");

            // Aggiorna la DataGridView dei prodotti nel form principale
            //(Owner as FormPrincipale).CaricaProdotti();

            // Chiudi il form corrente
            //Close();
        }
    }
}
