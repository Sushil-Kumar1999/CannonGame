using CannonGame.Entities;
using CannonGame.Interfaces;
using CannonGame.Services;
using Moq;

namespace CannonGame.Tests;

public class UserDataServiceTests
{
    private readonly Mock<IJsonFileIO> _jsonFileIO;

    public UserDataServiceTests()
    {
        _jsonFileIO = new Mock<IJsonFileIO>();
    }

    [Fact]
    public void GetUsers_GetsAllUsers()
    {
        _jsonFileIO.Setup(x => x.ListData<User>())
            .Returns(new List<User> { new User("A", 1, 1) });

        UserDataService userDataService = new UserDataService(_jsonFileIO.Object);
        userDataService.GetUsers();

        _jsonFileIO.Verify(x => x.ListData<User>(), Times.Exactly(1));
    }

    [Fact]
    public void AddUser_UpdatesUserData_WithNewUser()
    {
        IList<User> savedUserData = new List<User>();
        _jsonFileIO.Setup(x => x.ListData<User>())
            .Returns(new List<User>
            { 
                new User("A", 10, 1),
                new User("B", 9, 1),
                new User("C", 8, 1),
                new User("D", 2, 1),
                new User("E", 1, 1),
            });
        _jsonFileIO.Setup(x => x.UpdateData(It.IsAny<IList<User>>()))
            .Callback<IList<User>>(x => savedUserData = x);

        UserDataService userDataService = new UserDataService(_jsonFileIO.Object);
        userDataService.AddUser(new User("F", 5, 1));

        _jsonFileIO.Verify(x => x.ListData<User>(), Times.Exactly(1));
        _jsonFileIO.Verify(x => x.UpdateData(It.IsAny<IList<User>>()), Times.Exactly(1));
        var expectedSavedUserData = new List<User>
        {
            new User("A", 10, 1),
            new User("B", 9, 1),
            new User("C", 8, 1),
            new User("F", 5, 1),
            new User("D", 2, 1)
        };

        Assert.Equal(expectedSavedUserData, savedUserData);
    }
}
