using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio4
{
    internal class CertidaoNascimento
    {
        private int _idCertidao;
        private Pessoa pessoa;

        public int IdCertidao
        {
            get => _idCertidao;
        }

        public CertidaoNascimento(int idCertidao)
        {
            _idCertidao = idCertidao;
        }


        public bool associaPessoa(String nome)
        {
            if (this.pessoa == null)
            {
                this.pessoa = new Pessoa(nome);
                Console.WriteLine("Pessoa associada.");
                return true;
            }
            else
            {
                Console.WriteLine("A certidão de nascimento associada.");
                return false;
            }
        }
    }
}
