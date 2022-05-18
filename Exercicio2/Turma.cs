using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio2
{
    public class Turma
    {
        private List<Aluno> _alunos = new List<Aluno>();
        private int idTurma;
        public Turma(int id)
        {
            idTurma = id;
        }

        public Aluno retornaAluno (int matricula)
        {
            Aluno a = null;

            for (int i = 0; i < _alunos.Count; i++)
            {
                if (_alunos[i].Matricula.Equals(matricula))
                {
                    a = _alunos[i];
                }
            }
            if (a == null)
            {
                Console.WriteLine("Aluno não encontrado.");        
            }
            
            return a;
        }

        public int getId()
        {
            return idTurma;
        }

        public Turma retornaTurma(int id)
        {
            Turma turma = null;

            if (this.idTurma == id)
            {
                turma = this;
            }

            return turma;

        }
        public void addAluno()
        {
            Aluno aluno;

            Console.WriteLine("Insira o nome do aluno.");
            aluno = new Aluno(Console.ReadLine());

            _alunos.Add(aluno);

            Console.WriteLine("Aluno inserido com a matrícula: " + aluno.Matricula + ".");
        }

        public void addAluno(Aluno aluno)
        {
            _alunos.Add(aluno);

            Console.WriteLine("Aluno inserido com a matrícula: " + aluno.Matricula + ".");
        }

        public bool removeAluno(int matrigula)
        {
            Aluno aluno = this.retornaAluno(matrigula);

            if (aluno != null)
            {
                String nome = aluno.Nome;
                _alunos.Remove(aluno);
                Console.WriteLine("Aluno " + nome + " removido.");
                return true;
            }

            Console.WriteLine("Aluno não cadastrado.");
            return false;
        }

        public int tamanhoTurma()
        {
            return this._alunos.Count;
        }

        public void lancarP1()
        {
            int matricula;
            Aluno aluno;

            Console.WriteLine("Digite a matrícula do aluno.");
            matricula = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite a nota P1 do aluno.");
            int nota = Convert.ToInt32(Console.ReadLine());
            aluno = retornaAluno(matricula);

            if (aluno != null)
            {
                aluno.setP1(nota);
                Console.WriteLine("Nota atribuída ao aluno " + aluno.Nome);
            }
        }

        public void lancarP2()
        {
            int matricula;
            Aluno aluno;

            Console.WriteLine("Digite a matrícula do aluno.");
            matricula = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite a nota P2 do aluno.");
            int nota = Convert.ToInt32(Console.ReadLine());
            aluno = retornaAluno(matricula);

            if (aluno != null)
            {
                aluno.setP2(nota);
                Console.WriteLine("Nota atribuída ao aluno " + aluno.Nome);
                aluno.setNF();
            }
        }

        private float mediaP1()
        {
            float mediaP1;
            int somaNotas = 0;

            for (int i = 0; i < _alunos.Count; i++)
            {
                somaNotas += _alunos[i].getP1();
            }

            mediaP1 = (float)(somaNotas / _alunos.Count);

            return mediaP1;

        }

        private float mediaP2()
        {
            float mediaP2;
            int somaNotas = 0;

            for (int i = 0; i < _alunos.Count; i++)
            {
                somaNotas += _alunos[i].getP2();
            }

            mediaP2 = (float)(somaNotas / _alunos.Count);

            return mediaP2;

        }

        private float mediaTurma()
        {
            float mediaTurma, somaMedias = 0;

            for (int i = 0; i < _alunos.Count; i++)
            {
                somaMedias += _alunos[i].getNF();
            }

            mediaTurma = (somaMedias / _alunos.Count);

            return mediaTurma;
        }

        private Aluno retornaMaiorNF()
        {
            Aluno a = _alunos[0];

            for (int i = 1; i < _alunos.Count; i++)
            {
                if (_alunos[i].getNF() > a.getNF())
                {
                    a = _alunos[i];
                }
            }

            return a;
        }

        public void imprimeNomes()
        {
            if (_alunos == null)
            {
                Console.WriteLine("Turma não possui alunos.");
                return;
            }

            List<Aluno> alunosEmOrdem = _alunos.OrderBy(aluno => aluno.Nome).ToList();

            Console.WriteLine(String.Format("{0,-20}\n", "Aluno"));
            for (int i = 0; i < alunosEmOrdem.Count; i++)
            {
                Aluno aluno = alunosEmOrdem[i];
                Console.Write(String.Format("{0}\n", aluno.Nome));
            }

            Console.WriteLine("--------------------------------------------------");
        }
        public void imprime()
        {
            if (_alunos == null)
            {
                Console.WriteLine("Turma não possui alunos.");
                return;
            }

            List<Aluno> alunosEmOrdem = _alunos.OrderBy(aluno => aluno.Nome).ToList();

            Console.WriteLine(String.Format("{0,-20} {1,-20}\n\n", "Aluno", "Nota final"));
            for (int i = 0; i < alunosEmOrdem.Count; i++)
            {
                Aluno aluno = alunosEmOrdem[i];
                Console.Write(String.Format("{0}                           {1:2f}\n", aluno.Nome, aluno.getNF().ToString("0.00")));
            }

            Console.WriteLine("--------------------------------------------------");
        }

        public void imprimeEstatistica()
        {
            int somaNotas = 0;
            float mediaP1 = this.mediaP1();
            float mediaP2 = this.mediaP2();
            float mediaTurma = this.mediaTurma();
            Aluno alunoMaiorNF = this.retornaMaiorNF();

            Console.WriteLine(String.Format("Média da P1:{0,-20}\n" +
                                            "Média da P2:{1,-20}\n" +
                                            "Média da NF da Turma:{2,-20}\n" +
                                            "Aluno com a maior NF:{3,-20}", 
                                            mediaP1.ToString("0.00"), mediaP2.ToString("0.00"), mediaTurma.ToString("0.00"), alunoMaiorNF.Nome));
            Console.WriteLine("--------------------------------------------------");
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            Turma other = (Turma)obj;
            return this.idTurma.Equals(other.idTurma);
        }

    }
}
