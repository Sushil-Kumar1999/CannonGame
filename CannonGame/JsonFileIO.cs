using CannonGame.Interfaces;
using System.Text.Json;
using Newtonsoft.Json;
using System.IO.Abstractions;

namespace CannonGame;

public class JsonFileIO : IJsonFileIO
{
    private readonly string filePath;
    public readonly IFileSystem _fileSystem;

    public JsonFileIO(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
        filePath = _fileSystem.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "userdata.json");
    }

    public IList<TData> ListData<TData>()
    {
        CreateFileIfNotExists();

        string json = _fileSystem.File.ReadAllText(filePath);
        IList<TData> dataList = JsonConvert.DeserializeObject<List<TData>>(json) ?? new List<TData>();

        return dataList;
    }

    public void UpdateData<TData>(IList<TData> data)
    {
        CreateFileIfNotExists();

        string jsonString = System.Text.Json.JsonSerializer.Serialize(data);
        _fileSystem.File.WriteAllText(filePath, jsonString);
    }

    private void CreateFileIfNotExists()
    {
        if (!_fileSystem.File.Exists(filePath))
        {
            _fileSystem.File.Create(filePath).Close();
        }
    }
}
