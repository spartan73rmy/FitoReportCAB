using Chikisistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.Interfaces
{
    public interface IChikisistemaDbContext
    {
        DbSet<ActividadCurso> ActividadCurso { get; set; }
        DbSet<AlumnoCurso> AlumnoCurso { get; set; }
        DbSet<ArchivoUsuario> ArchivoUsuario { get; set; }
        DbSet<Curso> Curso { get; set; }
        DbSet<Materia> Materia { get; set; }
        DbSet<Mensaje> Mensaje { get; set; }
        DbSet<TipoActividad> TipoActividad { get; set; }
        DbSet<Unidad> Unidad { get; set; }
        DbSet<Usuario> Usuario { get; set; }
        DbSet<UsuarioActividad> UsuarioActividad { get; set; }
        DbSet<MaterialApoyoActividad> MaterialApoyoActividad { get; set; }
        DbSet<UsuarioToken> UsuarioToken { get; set; }
        DbSet<TokenDescargaArchivo> TokenDescargaArchivo { get; set; }
        DbSet<ComentarioActividad> ComentarioActividad { get; set; }
        DbSet<PostForo> PostForo { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
    }
}
