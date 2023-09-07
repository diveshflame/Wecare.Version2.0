using WeCare.Data.Model;

namespace WeCare.Data.Data
{
    public interface IRegistrationData
    {
        Task Register(UserModel User);
    }
}