using System;
using Exercicio6;

class Program
{
    static void Main(String[] args)
    {
        ProgressaoAritmetica pa = new ProgressaoAritmetica(3, 4);

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(pa.ProximoValor.ToString());
        }

        Console.WriteLine("Termo na posição 3: " + pa.TermoAt(3).ToString());

        Console.WriteLine("Reinicializando...");
        pa.Reinicializar();
        Console.WriteLine(pa.ProximoValor.ToString());

        Console.WriteLine("---------------------------------------");

        ProgressaoGeometrica pg = new ProgressaoGeometrica(3, 4);

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(pg.ProximoValor.ToString());
        }

        Console.WriteLine("Termo na posição 3: " + pg.TermoAt(3).ToString());

        Console.WriteLine("Reinicializando...");
        pg.Reinicializar();
        Console.WriteLine(pg.ProximoValor.ToString());
    }
}