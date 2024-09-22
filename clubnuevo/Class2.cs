using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clubnuevo
{

    internal class Club
    {
        private List<Socio> sociosLista;
        private List<ActDeportiva> act;

        public Club()
        {
            this.sociosLista = new List<Socio>();
            this.act = new List<ActDeportiva>();
        }

        public void cargarDeporte()
        {
            act.Add(new ActDeportiva(1, "Futbol", 50));
            act.Add(new ActDeportiva(2, "Tenis", 2));
            act.Add(new ActDeportiva(3, "Natacion", 30));
            act.Add(new ActDeportiva(4, "Basquet", 25));


        }
        private Socio buscarSocio(int buscar)
        {
            return sociosLista.Find(socio => socio.getId().Equals(buscar));
        }

        private ActDeportiva buscarAct(string acti)
        {
            return act.Find(activ => activ.Deporte.Equals(acti));
        }

        public bool altaSocio(string nombre, int dni)
        {
            bool resultado;
            Socio socio;
            socio = buscarSocio(dni);
            if (socio == null)
            {
                socio = new Socio(nombre, dni);
                sociosLista.Add(socio);
                resultado = true;
            }
            else
            { /* si esta repetido el socio*/
                resultado = false;
            }
            return resultado;
        }
        public void listar()
        {
            foreach (Socio soc in sociosLista) Console.WriteLine(soc.ToString());
        }

        public void menu()
        {



            Console.Title = "Menú Principal";
            string[] menuItems = { "1. LISTAR", "2. ALTA SOCIO", "3. INSCRIBIR ACTIVIDAD" };
            int selectedIndex = 0;

            Console.Clear();
/*            PrintCentered("=== Bienvenido al Menú Principal ===", Console.WindowWidth);
            Console.WriteLine();
*/
            while (true)
            {
                Console.Clear();
                PrintCentered("=== Bienvenido al Menú Principal ===", Console.WindowWidth);
                Console.WriteLine();

                for (int i = 0; i < menuItems.Length; i++)
                {
                    ClearCurrentConsoleLine();
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        PrintCentered($"> {menuItems[i]} <", Console.WindowWidth);
                        Console.ResetColor();
                    }
                    else
                    {
                        PrintCentered(menuItems[i], Console.WindowWidth);
                    }
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? menuItems.Length - 1 : selectedIndex - 1;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex == menuItems.Length - 1) ? 0 : selectedIndex + 1;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    string nom;
                     int   dni;
                     PrintCentered("Alta de Cliente", Console.WindowWidth);
                    if (selectedIndex==0)
                    {
                        Console.Clear();
                        listar();
                        Console.ReadKey();
                    }
                    if (selectedIndex == 1)
                    {
                        Console.Write("ingrese nombre: ", Console.WindowWidth);
                        nom=Console.ReadLine();
                        Console.Write("ingrese DNI: ", Console.WindowWidth);
                        while (!int.TryParse(Console.ReadLine(), out dni))
                        {
                            Console.Write("Por favor, ingrese un número : ");
                        }
                        if (!altaSocio(nom, dni))
                        {
                            Console.Write("Socio Existente");
                            Console.ReadKey();
                        } 

                    }
                    if (selectedIndex == 2)
                    {
                        string nomb;
                        int soc;
                        Console.Write("ingrese nombre de la Actividad: ", Console.WindowWidth);
                        nomb = Console.ReadLine();
                        Console.Write("ingrese DNI: ", Console.WindowWidth);
                        while (!int.TryParse(Console.ReadLine(), out soc))
                        {
                            Console.Write("Por favor, ingrese un número : ");
                        }
                        if (!inscribirActividad(nomb, soc))
                        {
                            Console.Write("ERROR EN ALTA EN A" +
                                "CTIVIDAD");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Write("ALTA EN ACTIVIDAD CORRECTA ");
                            Console.ReadKey();
                        }
                    }



                }

                // Mover el cursor hacia arriba para sobrescribir las líneas del menú
                Console.SetCursorPosition(0, Console.CursorTop - menuItems.Length);
            }
        }
            public void PrintCentered(string text, int windowWidth)
            {
                int padding = (windowWidth - text.Length) / 2;
                Console.WriteLine(text.PadLeft(padding + text.Length));
            }

            public void ClearCurrentConsoleLine()
            {
                int currentLineCursor = Console.CursorTop;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, currentLineCursor);
            }



            public bool inscribirActividad(string nomDeporte, int dni)
        {
            int state = 200;
            bool resultado;
            Socio socio = buscarSocio(dni);
            ActDeportiva bus = buscarAct(nomDeporte);

            if (bus == null)
            {
                state = 404;
            }
            if (socio == null)
            {
                state = 401;
            }
            if (socio != null && socio.Pos >= 3)
            {
                state = 403;
            }
            if (bus != null && bus.Cupo == 0)
            {
                state = 405;
            }

            switch (state)
            {
                case 200:
                    socio.SetActs(bus.Id);
                    bus.Cupo--;
                    resultado = true;
                    break;
                case 404:
                    MessageBox.Show("ACTIVIDAD INEXISTENTE");
                    resultado = false;
                    break;
                case 401:
                    MessageBox.Show("Socio INEXISTENTE");
                    resultado = false;
                    break;
                case 403:
                    MessageBox.Show("Tope de actividad alcanzado");
                    resultado = false;
                    break;
                case 405:
                    MessageBox.Show("Tope de Actividad Cupo");
                    resultado = false;
                    break;
                default:
                    MessageBox.Show("Error en la inscripción. Por favor contacte a su Administrador");
                    resultado = false;
                    break;
            }

            return resultado;
        }
    }
}
