using System;
using Exercicio3;

public class Program
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Insira o nome do curso:");
        Curso curso = new Curso(Console.ReadLine());

        curso.addTurma();
        curso.addTurma();

        for (int i = 0; i < 5; i++)
        {
            curso.addAluno();
        }
        Console.WriteLine("------------Imprimindo os alunos de uma turma------------");
        curso.imprimeAlunos();
        Console.WriteLine("------------Imprimindo todos os alunos de todas as turmas------------");
        curso.imprimeTudo();
        Console.WriteLine("------------Associando um aluno a uma turma------------");
        curso.associaTurma();
        Console.WriteLine("------------Desassociando um aluno a uma turma------------");
        curso.desassociaTurma();
        Console.WriteLine("------------Removendo um aluno de uma turma------------");
        curso.
    }
}