namespace Libertese.Model
{
    public interface IUserRepository
    {
        void Add(User user);

        List<User> Get();

        User GetByEmail(string email);
    }
}
