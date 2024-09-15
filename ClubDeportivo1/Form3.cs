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
        Club  club=new Club();   
        public Form3()
        {
            InitializeComponent();
            club.cargarDeporte();

        }

        private Club GetClub()
        {
            return club;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 nuevoFormulario = new Form2(club);
            
            nuevoFormulario.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 nuevoFormulario = new Form1(club);
            nuevoFormulario.Show();
        }
    }
}
