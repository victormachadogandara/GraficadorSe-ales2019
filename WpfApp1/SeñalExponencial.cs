using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class SeñalExponencial : SeñalSenoidal
    { 
        public double Alfa { get; set; }

        public SeñalExponencial()
        {
            Alfa = 0.0;

            Muestras = new List<Muestra>();
            AmplitudMaxima = 0.0;
        }
         
        public SeñalExponencial(double alfa)
        {
            Alfa = alfa;

            Muestras = new List<Muestra>();
            AmplitudMaxima = 0.0;
        }

        override public double evaluar(double tiempo)
        {
            double resultado;

            resultado = Math.Exp(Alfa * tiempo);

            return resultado;
        }

    }
}
