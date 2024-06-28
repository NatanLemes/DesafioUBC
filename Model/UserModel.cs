
namespace DesafioUBC.Model
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserModel(string username, string password)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }
        //int Id(identificador único)
        //string Username(nome de usuário)
        //string Password(senha)


    }
}
