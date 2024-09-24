using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Club club = new Club();

            club.CargarDeportes();


            club.AltaSocio("sdr", 22554568);
            club.AltaSocio("rrrrr", 25486154);
            club.AltaSocio("kkkk", 3366596);
            club.AltaSocio("kkkk", 3366596);
            club.AltaSocio("eeeeee", 4456874);
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
