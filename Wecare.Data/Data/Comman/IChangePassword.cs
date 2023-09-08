namespace WeCare.Data.Data
{
    public interface IChangePassword
    {
        Task<bool> UpdatePasswosrd(string userName, string currentPassword, string newPassword);
    }
}