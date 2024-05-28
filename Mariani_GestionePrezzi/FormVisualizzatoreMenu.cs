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
    // Definizione della classe parziale FormVisualizzatoreMenu che eredita da Form
    public partial class FormVisualizzatoreMenu : Form
    {
        // Costruttore della form
        public FormVisualizzatoreMenu()
        {
            InitializeComponent();

            // Aggiunge le colonne "Nome" e "Prezzo" alla DataGridView
            dataGridViewProdotti.Columns.Add("Nome", "Nome");
            dataGridViewProdotti.Columns.Add("Prezzo", "Prezzo");

            // Imposta la modalità di ridimensionamento automatico delle colonne in base al contenuto
            foreach (DataGridViewColumn colonna in dataGridViewProdotti.Columns)
            {
                colonna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        // Evento che si verifica quando la form viene caricata
        private void FormVisualizzatoreMenu_Load(object sender, EventArgs e)
        {
            CaricaProdottiConPrezzoFinale();  // Carica i prodotti con il loro prezzo finale dal file JSON
        }

        // Metodo per caricare i prodotti con il loro prezzo finale dal file JSON
        private void CaricaProdottiConPrezzoFinale()
        {
            string filePath = "prodottiConPrezzoFinale.json";  // Percorso del file JSON
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);  // Legge il contenuto del file JSON
                List<ProdottoConPrezzoFinale> prodottiConPrezzoFinale = JsonConvert.DeserializeObject<List<ProdottoConPrezzoFinale>>(json);  // Deserializza il contenuto in una lista di ProdottoConPrezzoFinale

                dataGridViewProdotti.Rows.Clear();  // Cancella tutte le righe esistenti nella DataGridView
                foreach (var prodotto in prodottiConPrezzoFinale)
                {
                    // Aggiunge una nuova riga alla DataGridView con il nome e il prezzo finale del prodotto
                    dataGridViewProdotti.Rows.Add(prodotto.Nome, prodotto.PrezzoFinale);
                }

                dataGridViewProdotti.AutoResizeColumns();  // Ridimensiona automaticamente le colonne in base al contenuto
            }
        }
    }
}
