using DesafioUBC.Context;
using DesafioUBC.DataModel;
using DesafioUBC.Interfaces;
using DesafioUBC.Model;
using DesafioUBC.Uteis;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DesafioUBC.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _dbcontext;

        //public readonly ITokenJWT _token;
        private readonly IConfiguration _config;

        public UserRepository(DatabaseContext dbcontext, IConfiguration config)
        {
            _dbcontext = dbcontext;
            _config = config;
        }
        public List<UserDataModel> BuscaTodosUsers() => _dbcontext.Users.ToList();

        public UserDataModel BuscaUserPorId(int id) => _dbcontext.Users.FirstOrDefault(b => b.Id == id) ?? new UserDataModel();

        public UserDataModel AdicionaUser(UserModel user)
        {
            UserDataModel userDataModel = new UserDataModel();
            userDataModel.Id = this.BuscaTodosUsers().Count == 0 ? 0 : this.BuscaTodosUsers().Last().Id + 1;
            userDataModel.Username = user.Username;
            userDataModel.Password = CriptografiaPassword.ComputeMd5Hash(user.Password);

            _dbcontext.Users.Add(userDataModel);
            this.Salvar();

            return userDataModel;
        }

        public UserDataModel AlteraUser(UserModel user, int id)
        {
            UserDataModel UserAltera = this.BuscaUserPorId(id);

            if (UserAltera.Id == 0) return new UserDataModel();

            UserAltera.Username = user.Username;
            UserAltera.Password = CriptografiaPassword.ComputeMd5Hash(user.Password);

            this.Salvar();

            return UserAltera;
        }

        public void DeletaUser(int id)
        {
            var debug = _dbcontext.Users.Remove(this.BuscaUserPorId(id));
            this.Salvar();
        }

        public void Salvar()
        {
            _dbcontext.SaveChanges();
        }

        public string Login(string username, string password)
        {
            var usuarioLogin = _dbcontext.Users.FirstOrDefault(x => x.Username == username && x.Password == CriptografiaPassword.ComputeMd5Hash(password));
            if (usuarioLogin == null || usuarioLogin.Equals(new UserDataModel()))
            {
                return "";
            }
            var token = this.CriarToken(usuarioLogin);

            return token;
        }

        public string CriarToken(UserDataModel usuario)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("username", usuario.Username),
                new Claim("id", usuario.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
