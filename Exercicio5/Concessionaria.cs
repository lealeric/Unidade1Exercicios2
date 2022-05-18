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
            Console.WriteLine("Insira o identificador do motor:");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Insira a cilindrada do motor: (X.X)");
            float cilindrada = float.Parse(Console.ReadLine());

            motores.Add(new Motor(id, cilindrada));
        }
        public void addCarro()
        {
            Console.WriteLine("Insira a placa do carro:");
            String placa = Console.ReadLine();

            Console.WriteLine("Insira o modelo do carro:");
            String modelo = Console.ReadLine();

            Console.WriteLine("Insira o id do motor:");
            int idMotor = Convert.ToInt32(Console.ReadLine());
            Motor motor = null;

            for (int i = 0; i < motores.Count; i++)
            {
                if (motores[i].retornaMotor(idMotor) != null)
                {
                    motor = motores[i];
                    break;
                }
            }

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

        public bool alteraMotor(Carro carro, Motor novoMotor)
        {

            if (!carro.validaMotor(novoMotor))
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
    }
}
