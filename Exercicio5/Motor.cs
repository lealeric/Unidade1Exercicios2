using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio5
{
    internal class Motor
    {
        private float cilinidrada;
        private Carro _carro;
        private int _idMotor;

        public int idMotor
        {
            get { return _idMotor; }
            set { _idMotor = value; }
        }
        public Carro Carro 
        { 
            get { return _carro; } 
            set { _carro = value; }
        }

        public Motor(int id, float cilindrada)
        {
            this._idMotor = id;
            this.cilinidrada = cilindrada;
            this._carro = null;
        }

        public Motor(int idMotor, float cilindrada, Carro carro)
        {
            this.cilinidrada = cilinidrada;
            this.idMotor = idMotor;
            this._carro = carro;
        }

        public float getCilinidrada()
        {
            return this.cilinidrada;
        }

        public void associaCarro(Carro novoCarro)
        {
            _carro = novoCarro;
        }
        public void desassociaCarro()
        {
            this._carro = null;
        }

        public Motor retornaMotor(int id)
        {
            Motor motor = null;

            if (this._idMotor == id)
            {
                motor = this;
            }

            return motor;
        }

        public override bool Equals(object? obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Motor other = (Motor)obj;
                return this.Equals(other);
            }
        }
    }
}
