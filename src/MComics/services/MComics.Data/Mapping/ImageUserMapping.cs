using MComics.Data.Mapping.ModelsData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MComics.Data.Mapping
{
    public class ImageUserMapping : IEntityTypeConfiguration<ImageUser>
    {
        public void Configure(EntityTypeBuilder<ImageUser> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.URL).IsRequired();

            builder.ToTable("ImagemUsuario");
        }
    }
}
