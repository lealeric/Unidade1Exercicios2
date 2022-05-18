using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio4
{
    internal class Registro
    {
        private Pessoa _pessoa;
        private CertidaoNascimento _certidaoNascimento;

        public Pessoa Pessoa
        {
            get => _pessoa;
        }

        public CertidaoNascimento CertidaoNascimento
        {
            get => _certidaoNascimento;
        }

        public Registro()
        {

        }

        public void registrarPessoa()
        {
            Console.WriteLine("Insira o nome da pessoa para registar");

            _pessoa = new Pessoa(Console.ReadLine());

            Console.WriteLine("Deseja associar uma certidão de nascimento? (S/N)");

            if (Console.ReadLine().Equals("S"))
            {
                this.associarCertidao();
            }

        }

        public bool associarCertidao()
        {
            Console.WriteLine("Insira o número da ceritdão de nascimento");
            return _pessoa.associaCertidao(Convert.ToInt32(Console.ReadLine()));
        }
    }
}
