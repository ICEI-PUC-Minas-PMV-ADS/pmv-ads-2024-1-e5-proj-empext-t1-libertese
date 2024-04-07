namespace Libertese_PrimeiroAcesso.Model
{
    public interface IUserRepository
    {
        void Add(User user);

        List<User> Get();
    }
}
