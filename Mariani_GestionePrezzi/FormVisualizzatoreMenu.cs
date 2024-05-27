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
    public partial class FormVisualizzatoreMenu : Form
    {
        public FormVisualizzatoreMenu()
        {
            InitializeComponent();
            dataGridViewProdotti.Columns.Add("Nome", "Nome");
            dataGridViewProdotti.Columns.Add("Prezzo", "Prezzo");

            foreach (DataGridViewColumn colonna in dataGridViewProdotti.Columns)
            {
                colonna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void FormVisualizzatoreMenu_Load(object sender, EventArgs e)
        {
            CaricaProdottiConPrezzoFinale();
        }

        private void CaricaProdottiConPrezzoFinale()
        {
            string filePath = "prodottiConPrezzoFinale.json";
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                List<ProdottoConPrezzoFinale> prodottiConPrezzoFinale = JsonConvert.DeserializeObject<List<ProdottoConPrezzoFinale>>(json);

                dataGridViewProdotti.Rows.Clear();
                foreach (var prodotto in prodottiConPrezzoFinale)
                {
                    dataGridViewProdotti.Rows.Add(prodotto.Nome, prodotto.PrezzoFinale);
                }

                dataGridViewProdotti.AutoResizeColumns();
            }
        }
    }
}
