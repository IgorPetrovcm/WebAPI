using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Application;


public class NoteConfiguration : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Id).IsUnique();

        builder.Property(x => x.Title).HasMaxLength(50);
        
    }
}