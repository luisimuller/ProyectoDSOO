using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo
{
    internal class Socio
    {
        private string nombre;
        private int Id, pos = 0;
        private int[] activ=new int[3];

        public Socio(string nombre, int ID)
        {
            this.nombre = nombre;
            this.Id = ID;
           
        }
        public int Pos { get => pos; set => pos = value; }
        public int[] getActs() {  return activ; }
        public void setActs(int idAct) {
            activ[pos]=idAct;
            pos++;
      
        }
        public int getId() { return Id; }
        public string getNombre() { return nombre; }

        public override string ToString()
        {

            return "Nombre: " + this.nombre + " ID: " + this.Id + " actividad nro: " + pos;
        }
    }
}
