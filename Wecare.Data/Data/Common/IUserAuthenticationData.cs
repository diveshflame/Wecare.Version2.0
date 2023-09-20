using System.Threading.Tasks;
using WeCare.Data.Model;

namespace Wecare.Data.Data.User_Authentication
{
    public interface IUserAuthenticationData
    {
        Task<bool> CheckUser(string userName, string password);
        Task<bool> IsUserSuperUser(string userName, string password);
        Task Register(UserModel User);
        Task<bool> UpdatePasswosrd(string userName, string currentPassword, string newPassword);
    }
}