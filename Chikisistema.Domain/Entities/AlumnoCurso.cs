namespace Chikisistema.Domain.Entities
{
    public partial class AlumnoCurso : BaseEntity
    {
        public int IdCurso { get; set; }
        public int IdAlumno { get; set; }

        public virtual Usuario IdAlumnoNavigation { get; set; }
        public virtual Curso IdCursoNavigation { get; set; }
    }
}
