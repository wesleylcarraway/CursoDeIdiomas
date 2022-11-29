using CursoDeIdiomas.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CursoDeIdiomas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaService _matriculaService;

        public MatriculaController(IMatriculaService matriculaService)
        {
            _matriculaService = matriculaService;
        }

        [HttpPost]
        [Route("se-registrar-em-uma-turma/{alunoId:int}/{turmaId:int}")]
        public async Task<IActionResult> RegisterForClassRoom(int alunoId, int turmaId)
        {
            await _matriculaService.Register(turmaId, alunoId);
            return Ok("Matrícula feita com sucesso.");
        }
    }
}
