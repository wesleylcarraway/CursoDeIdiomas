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

            CreateMap<Aluno, AlunoMinimalResponse>();
            CreateMap<Turma, TurmaMinimalResponse>();

            CreateMap<AlunoBaseRequest, Aluno>();
            CreateMap<AlunoAddRequest, Aluno>();
            CreateMap<AlunoUpdateRequest, Aluno>();  

            CreateMap<TurmaRequest, Turma>();         
        }
    }
}
