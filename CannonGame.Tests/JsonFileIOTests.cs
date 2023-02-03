using CannonGame.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CannonGame.Tests;

public class JsonFileIOTests
{
    private string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "userdata.json");

    private class TestUser
    {
        public TestUser(string username, int score, float timeElapsed)
        {
            Username = username;
            Score = score;
            TimeElapsed = timeElapsed;
        }

        public override bool Equals(object obj)
        {
            var other = obj as TestUser;
            if (other == null) return false;

            return Username == other.Username && Score == other.Score && TimeElapsed == other.TimeElapsed;
        }

        public string Username { get; }
        public int Score { get; }
        public float TimeElapsed { get; }
    }

    [Fact]
    public void GivenFileExists_WhenListDataCalled_ThenFileDataIsReturned()
    {
        var mockFileSystem = new MockFileSystem();
        var mockFileData = new MockFileData("""
            [
                {
                    "username" : "Test",
                    "score" : 23,
                    "timeElapsed" : 50
                }                                     
            ]
         """);
        mockFileSystem.AddFile(filePath, mockFileData);

        JsonFileIO jsonFileIO = new JsonFileIO(mockFileSystem);
        IList<TestUser> actualOutput = jsonFileIO.ListData<TestUser>();

        IList<TestUser> expectedOutput = new List<TestUser> { new TestUser("Test", 23, 50) };

        Assert.Equal(expectedOutput, actualOutput);
    }

    [Fact]
    public void GivenFileExists_WheUpdateDataCalled_ThenDataIsWrittenToFile()
    {
        var mockFileSystem = new MockFileSystem();
        var mockFileData = new MockFileData("");
        mockFileSystem.AddFile(filePath, mockFileData);
        IList<TestUser> testData = new List<TestUser>{ new TestUser("Test2", 22, 50) };

        JsonFileIO jsonFileIO = new JsonFileIO(mockFileSystem);
        jsonFileIO.UpdateData(testData);

        Console.WriteLine(mockFileData.ToString());
        MockFileInfoFactory factory = (MockFileInfoFactory)jsonFileIO._fileSystem.FileInfo;
        string savedData = factory.FileSystem.File.OpenText(filePath).ReadToEnd();
        string expectedData = """[{"Username":"Test2","Score":22,"TimeElapsed":50}]""";

        Assert.Equal(expectedData, savedData);
    }

    //[Fact]
    //public void GivenNoFileExists_WhenListDataCalled_ThenNewFileCreated()
    //{
    //    var mockFileSystem = new MockFileSystem();
    //    mockFileSystem.AddFile()
    //    var mockFile = new MockFile;

    //    mockFile.Setup(f => f.Exists(It.IsAny<string>())).Returns(false);
    //    mockFile.Setup(f => f.Create(filePath));

    //    JsonFileIO jsonFileIO = new JsonFileIO(mockFileSystem);
    //    IList<TestUser> actualOutput = jsonFileIO.ListData<TestUser>();

    //    mockFile.Verify(f => f.Exists(It.IsAny<string>()), Times.Once);
    //}
}
