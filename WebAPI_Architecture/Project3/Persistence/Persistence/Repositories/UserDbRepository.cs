using System.Reflection.Metadata.Ecma335;
using  Application.Repositories;
using Persistence.DataContext;
using Domain;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Persistence.Repositories;

public class UserDbRepository : IUserDbRepository
{
    private readonly ApplicationContext _context;

    public UserDbRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserAsync(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddUserAsync(User user)
    {
        if (user.Name != "")
            await _context.Users.AddAsync(user);
        else return;
    }

    public async Task UpdateUserAsync(User user)
    {
        User updateUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

        if (updateUser == null)
            return;
        
        updateUser = user;

        _context.Users.Update(updateUser);
    }

    public async Task RemoveUserAsync(User user)
    {
        _context.Users.Remove(user);
    }

    public async Task<int> SaveChangesAsync()
    {
        int result = await _context.SaveChangesAsync();
        return result;
    }

    public ApplicationContext GetContext()
    {
        return _context;
    }
}