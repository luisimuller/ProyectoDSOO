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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Club club = new Club();

            club.cargarDeporte();


            club.altaSocio("sdr", 22554568);
            club.altaSocio("rrrrr", 25486154);
            club.altaSocio("kkkk", 3366596);
            club.altaSocio("kkkk", 3366596);
            club.altaSocio("eeeeee", 4456874);
            


            club.listar();
            club.inscribirActividad("Tenis", 3366596);
            club.inscribirActividad("Tenis", 23366596);
            club.inscribirActividad("Tenis", 3366596);
            club.inscribirActividad("Tenis", 3366596);

            club.listar();
        }
    }
}
