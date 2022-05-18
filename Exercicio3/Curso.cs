using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercicio2;

namespace Exercicio3
{
    internal class Curso
    {
        List<Turma> turmas = new List<Turma>();
        List<Aluno> alunos = new List<Aluno>();
        String nome;

        public Curso(String nome)
        {
            this.nome = nome;
        }

        public bool addTurma()
        {
            Console.WriteLine("Insira o código da turma:");
            int idTurma = Convert.ToInt32(Console.ReadLine());

            if(turmas != null)
            {
                for (int i = 0; i < turmas.Count; i++)
                {
                    if (turmas[i].retornaTurma(idTurma)!= null)
                    {
                        Console.WriteLine("Turma já cadastrada.");
                        return false;
                    }
                }
            }

            Turma turma = new Turma(idTurma);

            turmas.Add(turma);
            Console.WriteLine("Turma cadastrada com sucesso.");

            return true;
        }

        public Turma retornaTurma(int idTurma)
        {
            Turma t = null;

            for (int i = 0; i < turmas.Count; i++)
            {
                if (turmas[i].getId() == idTurma)
                {
                    t = turmas[i];
                    break;
                }
            }

            if (t == null)
            {
                Console.WriteLine("Turma não encontrado.");
            }

            return t;
        }
        public bool associaTurma()
        {
            Console.WriteLine("Insira a matrícula do aluno:");
            Aluno aluno = this.retornaAluno(Convert.ToInt32(Console.ReadLine()));
            
            if (aluno == null)
            {
                return false;
            }

            Console.WriteLine("Insira o código da turma a inserir o aluno " + aluno.Nome + ":");
            Turma turma = this.retornaTurma(Convert.ToInt32(Console.ReadLine()));

            if (turma == null)
            {
                return false;
            }

            turma.addAluno(aluno);
            return true;
        }

        public bool associaTurma(Aluno aluno)
        { 
            Console.WriteLine("Insira o código da turma a inserir o aluno " + aluno.Nome + ":");
            Turma turma = this.retornaTurma(Convert.ToInt32(Console.ReadLine()));

            if (turma == null)
            {
                return false;
            }

            turma.addAluno(aluno);
            aluno.setTurma(turma);
            return true;
        }

        public bool desassociaTurma()
        {
            Aluno aluno;

            Console.WriteLine("Insira a matrícula do aluno que deseja desassociar:");

            aluno = this.retornaAluno(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("Insira o código da turma a retirar o aluno " + aluno.Nome + ":");
            Turma turma = this.retornaTurma(Convert.ToInt32(Console.ReadLine()));

            if (turma == null || !aluno.retornaTurma().Equals(turma))
            {
                return false;
            }

            turma.removeAluno(aluno.Matricula);
            aluno.setTurma(null);
            return true;
        }

        public bool removeTurma()
        {
            Console.WriteLine("Insira o id da turma a retirar:");
            int id = Convert.ToInt32(Console.ReadLine());
            
            Turma t = this.retornaTurma(id);

            if (t == null)
            {
                return false;
            }

            if (t.tamanhoTurma() > 0)
            {
                Console.WriteLine("Há alunos na turma. Não pode ser removida.");
                return false;
            }

            this.turmas.Remove(t);
            Console.WriteLine("Turma removida.");
            return true;
        }

        public void addAluno()
        {
            Aluno aluno;

            Console.WriteLine("Insira o nome do aluno.");

            do
            {
                aluno = new Aluno(Console.ReadLine());
            } while (this.retornaAluno(aluno.Matricula) != null);

            alunos.Add(aluno);

            Console.WriteLine("Aluno inserido com a matrícula: " + aluno.Matricula + ".");

            Console.WriteLine("Deseja associar o aluno a uma turma? (S/N)");
            if (Console.ReadLine().ToUpper() == "S")
            {
                this.associaTurma(aluno);
            }
        }

        public Aluno retornaAluno(int matricula)
        {
            Aluno a = null;

            for (int i = 0; i < alunos.Count; i++)
            {
                if (alunos[i].Matricula.Equals(matricula))
                {
                    a = alunos[i];
                }
            }
            if (a == null)
            {
                Console.WriteLine("Aluno não encontrado.");
            }

            return a;
        }

        public bool removeAluno(int matricula)
        {
            Aluno aluno = this.retornaAluno(matricula);

            if (aluno == null)
            {
                return false;
            }

            if (aluno.retornaTurma() != null)
            {
                Console.WriteLine("O aluno está matriculado em uma turma. Não pode ser removido.");
                return false;
            }

            this.alunos.Remove(aluno);
            Console.WriteLine("Aluno removido.");
            return true;
        }
        public void imprimeAlunos()
        {
            Console.WriteLine("Insira o id da turma que deseja imprimir: ");
            Turma turma = retornaTurma(Convert.ToInt32(Console.ReadLine()));

            turma.imprimeNomes();
        }
        public void imprimeTudo()
        {
            
            List<Turma> turmasEmOrdem = turmas.OrderBy(turma => turma.getId()).ToList();

            for (int i = 0; i < turmasEmOrdem.Count; i++)
            {
                Turma turma = turmasEmOrdem[i];
                Console.WriteLine("Turma:                       " + turma.getId().ToString());
                turma.imprimeNomes();
                Console.WriteLine("--------------------FIM-DA-TURMA-------------------------");
            }

            Console.WriteLine("--------------------------------------------------");
        }


    }
}
