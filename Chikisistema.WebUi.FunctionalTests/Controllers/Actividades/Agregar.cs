using Chikisistema.Application.UseCases.Actividades.Commands.AgregarActividad;
using Chikisistema.Common;
using Chikisistema.WebUi.FunctionalTests.Common;
using Chikisistema.WebUi.FunctionalTests.Mocks;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Chikisistema.WebUi.FunctionalTests.Controllers.Actividades
{
    public class Agregar : BaseTestController
    {
        public Agregar(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task AgregaCorrectamenteActividad()
        {
            var client = await GetMaestroClientAsync();
            var pet = new AgregarActividadCommand
            {
                IdUnidad = 2,
                IdTipoActividad = 1,
                Titulo = "Descripcion",
                Contenido = "ajkak",
                Valor = 40,
                FechaLimite = new System.DateTime(2080, 01, 10),
                FechaActivacion = new System.DateTime(2079, 01, 10)
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Actividades/Agregar", content);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<AgregarActividadResponse>(response);

            Assert.IsType<AgregarActividadResponse>(result);
            Assert.Equal(pet.IdUnidad, result.IdUnidad);
            Assert.Equal(pet.IdTipoActividad, result.IdTipoActividad);
            Assert.True(result.Id > 0);
        }

        [Fact]
        public async Task AgregaCorrectamenteActividadSinFechaActivacion()
        {
            var client = await GetMaestroClientAsync();
            var pet = new AgregarActividadCommand
            {
                IdUnidad = 2,
                IdTipoActividad = 1,
                Titulo = "Descripcion",
                Contenido = "ajkak",
                Valor = 40,
                FechaLimite = new System.DateTime(2080, 01, 10)
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Actividades/Agregar", content);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<AgregarActividadResponse>(response);

            Assert.IsType<AgregarActividadResponse>(result);
            Assert.Equal(pet.IdUnidad, result.IdUnidad);
            Assert.Equal(pet.IdTipoActividad, result.IdTipoActividad);
            Assert.True(result.Id > 0);
        }

        [Fact]
        public async Task AgregactividadSinFechaLimiteBadRequest()
        {
            var client = await GetMaestroClientAsync();
            var pet = new AgregarActividadCommand
            {
                IdUnidad = 2,
                IdTipoActividad = 1,
                Titulo = "Descripcion",
                Contenido = "ajkak",
                Valor = 40,
                FechaActivacion = new System.DateTime(2080, 01, 10)
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Actividades/Agregar", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task AgregactividadFechaLimiteMenorActivacionBadRequest()
        {
            var client = await GetMaestroClientAsync();
            var pet = new AgregarActividadCommand
            {
                IdUnidad = 2,
                IdTipoActividad = 1,
                Titulo = "Descripcion",
                Contenido = "ajkak",
                Valor = 40,
                FechaActivacion = new System.DateTime(2080, 01, 10),
                FechaLimite = new System.DateTime(2079, 01, 10)
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Actividades/Agregar", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task AgregactividadFechaLimiteMenorFechaActualBadRequest()
        {
            DateTime fechaActual = new DateTime(2020, 01, 09, 06, 00, 00, DateTimeKind.Utc);
            var client = await GetMaestroClientAsync(services =>
            {
                services.AddSingleton<IDateTime, DateTimeMock>(imp => new DateTimeMock(fechaActual));
            });
            var pet = new AgregarActividadCommand
            {
                IdUnidad = 2,
                IdTipoActividad = 1,
                Titulo = "Descripcion",
                Contenido = "ajkak",
                Valor = 40,
                FechaActivacion = fechaActual.AddMinutes(-5),
                FechaLimite = fechaActual.AddMinutes(-10)
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Actividades/Agregar", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}