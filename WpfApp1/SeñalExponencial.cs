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
        }
         
        public SeñalExponencial(double alfa)
        {
            Alfa = alfa;
        }



    }
}
