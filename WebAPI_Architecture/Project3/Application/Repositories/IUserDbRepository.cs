using Domain;

namespace Application.Repositories;

public interface IUserDbRepository
{ 
    Task<List<User>> GetAllAsync();

    Task<User> GetUserAsync(int id);

    Task AddUserAsync(User user);

    Task UpdateUserAsync(User user);

    Task RemoveUserAsync(User user);

    Task<int> SaveChangesAsync();
}