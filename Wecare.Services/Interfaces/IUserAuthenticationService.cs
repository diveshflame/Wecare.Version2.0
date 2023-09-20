using WeCare.Data.Model;


namespace Wecare.Services.Interfaces
{
    public interface IUserAuthenticationService
    {
        Task Register(UserModel user);
        Task<bool> CheckUser(string userName, string password);
        Task<bool> IsUserSuperUser(string userName, string password);
        Task<bool> UpdatePassword(string userName, string currentPassword, string newPassword);
    }
}
