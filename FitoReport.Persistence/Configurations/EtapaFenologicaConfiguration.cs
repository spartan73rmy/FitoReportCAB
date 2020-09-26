using FitoReport.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitoReport.Persistence.Configurations
{
    public class EtapaFenologicaConfiguration : IEntityTypeConfiguration<EtapaFenologica>
    {
        public void Configure(EntityTypeBuilder<EtapaFenologica> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(el => el.Nombre)
           .IsRequired()
           .IsUnicode(true);
        }
    }
}
