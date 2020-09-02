using FitoReport.Application.UseCases.Reportes.Commands.AgregarReporte;
using FitoReport.Common;
using FitoReport.WebUi.FunctionalTests.Common;
using FitoReport.WebUi.FunctionalTests.Mocks;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace FitoReport.WebUi.FunctionalTests.Controllers.Actividades
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
            var pet = new AgregarReporteCommand
            {
        
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Actividades/Agregar", content);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<AgregarReporteResponse>(response);

            Assert.IsType<AgregarReporteResponse>(result);
            //Assert.Equal(pet.IdUnidad, result.IdUnidad);
            //Assert.Equal(pet.IdTipoActividad, result.IdTipoActividad);
            Assert.True(result.Id > 0);
        }

        [Fact]
        public async Task AgregaCorrectamenteActividadSinFechaActivacion()
        {
            var client = await GetMaestroClientAsync();
            var pet = new AgregarReporteCommand
            {
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Actividades/Agregar", content);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<AgregarReporteResponse>(response);

            Assert.IsType<AgregarReporteResponse>(result);
            //Assert.Equal(pet.IdUnidad, result.IdUnidad);
            //Assert.Equal(pet.IdTipoActividad, result.IdTipoActividad);
            Assert.True(result.Id > 0);
        }

    }
}