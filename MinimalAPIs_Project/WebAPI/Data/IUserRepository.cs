public interface IUserRepository : IDisposable
{
    Task<List<User>> GetUsersAsync();

    Task<User> GetUserAsync(int id);

    Task CreateUserAsync(User user);

    Task UpdateUserAsync(int id, User user);

    Task RemoveUserAsync(int id);

    Task SaveAsync();
}