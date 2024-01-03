namespace Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Domain;


public interface INotesContext
{ 
    DbSet<Note> Notes { get; set; }

    Task<int> SaveChangesAsync(CancellationToken token);
}