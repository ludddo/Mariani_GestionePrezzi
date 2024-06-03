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
        }

        // Evento che si verifica quando la form viene caricata
        private void FormVisualizzatoreMenu_Load(object sender, EventArgs e)
        {
            CaricaProdottiConPrezzoFinale();  // Carica i prodotti con il loro prezzo finale dal file JSON
        }

        // Metodo per caricare i prodotti con il loro prezzo finale dal file JSON
        private void CaricaProdottiConPrezzoFinale()
        {
            string filePath = "prodottiConPrezzoFinale.json";
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                List<ProdottoConPrezzoFinale> prodottiConPrezzoFinale = JsonConvert.DeserializeObject<List<ProdottoConPrezzoFinale>>(json);

                GeneraCSS();  // Genera il file CSS per la formattazione della pagina HTML

                StringBuilder html = new StringBuilder();

                html.AppendLine("<!DOCTYPE html>");
                html.AppendLine("<html>");
                html.AppendLine("<head>");
                html.AppendLine("<link rel=\"stylesheet\" type=\"text/css\" href=\"style.css\">");
                html.AppendLine("</head>");
                html.AppendLine("<body>");
                html.AppendLine("<h2>Menu</h2>");
                html.AppendLine("<table>");
                html.AppendLine("<tr><th>Nome</th><th>Prezzo</th></tr>");

                foreach (var prodotto in prodottiConPrezzoFinale)
                {
                    html.AppendLine($"<tr><td>{prodotto.Nome}</td><td>{prodotto.PrezzoFinale}</td></tr>");
                }

                html.AppendLine("</table>");
                html.AppendLine("</body>");
                html.AppendLine("</html>");

                File.WriteAllText("menu.html", html.ToString());
            }
        }

        private void GeneraCSS()
        {
            // Genera il file CSS
            string css = @"
            body {
                font-family: Arial, sans-serif;
                background-color: #f0f0f0;
                padding: 20px;
            }

            h2 {
                color: #333;
                font-size: 2em;
                text-align: center;
            }

            table {
                width: 100%;
                border-collapse: collapse;
                margin-top: 20px;
            }

            th, td {
                border: 1px solid #999;
                padding: 10px;
                text-align: left;
            }

            th {
                background-color: #333;
                color: #fff;
            }

            td {
                background-color: #fff;
                color: #333;
            }

            tr:nth-child(even) td {
                background-color: #f2f2f2;
            }";

            File.WriteAllText("style.css", css);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = "menu.html";
            if (File.Exists(filePath))
            {
                System.Diagnostics.Process.Start(filePath);
            }
            else
            {
                MessageBox.Show("Il file menu.html non esiste.");
            }
        }
    }
}
