using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio2
{
    public class Aluno
    {
        private String _nome;
        private int _matricula;
        private float _notaFinal;
        private Turma turma;
        public string Nome
        { 
            get => _nome; 
            private set => _nome = value; 
        }

        public int Matricula
        {
            get => _matricula; 
            private set => _matricula = value; 
        }

        private int p1;
        private int p2;

        public Aluno(string nome)
        {
            Random r = new Random();
            _nome = nome;
            _matricula = r.Next(10000000, 100000000);
        }

        public Aluno(string nome, Turma turma)
        {
            Random r = new Random();
            _nome = nome;
            _matricula = r.Next(10000000, 100000000);
            this.turma = turma;
        }

        public Turma retornaTurma()
        {
            return this.turma;
        }

        public void setTurma(Turma turma)
        {
            this.turma = turma;
        }

        public int getP1()
        {
            return p1;
        }

        public void setP1(int nota)
        {
            this.p1 = nota;
        }

        public int getP2()
        {
            return p2;
        }

        public void setP2(int nota)
        {
            this.p2 = nota;
        }

        public float getNF()
        {
            return _notaFinal;
        }

        public void setNF()
        {
            this._notaFinal = (float)((this.p1 + this.p2) / 2.0);
        }
        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Aluno other = (Aluno)obj;
                return this._matricula.Equals(other._matricula);
            }
        }
    }
}
