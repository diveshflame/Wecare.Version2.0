namespace Wecare.Data.Data.Interface
{
    public interface ISqldataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string sqlCommand, U parameters, string ConnectionId = "Default");
        Task SaveData<T>(string Command, T parameters, string ConnectionId = "Default");

    }
}