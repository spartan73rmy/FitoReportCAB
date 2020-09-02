﻿using Chikisistema.Application.Interfaces;
using Chikisistema.Common;
using Chikisistema.Domain;
using Chikisistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Persistence
{
    public partial class ChikisistemaDbContext : DbContext, IFitoReportDbContext
    {
        private readonly IDateTime time;
        public ChikisistemaDbContext(DbContextOptions<ChikisistemaDbContext> options, IDateTime time)
            : base(options)
        {
            this.time = time;
        }

        public ChikisistemaDbContext(DbContextOptions<ChikisistemaDbContext> options)
            : base(options)
        {

        }
        public bool IsSoftDeleteFilterEnabled => true;
        public virtual DbSet<ArchivoUsuario> ArchivoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioToken> UsuarioToken { get; set; }
        public DbSet<TokenDescargaArchivo> TokenDescargaArchivo { get; set; }
        public DbSet<Reporte> Reporte { get; set; }
        public DbSet<Plaga> Plaga { get; set; }
        public DbSet<Enfermedad> Enfermedad { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<ReporteEnfermedad> ReporteEnfermedad { get; set; }
        public DbSet<ReportePlaga> ReportePlaga { get; set; }

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
        {
            return this.Database.BeginTransactionAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = time.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.Modified = time.Now;
                        break;
                    case EntityState.Deleted:
                        if (entry.Entity is DeleteableEntity deleaetableEntity)
                        {
                            entry.State = EntityState.Modified;
                            deleaetableEntity.DeletedDate = time.Now;
                            deleaetableEntity.IsDeleted = true;
                        }
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChikisistemaDbContext).Assembly);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(DeleteableEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType).AddQueryFilter<DeleteableEntity>(e => IsSoftDeleteFilterEnabled == false || e.IsDeleted == false);
                }
            }

            // Si la entidad es de tipo DateTime se encarga de convertirlo a UTC
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime))
                    {
                        modelBuilder.Entity(entityType.ClrType)
                         .Property<DateTime>(property.Name)
                         .HasConversion(
                          v => v.ToUniversalTime(),
                          v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
                    }
                    else if (property.ClrType == typeof(DateTime?))
                    {
                        modelBuilder.Entity(entityType.ClrType)
                         .Property<DateTime?>(property.Name)
                         .HasConversion(
                          v => v.HasValue ? v.Value.ToUniversalTime() : v,
                          v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v);
                    }
                }
            }
        }
    }
}
