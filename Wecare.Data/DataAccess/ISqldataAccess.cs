using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeCare.Data.DataAccess
{
    public interface ISqldataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string sqlCommand, U parameters, string ConnectionId = "Default");
        Task SaveData<T>(string sqlCommand, T parameters, string ConnectionId = "Default");
    }
}