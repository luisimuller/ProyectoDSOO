using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivo1
{
    public class Club
    {
        private List<Socio> SociosLista;
        private List<ActDeportiva> Act;

        
        
        public Club() 
        {
            this.SociosLista = new List<Socio>();
            this.Act = new List<ActDeportiva>();
        }

        public void cargarDeporte() 
        {
            Act.Add(new ActDeportiva(1,"Futbol", 50));
            Act.Add(new ActDeportiva(2,"Tenis", 20));
            Act.Add(new ActDeportiva(3,"Natacion", 30));
            Act.Add(new ActDeportiva(4,"Basquet", 25));

            SociosLista.Add(new Socio("Carlos", 2256));
            SociosLista.Add(new Socio("Luis", 2257));
            SociosLista.Add(new Socio("Miguel", 2258));
            SociosLista.Add(new Socio("juan", 2259));
        }
        private Socio buscarSocio(int buscar) 
        {
            return SociosLista.Find(socio => socio.getId().Equals(buscar));
        }
        
        private ActDeportiva buscarAct(string acti) 
        {
            return Act.Find(activ => activ.Deporte.Equals(acti));
        }

        public bool altaSocio(string nombre, int dni)
        {
            bool resultado;
            Socio socio;
            socio=buscarSocio(dni);
            if (socio == null)
            {
                socio = new Socio(nombre, dni);
                SociosLista.Add(socio);
                resultado = true;
            }
            else { /* si esta repetido el socio*/
                resultado = false;
            }
            return resultado;
        }
        public void listar()
        {
            foreach (Socio soc in SociosLista) Console.WriteLine(soc.ToString());
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
                    MessageBox.Show("Inscripción exitosa");
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
