using mysos_web_api.Entities;

namespace mysos_web_api.Repositories
{
    public interface IUserRepository
    {
        Task<bool> Add(User user);
        Task<bool> Update(User user);
        Task<User?> Find(int id);
        List<User> GetAll();
        Task<bool> Remove(int id);
        Task<bool> Update(int id);
    }
}
