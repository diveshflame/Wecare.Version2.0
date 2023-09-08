using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wecare.Services.Interfaces;
using WeCare.Data.Model;

namespace Wecare.Services
{
    public class UserAuthenticationService :IUserAuthenticationService
    {
        private readonly IUserAuthenticationService _userAuthenticationData;

        public UserAuthenticationService(IUserAuthenticationService userAuthenticationData)
        {
            _userAuthenticationData = userAuthenticationData;
        }

        public async Task Register(UserModel user)
        {
            await _userAuthenticationData.Register(user);
        }

        public async Task<bool> CheckUser(string userName, string password)
        {
            if(await _userAuthenticationData.CheckUser(userName, password) == true)
                return true;
            return false;
        }

        public async Task<bool> IsUserSuperUser(string userName, string password)
        {
            if(await _userAuthenticationData.IsUserSuperUser(userName, password) == true)
                return true;
            return false;
        }

        public async Task<bool> UpdatePassword(string userName, string currentPassword, string newPassword)
        {
            return await _userAuthenticationData.UpdatePassword(userName, currentPassword, newPassword);
        }
    }
}
