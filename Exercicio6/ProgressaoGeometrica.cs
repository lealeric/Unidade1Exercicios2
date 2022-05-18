using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio6
{
    internal class ProgressaoGeometrica : Progressao
    {
        private int _primeiro;
        private int _razao;
        private int _proximoValor;

        public override int Primeiro
        {
            get => _primeiro;
            set => _primeiro = value;
        }

        public override int Razao
        {
            get => _razao;
            set => _razao = value;
        }

        public override int ProximoValor
        {
            get
            {
                int valor = _proximoValor;
                this._proximoValor *= this.Razao;
                return valor;
            }
            set {  }
        }
        public ProgressaoGeometrica(int primeiroValor, int razao)
        {
            _primeiro = primeiroValor;
            _razao = razao;
            _proximoValor = primeiroValor;
        }

        public override int TermoAt(int i)
        {
            return this.Primeiro * (int) (Math.Pow(this.Razao, (i - 1)));
        }

        public override void Reinicializar()
        {
            this._proximoValor = this._primeiro;
        }
    }
}
