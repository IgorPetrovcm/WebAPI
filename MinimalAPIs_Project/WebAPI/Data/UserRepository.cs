


public class UserRepository : IUserRepository
{
    private readonly UserDb _context;

    public UserRepository(UserDb context)
    {
        _context = context;
    }

    public Task<List<User>> GetUsersAsync()
    {
        return _context.users.ToListAsync();
    }

    public async Task<User> GetUserAsync(int id)
    {
        return await _context.users.FindAsync(id);
    }

    public async Task CreateUserAsync(User user)
    {
        await _context.users.AddAsync(user);
    }

    public async Task RemoveUserAsync(int id)
    {
        User user = await _context.users.FindAsync(id);
        if (user == null) return;
        _context.users.Remove(user);
    }

    public async Task UpdateUserAsync(int id, User user)
    {
        User currentUser = await _context.users.FindAsync(id);
        if (currentUser == null) return;

        currentUser.Name = user.Name;
        currentUser.Age = user.Age;
        
        _context.users.Update(currentUser);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    private bool _disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}