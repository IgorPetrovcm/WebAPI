public class UserDb : DbContext
{
    public UserDb(DbContextOptions<UserDb> options) : base(options) {}

    public DbSet<User> users => Set<User>();
}