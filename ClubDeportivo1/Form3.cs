using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivo1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 nuevoFormulario = new Form2();
            nuevoFormulario.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 nuevoFormulario = new Form1();
            nuevoFormulario.Show();
        }
    }
}
