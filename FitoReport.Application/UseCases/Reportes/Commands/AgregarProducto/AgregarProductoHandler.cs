using FitoReport.Application.Exceptions;
using FitoReport.Application.Interfaces;
using FitoReport.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Reportes.Commands.AgregarProducto
{
    public class AgregarProductoHandler : IRequestHandler<AgregarProductoCommand, AgregarProductoResponse>
    {
        private readonly IFitoReportDbContext db;

        public AgregarProductoHandler(IFitoReportDbContext db)
        {
            this.db = db;
        }

        public async Task<AgregarProductoResponse> Handle(AgregarProductoCommand request, CancellationToken cancellationToken)
        {
            Producto entity = new Producto
            {
                Cantidad = request.Cantidad,
                NombreProducto = request.NombreProducto,
                IngredienteActivo = request.IngredienteActivo,
                Concentracion = request.Concentracion,
                IntervaloSeguridad = request.IntervaloSeguridad
            };

            db.Producto.Add(entity);
            await db.SaveChangesAsync(cancellationToken);

            return new AgregarProductoResponse
            {
                Id = entity.Id,
                Cantidad = entity.Cantidad,
                NombreProducto = entity.NombreProducto,
                IngredienteActivo = entity.IngredienteActivo,
                Concentracion = entity.Concentracion,
                IntervaloSeguridad = entity.IntervaloSeguridad
            };
        }
    }
}
