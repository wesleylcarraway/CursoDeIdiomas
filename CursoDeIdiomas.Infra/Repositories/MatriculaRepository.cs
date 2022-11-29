using CursoDeIdiomas.Domain.Interfaces;
using CursoDeIdiomas.Domain.Models;
using CursoDeIdiomas.Infra.Context;

namespace CursoDeIdiomas.Infra.Repositories
{
    public class MatriculaRepository : BaseRepository<Matricula>, IMatriculaRepository
    {
        public MatriculaRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
