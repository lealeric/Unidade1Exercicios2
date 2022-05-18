using System;
using Exercicio5;

public class Program
{
    static void Main(string[] args)
    {
        Concessionaria concessionaria = new Concessionaria();

        for (int i = 0; i < 3; i++)
        {
            concessionaria.addMotor();
        }

        for (int i = 0; i < 2; i++)
        {
            concessionaria.addCarro();
        }


    }
}