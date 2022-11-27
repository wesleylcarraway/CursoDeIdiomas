using CursoDeIdiomas.Domain.Interfaces;
using CursoDeIdiomas.Domain.Models;
using CursoDeIdiomas.Infra.Context;

namespace CursoDeIdiomas.Infra.Repositories
{
    public class TurmaRepository : BaseRepository<Turma>, ITurmaRepository
    {
        public TurmaRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
