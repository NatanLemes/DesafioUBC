using DesafioUBC.Context;
using DesafioUBC.DataModel;
using DesafioUBC.Interfaces;
using DesafioUBC.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace DesafioUBC.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IStudentRepository _repository;

        public StudentController(IStudentRepository repository)
            => _repository = repository;

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetStudentModels()
        {
            return Ok(_repository.BuscaTodosEstudantes());
        }

        [Authorize]
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetStudentModelsById(int id)
        {
            return Ok(_repository.BuscaEstudantePorId(id));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddStudentModels(StudentModel obj)
        {
            return Ok(_repository.AdicionaEstudante(obj));
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudentModels(int id, [FromBody]StudentModel obj)
        {
            return Ok(_repository.AlteraEstudante(obj, id));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentModels(int id)
        {
            _repository.DeletaEstudante(id);
            return Ok();
        }
    }
}
