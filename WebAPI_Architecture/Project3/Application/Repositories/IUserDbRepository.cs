using Domain;

namespace Application.Repositories;

public interface IUserDbRepository
{ 
    Task<List<User>> GetAllAsync();

    Task<User> GetUserAsync(int id);

    Task AddUserAsync(User user);

    Task UpdateUserAsync(int id, User user);

    Task RemoveUserAsync(int id);

    Task<int> SaveChangesAsync();
}