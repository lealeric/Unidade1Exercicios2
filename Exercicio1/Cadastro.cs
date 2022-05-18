using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Exercicio1
{
    internal class Cadastro
    {
        private Dictionary<int,Exception> dicionario;
        private String _nome;
        private long _cpf;
        private DateTime _dataDeNascimento;
        private float _rendaMensal;
        private char _estadoCivil;
        private int _dependentes;

        public Cadastro()
        {
            this.dicionario = new Dictionary<int,Exception>();
            this.incluiCadastro();
            this.imprimeDados();

        }
        private enum tipoEstadoCivil
        {
            CASADO,
            SOLTEIRO,
            DIVORCIADO,
            VIÚVO
        }
        private String retornaEstadoCivil(char c)
        {
            String ret = "";

            if (c == 'C') { ret = tipoEstadoCivil.CASADO.ToString(); }
            else if (c == 'S') { ret = tipoEstadoCivil.SOLTEIRO.ToString(); }
            else if (c == 'D') { ret = tipoEstadoCivil.DIVORCIADO.ToString(); }
            else if (c == 'V') { ret = tipoEstadoCivil.VIÚVO.ToString(); }


            return ret;
        }

        private void incluiCadastro()
        {
            Validacao validacao;
            String[] entradas = new String[6];
            String[] textos = new String[6];
            Exception[] excecoes = new Exception[6];

            textos[0] = "Insira o nome: ";
            textos[1] = "Insira o CPF: ";
            textos[2] = "Insira a data de nascimento: (DD/MM/YYYY)";
            textos[3] = "Insira a renda mensal: ";
            textos[4] = "Insira o Estado Civil: (c,s,v,d)";
            textos[5] = "Insira o número de dependentes: ";

            for (int i = 0; i < 6; i++)
            { 
                Console.WriteLine(textos[i]);
                entradas[i] = Console.ReadLine();
                validacao = new Validacao(i, entradas[i]);
                dicionario.Add(i, validacao.excecao);
            }

            while (dicionario.Count > 0)
            {
                Console.WriteLine(String.Format("{0,-20}:{1,-15} {2}", "Campo com erro", "Valor", "Erro"));                
                foreach (KeyValuePair<int,Exception> id in dicionario)
                {
                    if(id.Value == null)
                    {
                        dicionario.Remove(id.Key);
                    }
                    else
                    {
                        this.imprimeErros(id.Key, id.Value, entradas[id.Key]);
                    }                    
                }
                Console.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));

                foreach (KeyValuePair<int, Exception> id in dicionario)
                {
                    Console.WriteLine(textos[id.Key]);
                    entradas[id.Key] = Console.ReadLine();
                    validacao = new Validacao(id.Key, entradas[id.Key]);
                    dicionario[id.Key] = validacao.excecao;
                }
            }

            String padrao = "dd/MM/yyyy";

            this._nome = entradas[0];
            this._cpf = Convert.ToInt64(entradas[1]);
            this._dataDeNascimento = DateTime.ParseExact(entradas[2], padrao, CultureInfo.InvariantCulture);
            this._rendaMensal = float.Parse(entradas[3].Replace(",","."));
            this._estadoCivil = Convert.ToChar(entradas[4].ToUpper());
            this._dependentes = Convert.ToInt32(entradas[5]);
        }
        private void imprimeErros(int idCampo, Exception ex, String valor)
        {
            String[] campo = new string[6];

            campo[0] = "Nome";
            campo[1] = "CPF";
            campo[2] = "Data de Nascimento";
            campo[3] = "Renda";
            campo[4] = "Estado Civil";
            campo[5] = "Dependentes";

            Console.WriteLine(String.Format("{0,-20}:{1,-15} {2}", campo[idCampo], valor, ex.Message));
        }

        private void imprimeDados()
        {
            Console.WriteLine();
            Console.WriteLine(  "-------------------------------------------------------------------------------------------------------------\n" +
                                "--------------------------------------------CLIENTE CADASTRADO-----------------------------------------------\n" +
                                "-------------------------------------------------------------------------------------------------------------\n");
            Console.WriteLine(String.Format(  "Nome:                    {0}\n" +
                                              "CPF:                     {1}\n" +
                                              "Data de nascimento:      {2}\n" +
                                              "Renda mensal:            {3}\n" +
                                              "Estado civil:            {4}\n" +
                                              "Dependentes:             {5}\n", this._nome, this._cpf.ToString(), this._dataDeNascimento.ToString("dd/MM/yyyy"),
                                              this._rendaMensal.ToString("C", new System.Globalization.CultureInfo("pt-BR")), this.retornaEstadoCivil(this._estadoCivil),
                                              this._dependentes.ToString()));
        }
    }
}
