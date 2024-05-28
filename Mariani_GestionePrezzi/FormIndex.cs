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
    public partial class FormIndex : Form
    {
        // Costruttore della form principale
        public FormIndex()
        {
            InitializeComponent();
        }

        // Evento che si verifica quando la form viene caricata
        private void Form1_Load(object sender, EventArgs e)
        {
            // Controlla se il file "magazzino.json" esiste
            if (!File.Exists("magazzino.json"))
            {
                // Se il file non esiste, crea un nuovo file vuoto con un array JSON vuoto
                File.WriteAllText("magazzino.json", "[]");
            }
        }

        // Evento che si verifica quando il bottone per aggiungere un ingrediente viene cliccato
        private void button1_Click(object sender, EventArgs e)
        {
            // Crea e mostra una nuova form per aggiungere ingredienti al magazzino
            FormAggiuntaMagazzino nuovoForm = new FormAggiuntaMagazzino();
            nuovoForm.Show();
        }

        // Evento che si verifica quando il bottone per calcolare il prezzo viene cliccato
        private void button2_Click(object sender, EventArgs e)
        {
            // Crea e mostra una nuova form per calcolare il prezzo dei prodotti
            FormCalcoloPrezzo nuovoForm = new FormCalcoloPrezzo();
            nuovoForm.Show();
        }

        // Evento che si verifica quando il bottone per gestire il menu viene cliccato
        private void button3_Click(object sender, EventArgs e)
        {
            // Crea e mostra una nuova form per gestire il menu
            FormMenu nuovoForm = new FormMenu();
            nuovoForm.Show();
        }

        // Evento che si verifica quando il bottone per visualizzare il menu viene cliccato
        private void button4_Click(object sender, EventArgs e)
        {
            // Crea e mostra una nuova form per visualizzare i prodotti del menu
            FormVisualizzatoreMenu formVisualizzaProdotti = new FormVisualizzatoreMenu();
            formVisualizzaProdotti.Show();
        }
    }
}
