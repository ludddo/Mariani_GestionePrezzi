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
        
        public FormIndex()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists("magazzino.json"))
            {
                File.WriteAllText("magazzino.json", "[]");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAggiuntaMagazzino nuovoForm = new FormAggiuntaMagazzino();

            nuovoForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormCalcoloPrezzo nuovoForm = new FormCalcoloPrezzo();

            nuovoForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormMenu nuovoForm = new FormMenu();

            nuovoForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormVisualizzatoreMenu formVisualizzaProdotti = new FormVisualizzatoreMenu();
            formVisualizzaProdotti.Show();
        }
    }
}
