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



        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            club.cargarDeporte();

            
            club.altaSocio("sdr", 22554568);
            club.altaSocio("rrrrr", 25486154);
            club.altaSocio("kkkk", 3366596);
           
            club.altaSocio("eeeeee", 4456874);
            


            club.listar();
           
         
            /*   club.inscribirActividad("Tenis", 3366596);
            club.inscribirActividad("Tenis", 23366596);
            club.inscribirActividad("Tenis", 3366596);
            club.inscribirActividad("Tenis", 3366596);
         */
            club.listar();
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
            club.inscribirActividad(selecDeporte.SelectedItem.ToString(), int.Parse(entradaDni.Text));
        }
    }
}
