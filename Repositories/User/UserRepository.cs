using mysos_web_api.Data;
using mysos_web_api.Entities;

namespace mysos_web_api.Repositories
{
    public class UserRepository : IUserRepository
    {
        ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Add(User user)
        {
            _dbContext.Users.Add(user);

            if (await _dbContext.SaveChangesAsync() != 0)
                return true;

            return false;

        }

        public async Task<bool> Update(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> Find(int id)
        {
            return await _dbContext.FindAsync<User>(id);
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
