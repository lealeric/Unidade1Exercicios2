using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio5
{
    internal class Concessionaria
    {
        List<Carro> carros;
        List<Motor> motores;


        public void addMotor()
        {
            motores = new List<Motor>();
            Console.WriteLine("Insira o identificador do motor:");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Insira a cilindrada do motor: (X.X)");
            float cilindrada = float.Parse(Console.ReadLine());

            motores.Add(new Motor(id, cilindrada));
        }
        public void addCarro()
        {
            carros = new List<Carro>();
            Console.WriteLine("Insira a placa do carro:");
            String placa = Console.ReadLine();

            Console.WriteLine("Insira o modelo do carro:");
            String modelo = Console.ReadLine();

            Console.WriteLine("Insira o id do motor:");
            int idMotor = Convert.ToInt32(Console.ReadLine());
            Motor motor = this.retornaMotor(idMotor);

            if (motor == null)
            {
                Console.WriteLine("Motor não cadastrado. Inserir novo motor? (S/N):");
                if (Console.ReadLine().ToUpper() == "S")
                {
                    this.addMotor();
                }
            }

            carros.Add(new Carro(placa, modelo, motor));
        }

        private Motor retornaMotor(int id)
        {
            Motor m = null;

            for (int i = 0; i < motores.Count; i++)
            {
                if (motores[i].idMotor == id)
                {
                    m = motores[i];
                    break;
                }
            }

            return m;
        }

        private Motor retornaMotor(Motor motor)
        {
            Motor m = null;

            for (int i = 0; i < motores.Count; i++)
            {
                if (motores[i].Equals(motor))
                {
                    m = motores[i];
                    break;
                }
            }

            return m;
        }

        private Carro retornaCarro(Carro carro)
        {
            Carro c = null;

            for (int i = 0; i < carros.Count; i++)
            {
                if (carros[i].Equals(carro))
                {
                    c = carros[i];
                    break;
                }
            }

            return c;
        }

        public bool alteraMotor(Carro carro, Motor novoMotor)
        {

            if (!carro.validaMotor(novoMotor))
            {
                return false;
            }
            else
            {
                this.retornaCarro(carro).alteraMotor(novoMotor);
                return true;
            }
        }
    }
}
