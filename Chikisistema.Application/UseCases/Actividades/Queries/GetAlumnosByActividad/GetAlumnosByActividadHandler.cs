using Chikisistema.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetAlumnosByActividad
{
    public class GetAlumnosByActividadHandler : IRequestHandler<GetAlumnosByActividadQuery, GetAlumnosByActividadResponse>
    {
        private readonly IChikisistemaDbContext db;

        public GetAlumnosByActividadHandler(IChikisistemaDbContext db)
        {
            this.db = db;
        }

        public async Task<GetAlumnosByActividadResponse> Handle(GetAlumnosByActividadQuery request, CancellationToken cancellationToken)
        {
            var respuestas = await db
                .ActividadCurso
                .Where(el => el.Id == request.IdActividad)
                .Select(el => new GetAlumnosByActividadResponse
                {
                    IdActividad = el.Id,
                    TituloActividad = el.Titulo,
                    PuedeCalificar = el.BloquearEnvios,
                    CalificacionMaxima = el.Valor,
                    Respuestas = el.UsuarioActividades.Select(respuesta => new GetAlumnosByActividadResponse.RespuestaAlumnos
                    {
                        ApellidoMaterno = respuesta.IdUsuarioNavigation.ApellidoMaterno,
                        ApellidoPaterno = respuesta.IdUsuarioNavigation.ApellidoPaterno,
                        Contenido = respuesta.Contenido,
                        IdUsuario = respuesta.IdUsuario,
                        Nombre = respuesta.IdUsuarioNavigation.Nombre,
                        NombreUsuario = respuesta.IdUsuarioNavigation.NombreUsuario,
                        Archivo = respuesta.Archivo.Hash,
                        ContentTypeArchivo = respuesta.Archivo.ContentType,
                        NombreArchivo = respuesta.Archivo.Nombre,
                        Calificacion = respuesta.Calificacion
                    })
                }).
                SingleOrDefaultAsync();

            return respuestas;
        }
    }
}