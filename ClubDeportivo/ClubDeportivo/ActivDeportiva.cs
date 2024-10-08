﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo
{
    internal class ActivDeportiva
    {
        private int id;
        private string deporte;
        private int cupo;

        public ActivDeportiva(int id, string deporte, int cupo)
        {
            this.id = id;
            this.Deporte = deporte;
            this.Cupo = cupo;


        }
        public int Id { get => id; set => id = value; }
        public string Deporte { get => deporte; set => deporte = value; }
        public int Cupo { get => cupo; set => cupo = value; }

        public override string ToString()
        {

            return $"{" "+deporte,-25} {cupo,-20}";
        }
    }
}