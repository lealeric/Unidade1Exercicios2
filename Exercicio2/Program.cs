using System;
using Exercicio2;


public class Program
{
    static void Main(string[] args)
    {
        Turma turma = new Turma(1);

        for (int i = 0; i < 2; i++)
        {
            turma.addAluno();
        }

        for (int i = 0; i < turma.tamanhoTurma(); i++)
        {
            turma.lancarP1();
            turma.lancarP2();
        }

        turma.imprime();

        turma.imprimeEstatistica();

    }
}
