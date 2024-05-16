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
            menu = new GestioneMenu.Menu();
            listaIngredienti = Ingredient<string>.DeserializzaDaJSON("magazzino.json");


            // Popola il ComboBox con gli ingredienti disponibili
            foreach (var ingrediente in listaIngredienti)
            {
                comboBox1.Items.Add(ingrediente.Name);
            }

            // Imposta la DataGridView per le selezioni degli ingredienti
            dataGridView1.Columns.Add("Ingrediente", "Ingrediente");
            dataGridView1.Columns.Add("Quantita", "Quantità");
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
                        ProductIngredient ingredient = new ProductIngredient
                        {
                            IngredientName = nomeIngrediente,
                            Quantity = quantita
                        };

                        nuovoProdotto.Ingredients.Add(ingredient);
                    }
                }
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
