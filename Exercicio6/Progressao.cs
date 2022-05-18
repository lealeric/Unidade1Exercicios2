using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio6
{
    public abstract class Progressao
    {

        public abstract int ProximoValor { get; set; }

        public abstract int Primeiro { get; set; }

        public abstract int Razao { get; set; }

        public abstract void Reinicializar();
        public abstract int TermoAt(int i);


    }
}
