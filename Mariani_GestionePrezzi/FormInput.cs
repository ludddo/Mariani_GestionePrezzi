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
    // Definizione della classe parziale FormInput che eredita da Form
    public partial class FormInput : Form
    {
        // Costruttore della form
        public FormInput()
        {
            InitializeComponent();
        }

        // Proprietà per memorizzare il nome dell'ingrediente inserito dall'utente
        public string IngredientName { get; private set; }

        // Evento che si verifica quando il bottone per confermare viene cliccato
        private void button1_Click(object sender, EventArgs e)
        {
            // Memorizza il testo inserito nel TextBox nella proprietà IngredientName
            IngredientName = textBox1.Text;
            // Imposta il risultato del dialogo a OK
            this.DialogResult = DialogResult.OK;
            // Chiude la form
            this.Close();
        }

        // Evento che si verifica quando la form viene caricata
        private void FormInput_Load(object sender, EventArgs e)
        {
            // Al momento, questo evento non fa nulla
        }
    }
}
