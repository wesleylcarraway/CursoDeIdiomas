using AutoMapper;
using CursoDeIdiomas.Application.Extensions;
using CursoDeIdiomas.Application.ViewModels.Aluno;
using CursoDeIdiomas.Application.ViewModels.Curso;
using CursoDeIdiomas.Application.ViewModels.Turma;
using CursoDeIdiomas.Domain.Models;
using CursoDeIdiomas.Domain.Models.Enums;

namespace CursoDeIdiomas.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Aluno, AlunoResponse>();
            CreateMap<Turma, TurmaResponse>();
            CreateMap<Curso, CursoResponse>();

            CreateMap<AlunoRequest, Aluno>()
                .MergeList(x => x.Turmas, vm => vm.Turmas);

            CreateMap<AlunoSemCadastroDeTurmasRequest, Aluno>();
                
            CreateMap<TurmaRequest, Turma>()
                .MergeList(x => x.Alunos, vm => vm.Alunos);

            CreateMap<TurmaSemCadastroDeAlunosRequest, Turma>();
        }
    }
}
