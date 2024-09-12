using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivo1
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
            act.Add(new ActDeportiva(1,"Futbol", 50));
            act.Add(new ActDeportiva(2,"Tenis", 20));
            act.Add(new ActDeportiva(3,"Natacion", 30));
            act.Add(new ActDeportiva(4,"Basquet", 25));


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
            socio=buscarSocio(dni);
            if (socio == null)
            {
                socio = new Socio(nombre, dni);
                sociosLista.Add(socio);
                resultado = true;
            }
            else { /* si esta repetido el socio*/
                resultado = false;
            }
            return resultado;
        }
        public void listar()
        {
            foreach (Socio soc in sociosLista) Console.WriteLine(soc.ToString());
        }

        public bool inscribirActividad(string nomDeporte, int dni)
        {
            int state = 200;
            bool resultado;
            Socio socio = buscarSocio(dni);
            ActDeportiva bus = buscarAct(nomDeporte);
           
            if (bus == null) { 
                state = 404; 
           }
           if (socio==null)
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
                    resultado =false;
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
