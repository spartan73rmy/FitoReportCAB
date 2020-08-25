using Chikisistema.Application.Interfaces;
using Chikisistema.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Archivos.Commands.AgregarArchivo
{
    public class AgregarArchivoHandler : IRequestHandler<AgregarArchivoCommand, AgregarArchivoResponse>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IFileService fileService;
        private readonly IUserAccessor currentUser;

        public AgregarArchivoHandler(IChikisistemaDbContext db, IFileService fileService, IUserAccessor currentUser)
        {
            this.db = db;
            this.fileService = fileService;
            this.currentUser = currentUser;
        }

        public async Task<AgregarArchivoResponse> Handle(AgregarArchivoCommand request, CancellationToken cancellationToken)
        {
            string hash = await fileService.SaveFile(request.Archivo);
            var nuevoArchivo = new ArchivoUsuario
            {
                ContentType = request.ContentType,
                Hash = hash,
                IdUsuario = currentUser.UserId,
                Nombre = request.Nombre
            };

            db.ArchivoUsuario.Add(nuevoArchivo);

            await db.SaveChangesAsync(cancellationToken);
            
            return new AgregarArchivoResponse
            {
                Hash = hash
            };
        }
    }
}