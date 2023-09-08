namespace WeCare.Data.Data
{
    public interface ILoginData
    {
        Task<bool> CheckUser(string userName, string password);
        Task<bool> IsUserSuperUser(string userName, string password);
    }
}