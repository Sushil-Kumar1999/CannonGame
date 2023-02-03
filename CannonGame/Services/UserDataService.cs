using CannonGame.Entities;
using CannonGame.Interfaces;

namespace CannonGame.Services;

public class UserDataService : IUserDataService
{
    private readonly IJsonFileIO _fileIO;
    private const int ListSize = 5;

    public UserDataService(IJsonFileIO fileIO)
    {
        _fileIO = fileIO;
    }

    public IList<User> GetUsers()
    {
        return _fileIO.ListData<User>();
    }

    public void AddUser(User user)
    {
        IList<User> userData = GetUsers();
        userData.Add(user);
        userData = userData.OrderByDescending(user => user.Score).Take(ListSize).ToList();

        _fileIO.UpdateData(userData);
    }
}
