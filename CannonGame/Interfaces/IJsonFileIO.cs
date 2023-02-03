namespace CannonGame.Interfaces;

public interface IJsonFileIO
{
    public IList<TData> ListData<TData>();
    public void UpdateData<TData>(IList<TData> data);
}
