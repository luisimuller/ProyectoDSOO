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

    public partial class Form2 : Form
    {
        Club club = new Club();
        public Form2(Club club2)
        {
            club = club2;
            InitializeComponent();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            club.altaSocio(nombre.Text,int.Parse(dni.Text));
            club.listar();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
