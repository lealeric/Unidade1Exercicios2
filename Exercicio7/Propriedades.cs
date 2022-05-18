using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Exercicio7
{
    internal class Propriedades
    {
        private Dictionary<String, String> dic;
        private String caminho;

        public Propriedades()
        {
            this.dic = new Dictionary<String, String>();

            Console.WriteLine("Insira a url da empresa:");
            dic.Add("url", Console.ReadLine());

            Console.WriteLine("Insira a porta da rede da empresa:");
            dic.Add("porta", Console.ReadLine());

            Console.WriteLine("Insira o endereço da rede da empresa:");
            dic.Add("endereco", Console.ReadLine());

            Console.WriteLine("Insira o email do responsável:");
            dic.Add("email", Console.ReadLine());

        }

        public Propriedades(String path)
        {
            StreamReader arquivo;
            String linha;
            this.dic = new Dictionary<String, String>();

            try
            {
                arquivo = new StreamReader(path);

                linha = arquivo.ReadLine();

                while (linha != null)
                {
                    String[] parametros = linha.Split("=");
                    dic.Add(parametros[0], parametros[1]);
                    linha = arquivo.ReadLine();
                }

                arquivo.Close();
                this.caminho = path;
            }
            catch (Exception e)
            {
                Console.WriteLine("Um ou mais dados estão fora do padrão.");
            }
            
        }

        public String retornaValor(String chave)
        {
            if (this.existeChave(chave))
            {
                return dic[chave.ToLower()];
            }

            return "Chave não encontrada.";
            
        }

        public bool existeChave(String valor)
        {
            return this.dic.ContainsKey(valor);
        }

        public bool alteraValor(String chave)
        {
            if (chave == null)
            {
                throw new ArgumentNullException();
                return false;
            }

            chave = chave.ToLower();
            try
            {
                Console.WriteLine("Insira o novo valor para " + chave + ":");
                dic[chave] = Console.ReadLine();
                Console.WriteLine("Valor alterado com sucesso.");
                return true;
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("A chave não existe no dicionário.");
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }

        public void addChave()
        {
            Console.WriteLine("Insira o nome da nova chave:");
            String novaChave = Console.ReadLine().ToLower();

            if (this.existeChave(novaChave))
            {
                throw new Exception("A chave já existe no dicionário.");
                this.addChave();
                return;
            }
            else
            {
                Console.WriteLine("Gostaria de atribuir um valor para a nova chave? (S/N)");
                String novoValor = null;

                if (Console.ReadLine().ToUpper() == "S")
                {
                    Console.WriteLine("Insira o valor a ser associado:");
                    novoValor = Console.ReadLine();
                }

                dic.Add(novaChave, novoValor);
            }
        }

        public void exportaPropriedades()
        {
            File.Delete(this.caminho);

            StreamWriter saida = new StreamWriter(this.caminho);

            foreach (KeyValuePair<String, String> linha in dic)
            {
                saida.WriteLine("{0}={1}", linha.Key, linha.Value);
            }

            saida.Close();

            Console.WriteLine("Propriedades salvas em " + this.caminho);
        }

        public void exportaPropriedades(String caminho)
        {

            StreamWriter saida = new StreamWriter(caminho);

            foreach (KeyValuePair<String, String> linha in dic)
            {
                saida.WriteLine("{0}={1}", linha.Key, linha.Value);
            }

            saida.Close();

            Console.WriteLine("Propriedades salvas em " + caminho);
        }

    }
}
