using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Exercicio1
{
    public class Validacao
    {
        public Exception excecao;

        public Validacao(int id, String valorEntrada)
        {
            switch (id)
            {
                case 0: 
                    this.excecao = this.validaNome(valorEntrada);
                    break;
                case 1:
                    this.excecao = this.validaCpf(valorEntrada);
                    break;
                case 2:
                    this.excecao = this.validaNascimento(valorEntrada);
                    break;
                case 3:
                    this.excecao = this.validaRenda(valorEntrada);
                    break;
                case 4:
                    this.excecao = this.validaEstado(valorEntrada);
                    break;
                case 5:
                    this.excecao = this.validaDependente(valorEntrada);
                    break;
            }
        }

        public Exception validaNome(String nome)
        {
            if (nome.Length < 5)
            {
                return new ArgumentException("Nome muito curto.");
            }

            return null;
        }

        public Exception validaCpf(String cpf)
        {
            if (cpf.Length != 11 || testeCpfIgual(cpf) || !testeDigito1Cpf(cpf) || !testeDigito2Cpf(cpf))
            {
                return new ArgumentException("CPF inválido.");
            }

            return null;
        }

        private bool testeCpfIgual(String s)
        {
            for (int i = 1; i < s.Length; i++)
                if (s[i] != s[0])
                    return false;

            return true;
        }

        private bool testeDigito1Cpf(String s)
        {
            bool saida = false;
            int soma = 0;

            for (int i = 0, j = 10; i <= 8; i++, j--)
            {
                soma += (int.Parse(s[i].ToString()) * j);
            }

            int resto = soma % 11;

            if (resto <= 1)
            {
                if (int.Parse(s[9].ToString()) == 0 ) { saida = true; }
            }
            else
            {
                if (int.Parse(s[9].ToString()) == (11 - resto)) { saida = true; }
            }

            return saida;
        }

        private bool testeDigito2Cpf(String s)
        {
            bool saida = false;
            int soma = 0;

            for (int i = 0, j = 11; i <= 9; i++, j--)
            {
                soma += int.Parse(s[i].ToString()) * j;
            }        
        
            int resto = soma % 11;

            if (resto <= 1)
            {
                if (int.Parse(s[10].ToString()) == 0) { saida = true; }
            }
            else
            {
                if (int.Parse(s[10].ToString()) == (11 - resto)) { saida = true; }
            }

            return saida;
        }

        public Exception validaNascimento(String dataNascimento)
        {
            if (dataNascimento[2] != '/' || dataNascimento[5] != '/')
            {
                return new ArgumentException("Formato de data inválido.");
            }
            else
            {
                String[] subs = dataNascimento.Split('/');
                int dia, mes, ano;
                dia = Convert.ToInt32(subs[0]);
                mes = Convert.ToInt32(subs[1]);
                ano = Convert.ToInt32(subs[2]);

                if (ano < 1900 || ano > DateTime.Now.Year)
                {
                    return new ArgumentException("Ano de nascimento inválido.");
                }

                if (mes < 1 || mes > 12)
                {
                    return new ArgumentException("Mês de nascimento inválido.");
                }

                if (dia < 1)
                {
                    return new ArgumentException("Dia de nascimento inválido.");
                }
                else
                {
                    switch (mes)
                    {
                        case 2:
                            if ((DateTime.IsLeapYear(ano) && dia > 29) || (!DateTime.IsLeapYear(ano) && dia > 28))
                            {
                                return new ArgumentException("Dia de nascimento inválido.");
                            }
                            break;
                        case 1:
                        case 3:
                        case 5:
                        case 7:
                        case 8:
                        case 10:
                        case 12:
                            if (dia > 31)
                            {
                                return new ArgumentException("Dia de nascimento inválido.");
                            }
                            break;
                        case 4:
                        case 6:
                        case 9:
                        case 11:
                            if (dia > 30)
                            {
                                return new ArgumentException("Dia de nascimento inválido.");
                            }
                            break;
                    }

                }

            }

            String padrao = "dd/MM/yyyy";

            DateTime data = DateTime.ParseExact(dataNascimento, padrao, CultureInfo.InvariantCulture);

            TimeSpan diferenca = DateTime.Now - data;

            int anos = (int)(diferenca.TotalDays / 365.25);

            if (anos < 18)
            {
                return new Exception("Cliente menor de 18 anos.");
            }

            return null;
        }

        public Exception validaRenda(String renda)
        {
            if (float.Parse(renda.Replace(',', '.')) <= 0)
            {
                return new ArgumentException("Valor da renda inválido.");
            }
            if (renda[renda.Length - 3] != ',')
            {
                return new ArgumentException("Valor da renda não está no formato XXXXX,XX.");
            }
            else
            {
                String[] sub = renda.Split(',');
                if (sub[1].Length != 2)
                {
                    return new ArgumentException("Valor da renda não está no formato XXXXX,XX.");
                }
            }
            
            return null;
        }

        public Exception validaEstado(String estado)
        {
            char c = Convert.ToChar(estado.ToUpper());

            if (c != 'C' && c != 'S' && c != 'D' && c != 'V')
            {
                return new Exception("Valor inválido.");
            }

            return null;
        }

        public Exception validaDependente(String dependente)
        {
            int n = Convert.ToInt32(dependente);

            if (n < 0 || n > 10)
            {
                return new Exception("Valor inválido.");
            }

            return null;
        }
    }
    
}
