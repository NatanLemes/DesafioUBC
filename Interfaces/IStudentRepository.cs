using DesafioUBC.DataModel;
using DesafioUBC.Model;

namespace DesafioUBC.Interfaces
{
    public interface IStudentRepository
    {
        List<StudentDataModel> BuscaTodosEstudantes();
        StudentDataModel BuscaEstudantePorId(int id);
        StudentDataModel AdicionaEstudante(StudentModel estudante);
        StudentDataModel AlteraEstudante(StudentModel estudante, int id);
        void DeletaEstudante (int id);
        void Salvar();
        void CarregaBaseCSV(List<StudentDataModel> lista);
    }
}
