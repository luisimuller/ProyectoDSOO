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

            club.cargarDeportes();

            club.cargarSocios();

            club.menu();


           





        }
    }
}
