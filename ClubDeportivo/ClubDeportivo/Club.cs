using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace ClubDeportivo
{
    internal class Club
    {
        private List<Socio> ListaSocios;
        private List<ActivDeportiva> actividades;

        public Club() {
            this.ListaSocios = new List<Socio>();
            this.actividades = new List<ActivDeportiva>();

        }
        public void cargarDeportes() {
            actividades.Add(new ActivDeportiva(1, "Futbol", 20));
            actividades.Add(new ActivDeportiva(1, "Voley", 30));
            actividades.Add(new ActivDeportiva(1, "Natacion", 40));
            actividades.Add(new ActivDeportiva(1, "Hockey", 20));
            actividades.Add(new ActivDeportiva(1, "Basquet", 25));
            actividades.Add(new ActivDeportiva(1, "Patin", 18));
            actividades.Add(new ActivDeportiva(1, "Rugby", 20));
        }
        private Socio buscarSocio(int dni) {
            return ListaSocios.Find(socio => socio.getId().Equals(dni));
        }

        private  ActivDeportiva buscarActividad(string activ)
        {
            return actividades.Find(act =>act.Deporte != null && act.Deporte.ToLower().Equals(activ.ToLower()));
        }
        public bool altaSocio(string nombre, int dni)
        {
            bool resultado;
            Socio socio;
            socio = buscarSocio(dni);
            if (socio == null)
            {
                socio = new Socio(nombre, dni);
                ListaSocios.Add(socio);
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
            foreach (Socio soc in ListaSocios) Console.WriteLine(soc.ToString());
        }

        public void menu()
        {
            while (true)
            {
                AnsiConsole.Clear();
                AnsiConsole.MarkupLine("[bold yellow]=== Bienvenido al Menú Principal ===[/]");

                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Seleccione una opción:")
                        .AddChoices(new[] { "1. LISTAR", "2. ALTA SOCIO", "3. INSCRIBIR ACTIVIDAD", "4. SALIR" }));

                switch (choice)
                {
                    case "1. LISTAR":
                        listar();
                        break;
                    case "2. ALTA SOCIO":
                        altaSocio();  // Aquí estaba en mayúsculas, ya corregido
                        break;
                    case "3. INSCRIBIR ACTIVIDAD":
                        inscribirActividad();  // Aquí también lo corregimos
                        break;
                    case "4. SALIR":
                        return;
                }

                AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void altaSocio()
        {
            string nombre = AnsiConsole.Ask<string>("Ingrese nombre:");
            int dni;
            while (!int.TryParse(AnsiConsole.Ask<string>("Ingrese DNI:"), out dni))
            {
                AnsiConsole.MarkupLine("[red]Por favor, ingrese un número válido.[/]");
            }
            if (!altaSocio(nombre, dni))
            {
                AnsiConsole.MarkupLine("[red]Socio existente.[/]");
            }
        }

        private void inscribirActividad()
        {
            string actividad = AnsiConsole.Ask<string>("Ingrese nombre de la Actividad:");
            int dni;
            while (!int.TryParse(AnsiConsole.Ask<string>("Ingrese DNI:"), out dni))
            {
                AnsiConsole.MarkupLine("[red]Por favor, ingrese un número válido.[/]");
            }

            int state = 200;
            Socio socio = buscarSocio(dni);
            ActivDeportiva bus = buscarActividad(actividad);

            // Lógica de inscripción
            if (bus == null)
            {
                state = 404; // Actividad inexistente
            }
            if (socio == null)
            {
                state = 401; // Socio inexistente
            }
            if (socio != null && socio.Pos >= 3)
            {
                state = 403; // Tope de actividades alcanzado
            }
            if (bus != null && bus.Cupo == 0)
            {
                state = 405; // Cupo lleno
            }

            switch (state)
            {
                case 200:
                    socio.setActs(bus.Id);
                    bus.Cupo--;
                    AnsiConsole.MarkupLine("[green]Inscripción exitosa.[/]");
                    break;
                case 404:
                    AnsiConsole.MarkupLine("[red]Actividad inexistente.[/]");
                    break;
                case 401:
                    AnsiConsole.MarkupLine("[red]Socio inexistente.[/]");
                    break;
                case 403:
                    AnsiConsole.MarkupLine("[red]Tope de actividades alcanzado.[/]");
                    break;
                case 405:
                    AnsiConsole.MarkupLine("[red]Cupo de actividad lleno.[/]");
                    break;
                default:
                    AnsiConsole.MarkupLine("[red]Error en la inscripción. Por favor contacte a su Administrador.[/]");
                    break;
            }
        }


    }
}
