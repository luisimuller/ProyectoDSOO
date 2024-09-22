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
    public partial class Form1 : Form
    {
        Club club = new Club();



        public Form1(Club i)
        {
            club = i;
            InitializeComponent();
            club.listar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            

            
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            club.listar();
            club.inscribirActividad(selecDeporte.SelectedItem.ToString(), int.Parse(entradaDni.Text));
        }
    }
}
