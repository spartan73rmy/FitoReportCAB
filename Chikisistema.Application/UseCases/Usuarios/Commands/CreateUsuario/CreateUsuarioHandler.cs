using Chikisistema.Application.Interfaces;
using Chikisistema.Application.Security;
using Chikisistema.Common;
using Chikisistema.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Usuarios.Commands.CreateUsuario
{
    public class CreateUsuarioHandler : IRequestHandler<CreateUsuarioCommand, CreateUsuarioResponse>
    {
        private readonly IMediator mediator;
        private readonly IChikisistemaDbContext db;
        private readonly IDateTime dateTime;
        private readonly IRandomGenerator randomGenerator;

        public CreateUsuarioHandler(IChikisistemaDbContext db, IMediator mediator, IDateTime dateTime, IRandomGenerator randomGenerator)
        {
            this.mediator = mediator;
            this.db = db;
            this.dateTime = dateTime;
            this.randomGenerator = randomGenerator;
        }

        public async Task<CreateUsuarioResponse> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            string pass = PasswordStorage.CreateHash(request.Password);

            var user = new Usuario
            {
                Email = request.Email,
                NombreUsuario = request.NombreUsuario,
                HashedPassword = pass,
                TipoUsuario = request.TipoUsuario,
                Confirmado = false,
                FechaRegistro = dateTime.Now,
                TokenConfirmacion = randomGenerator.Guid(),
                ApellidoMaterno = request.ApellidoMaterno,
                ApellidoPaterno = request.ApellidoPaterno,
                Nombre = request.Nombre,
                NormalizedEmail = request.Email.ToUpper(),
                NormalizedUserName = request.NombreUsuario.ToUpper()
            };
            db.Usuario.Add(user);

            await db.SaveChangesAsync(cancellationToken);

            string mensaje = "Usuario Creado, espere a que el Administrador Confirme su Cuenta";

            if (user.TipoUsuario == Domain.Enums.TiposUsuario.Alumno)
            {
                mensaje = "Usuario Creado, revise su correo para poder Acceder por primera vez";
                await mediator.Publish(new CreateUsuarioNotificate { IdUsuario = user.Id }, cancellationToken);
            }

            return new CreateUsuarioResponse
            {
                Id = user.Id,
                Email = user.Email,
                NombreUsuario = user.NombreUsuario,
                NotificationMessage = mensaje,
                ApellidoMaterno = user.ApellidoMaterno,
                ApellidoPaterno = user.ApellidoPaterno,
                Nombre = user.Nombre
            };
        }
    }
}