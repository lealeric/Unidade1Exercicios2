using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio5
{
    internal class Carro
    {
        private String _placa;
        private String _modelo;
        private Motor _motor;
        private float _velocidadeMaxima;

        public Motor Motor
        {
            get => _motor;
            private set => _motor = value;
        }

        public float VotalocidadeMaxima
        {
            get => _velocidadeMaxima;
            private set 
            {
                if (this.Motor.getCilinidrada() <= 1.0)
                {
                    this._velocidadeMaxima = 140;
                    return;
                }
                else if (this.Motor.getCilinidrada() <= 1.6)
                {
                    this._velocidadeMaxima = 160;
                    return;
                }
                else if (this.Motor.getCilinidrada() <= 2.0)
                {
                    this._velocidadeMaxima = 180;
                    return;
                }
                else
                {
                    this._velocidadeMaxima = 220;
                    return;
                }
            }
        }

        public Carro(string placa, string modelo, Motor motor)
        {
            try
            {
                validaMotor(motor);
                _placa = placa;
                _modelo = modelo;
                Motor = motor;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

        public bool validaMotor(Motor m)
        {
            if (m == null)
            {
                throw new ArgumentNullException("Carro não pode ficar sem motor associado.");
                return false;
            }
            if (m.Carro != null)
            {
                throw new ArgumentException("Motor não pode estar associado a outro carro.");
                return false;
            }
            return true;
        }
        public Carro retornaCarroMotor(Motor m)
        {
            Carro carro = null;

            if (this.Motor == m)
            {
                carro = this;
            }

            return carro;
        }

        public bool alteraMotor(Motor novoMotor)
        {

            if (!validaMotor(novoMotor))
            {                
                return false;
            }
            else
            {
                this._motor.desassociaCarro();
                this._motor = novoMotor;
                Console.WriteLine("Novo motor associado.");
                return true;
            }
        }

        public override bool Equals(object? obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Carro other = (Carro)obj;
                return (this._placa == other._placa && this.Motor.Equals(other.Motor));
            }
        }
    }
}
