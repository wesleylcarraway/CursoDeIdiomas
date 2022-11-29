using CursoDeIdiomas.Application.Interfaces;
using CursoDeIdiomas.Application.Params;
using CursoDeIdiomas.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using CursoDeIdiomas.Application.ViewModels.Turma;

namespace CursoDeIdiomas.API.Controllers
{
    [ApiController]
    [Route("api/turmas")]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaService _turmaService;

        public TurmaController(ITurmaService turmaService)
        {
            _turmaService = turmaService;
        }

        [HttpGet]
        public async Task<PaginationResponse<TurmaResponse>> GetAsync([FromQuery] TurmaParams queryParams)
        {
            var data = await _turmaService.GetAsync(queryParams);
            return new PaginationResponse<TurmaResponse>
            {
                Data = data,
                Total = data.Count(),
                Take = queryParams.Take,
                Skip = queryParams.Skip,
            };
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TurmaResponse>> GetByIdAsync(int id)
        {
            return await _turmaService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<TurmaResponse>> PostAsync([FromBody] TurmaRequest turma)
        {
            return await _turmaService.AddAsync(turma);
        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult<TurmaResponse>> PutAsync([FromBody] TurmaRequest turma, [FromRoute] int id)
        {
            return await _turmaService.UpdateAsync(turma, id);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TurmaResponse>> DeleteAsync(int id)
        {
            return await _turmaService.RemoveAsync(id);
        }
    }
}
