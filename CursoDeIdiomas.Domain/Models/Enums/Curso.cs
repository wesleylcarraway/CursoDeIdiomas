using CursoDeIdiomas.Domain.Core;

namespace CursoDeIdiomas.Domain.Models.Enums
{
    public class Curso : Enumeration
    {
        public static Curso Portugues = new Curso(1, nameof(Portugues));
        public static Curso Ingles = new Curso(2, nameof(Ingles));
        public static Curso Espanhol = new Curso(3, nameof(Espanhol));

        public Curso(int id, string name) : base(id, name)
        { }
    }
}
