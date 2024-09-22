using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clubnuevo
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Club club = new Club();
            
            club.cargarDeporte();


            club.altaSocio("sdr", 22554568);
            club.altaSocio("rrrrr", 25486154);
            club.altaSocio("kkkk", 3366596);
            club.altaSocio("kkkk", 3366596);
            club.altaSocio("eeeeee", 4456874);
            club.menu();


            club.listar();
          /*  club.inscribirActividad("Tenis", 3366596);
            club.inscribirActividad("Tenis", 23366596);
            club.inscribirActividad("Tenis", 3366596);
            club.inscribirActividad("Tenis", 3366596);
          */
            club.listar();





        }
    }
}
