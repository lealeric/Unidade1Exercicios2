using System;
using Exercicio7;

public class Program
{
    public static void Main(String[] args)
    {
        Propriedades propriedades = new Propriedades();

        Console.WriteLine("Insira a chave que deseja consultar o valor:");
        Console.WriteLine(propriedades.retornaValor(Console.ReadLine()));

        Console.WriteLine("Insira a chave para consulta de existência:");
        Console.WriteLine(propriedades.existeChave(Console.ReadLine()));

        Console.WriteLine("Insira a chave para consulta de existência:");
        Console.WriteLine(propriedades.existeChave(Console.ReadLine()));

        propriedades.addChave();
        propriedades.addChave();

        Console.WriteLine("Insira a chave que deseja alterar:");
        propriedades.alteraValor(Console.ReadLine());

        Console.WriteLine("Insira o caminho e nome do arquivo para salvar o arquivo de propriedades:");
        propriedades.exportaPropriedades(Console.ReadLine());

        Console.WriteLine("---------------------------------------------\n" +
                            "---------UTILIZANDO OUTRO CONTRUTOR----------" +
                            "---------------------------------------------");

        Propriedades propriedades2 = new Propriedades("D:/Documentos/Residência Back-End/propriedades.txt");

        Console.WriteLine("Insira a chave que deseja consultar o valor:");
        Console.WriteLine(propriedades2.retornaValor(Console.ReadLine()));

        Console.WriteLine("Insira a chave para consulta de existência:");
        Console.WriteLine(propriedades2.existeChave(Console.ReadLine()));

        Console.WriteLine("Insira a chave para consulta de existência:");
        Console.WriteLine(propriedades2.existeChave(Console.ReadLine()));

        propriedades2.addChave();
        propriedades2.addChave();

        Console.WriteLine("Insira a chave que deseja alterar:");
        propriedades2.alteraValor(Console.ReadLine());

        propriedades2.exportaPropriedades();
    }
}