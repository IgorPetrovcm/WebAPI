namespace Persistence;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Persistence.EntityTypeConfiguration;
using Domain;

public class NotesContext : DbContext, INotesContext
{
    public DbSet<Note> Notes { get; set; }

    public NotesContext(DbContextOptions<NotesContext> option) : base(option) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration<Note>(new NoteConfiguration());
        
        base.OnModelCreating(builder);
    }
}