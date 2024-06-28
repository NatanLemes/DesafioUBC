using DesafioUBC.Interfaces;
using DesafioUBC.Model;
using DesafioUBC.Uteis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DesafioUBC.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
            => _repository = repository;

        [HttpGet]
        public async Task<IActionResult> GetUsersModels()
        {
            return Ok(_repository.BuscaTodosUsers());
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetUserModelsById(int id)
        {
            return Ok(_repository.BuscaUserPorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddUSerModels(UserModel obj)
        {
            return Ok(_repository.AdicionaUser(obj));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserModels(int id, [FromBody] UserModel obj)
        {
            return Ok(_repository.AlteraUser(obj, id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserModels(int id)
        {
            _repository.DeletaUser(id);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserModel obj)
        {
            var retorno = _repository.Login(obj.Username, obj.Password);
            if (retorno.IsNullOrEmpty())
            {
                return NotFound("Login Invalido");
            }
            return Ok(retorno);
        }

    }
}
