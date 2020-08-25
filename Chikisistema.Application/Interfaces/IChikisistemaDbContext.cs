using Chikisistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.Interfaces
{
    public interface IChikisistemaDbContext
    {
        DbSet<Reporte> Reporte { get; set; }
        DbSet<ArchivoUsuario> ArchivoUsuario { get; set; }
        DbSet<Usuario> Usuario { get; set; }
        DbSet<UsuarioToken> UsuarioToken { get; set; }
        DbSet<TokenDescargaArchivo> TokenDescargaArchivo { get; set; }
        DbSet<Plaga> Plaga { get; set; }
        DbSet<Enfermedad> Enfermedad { get; set; }
        DbSet<Producto> Producto { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
    }
}
