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
        public FormAggiuntaMagazzino()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ingredient<decimal> ingrediente = new Ingredient<decimal>(textBox1.Text, decimal.Parse(textBox2.Text), decimal.Parse(textBox3.Text));

            string percorsoFile = "magazzino.json";

            ingrediente.SerializzaInJSON(percorsoFile);

            // Deserializzazione da file JSON
            Ingredient<decimal> ingredienteDeserializzato = Ingredient<decimal>.DeserializzaDaJSON(percorsoFile);
        }
    }
}
