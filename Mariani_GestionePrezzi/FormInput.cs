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
    public partial class FormInput : Form
    {
        public FormInput()
        {
            InitializeComponent();
        }

        public string IngredientName { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            IngredientName = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
