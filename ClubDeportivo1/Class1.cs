using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clubnuevo
{
    internal class Socio
    {
        private string nombre;
        private int id, pos = 0;
        private int[] acts = new int[3];


        public Socio(string nombre, int ID)
        {
            this.nombre = nombre;
            this.id = ID;

        }
        public int Pos { get => pos; set => pos = value; }
        public int[] GetActs() { return acts; }
        public void SetActs(int y)
        {
            acts[pos] = y;
            pos++;
        }
        public int getId() { return id; }
        public string getNomnbre() { return nombre; }

        public override string ToString()
        {

            return "Nombre: " + this.nombre + " ID: " + this.id + " actuividad nro: " + pos;
        }
    }
}