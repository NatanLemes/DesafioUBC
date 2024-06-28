using DesafioUBC.Context;
using DesafioUBC.DataModel;
using DesafioUBC.Interfaces;
using DesafioUBC.Model;
using DesafioUBC.Uteis;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace DesafioUBC.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DatabaseContext _dbcontext;

        public StudentRepository(DatabaseContext dbcontext) => _dbcontext = dbcontext;

        public StudentRepository(){}

        public List<StudentDataModel> BuscaTodosEstudantes() => _dbcontext.Students.ToList();
        public StudentDataModel BuscaEstudantePorId(int id) => _dbcontext.Students.FirstOrDefault(b => b.Id == id) ?? new StudentDataModel();

        public StudentDataModel AdicionaEstudante(StudentModel estudante)
        {
            StudentDataModel studentDataModel = new StudentDataModel();
            studentDataModel.Id = this.BuscaTodosEstudantes().Count ==0 ? 0 : this.BuscaTodosEstudantes().Last().Id + 1;
            studentDataModel.Nome = estudante.Nome;
            studentDataModel.Idade = estudante.Idade;
            studentDataModel.Serie = estudante.Serie;
            studentDataModel.NotaMedia = estudante.NotaMedia;
            studentDataModel.Endereco = estudante.Endereco;
            studentDataModel.NomePai = estudante.NomePai;
            studentDataModel.NomeMae = estudante.NomeMae;
            studentDataModel.DataNascimento = estudante.DataNascimento;

            _dbcontext.Students.Add(studentDataModel);
            this.Salvar();

            return studentDataModel;
        }

        public StudentDataModel AlteraEstudante(StudentModel estudante, int id)
        {
            StudentDataModel EstudanteAltera = this.BuscaEstudantePorId(id);

            if (EstudanteAltera.Id == 0) return new StudentDataModel();

            EstudanteAltera.Nome = estudante.Nome;
            EstudanteAltera.Idade = estudante.Idade;
            EstudanteAltera.Serie = estudante.Serie;
            EstudanteAltera.NotaMedia = estudante.NotaMedia;
            EstudanteAltera.Endereco = estudante.Endereco;
            EstudanteAltera.NomePai = estudante.NomePai;
            EstudanteAltera.NomeMae = estudante.NomeMae;
            EstudanteAltera.DataNascimento = estudante.DataNascimento;

            this.Salvar();

            return EstudanteAltera;
        }

        public void DeletaEstudante(int id)
        {
            //var Estudantes = this.BuscaTodosEstudantes();
            //Estudantes.Remove(this.BuscaEstudantePorId(id));
            var debug = _dbcontext.Students.Remove(this.BuscaEstudantePorId(id));
            this.Salvar();
        }

        public void Salvar()
        {
            _dbcontext.SaveChanges();
        }
        
        //Uso exclusivo para carregar a base de dados
        public void CarregaBaseCSV(List<StudentDataModel> students)
        {
            //_dbcontext.Students.Concat(students);
            
            students.ForEach(student =>
            {
                _dbcontext.Students.Add(student);
            });
            this.Salvar();
        }
    }
}
