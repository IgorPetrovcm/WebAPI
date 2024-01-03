namespace Persistence.EntityTypeConfiguration;

public class DbInitialize
{
    public void Initialize(NotesContext context)
    {
        context.Database.EnsureCreated();
    }
}   