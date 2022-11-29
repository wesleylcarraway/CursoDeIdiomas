using CursoDeIdiomas.Application.Interfaces;
using CursoDeIdiomas.Application.Params;
using CursoDeIdiomas.Application.ViewModels;
using CursoDeIdiomas.Application.ViewModels.Aluno;
using Microsoft.AspNetCore.Mvc;

namespace CursoDeIdiomas.API.Controllers
{
    [ApiController]
    [Route("api/alunos")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public async Task<PaginationResponse<AlunoResponse>> GetAsync([FromQuery] AlunoParams queryParams)
        {
            var data = await _alunoService.GetAsync(queryParams);
            return new PaginationResponse<AlunoResponse>
            {
                Data = data,
                Total = data.Count(),
                Take = queryParams.Take,
                Skip = queryParams.Skip,
            };
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AlunoResponse>> GetByIdAsync(int id)
        {
            return await _alunoService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<AlunoResponse>> PostAsync([FromBody] AlunoAddRequest aluno)
        {
            return await _alunoService.AddAsync(aluno);
        }

        [HttpPut("{id:int}")]
       
        public async Task<ActionResult<AlunoResponse>> PutAsync([FromBody] AlunoUpdateRequest aluno, [FromRoute] int id)
        {
            return await _alunoService.UpdateAsync(aluno, id);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<AlunoResponse>> DeleteAsync(int id)
        {
            return await _alunoService.RemoveAsync(id);
        }
    }
}
