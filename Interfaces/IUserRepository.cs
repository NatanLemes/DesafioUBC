using DesafioUBC.DataModel;
using DesafioUBC.Model;

namespace DesafioUBC.Interfaces
{
    public interface IUserRepository
    {
        List<UserDataModel> BuscaTodosUsers();
        UserDataModel BuscaUserPorId(int id);
        UserDataModel AdicionaUser(UserModel user);
        UserDataModel AlteraUser(UserModel user, int id);
        void DeletaUser(int id);
        void Salvar();
        string Login(string username, string password);
        string CriarToken(UserDataModel usuario);
    }
}
