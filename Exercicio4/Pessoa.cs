using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio4
{
    internal class Pessoa
    {
        private string _nome;
        private CertidaoNascimento certidaoNascimento;

        public string Nome
        {
            get => _nome;
        }

        public Pessoa(String nome)
        {
            _nome = nome;
        }

        public bool associaCertidao(int numeroCertidao)
        {
            if (this.certidaoNascimento == null)
            {
                this.certidaoNascimento = new CertidaoNascimento(numeroCertidao);
                Console.WriteLine("Certidão de nascimento associada.");
                return true;
            }
            else
            {
                Console.WriteLine("A pessoa já possui certidão de nascimento associada.");
                return false;
            }
        }

    }
}
