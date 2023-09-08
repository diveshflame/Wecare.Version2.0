using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCare.Data.DataAccess;

namespace WeCare.Data.Data
{
    public class LoginData : ILoginData
    {
        private readonly ISqldataAccess _db;

        public LoginData(ISqldataAccess db)
        {
            _db = db;
        }

        public async Task<bool> CheckUser(string userName, string password)
        {
            // the SQL command to check if the user exists and SuperUser column is 0
            string sqlCommand = @"
                SELECT COUNT(*)
                FROM Users
                WHERE UserName = @UserName
                AND Password = @Password
                AND SuperUser = 0";

            var parameters = new { UserName = userName, Password = password };

            try
            {
                var result = await _db.LoadData<int, dynamic>(sqlCommand, parameters);
                return result.FirstOrDefault() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("User checking failed.", ex);
            }
        }

        public async Task<bool> IsUserSuperUser(string userName, string password)
        {
            // the SQL command to check if the user is a SuperUser (SuperUser column is 1)
            string sqlCommand = @"
                SELECT COUNT(*)
                FROM Users
                WHERE UserName = @UserName
                AND Password = @Password
                AND SuperUser = 1";

            var parameters = new { UserName = userName, Password = password };

            try
            {
                var result = await _db.LoadData<int, dynamic>(sqlCommand, parameters);
                return result.FirstOrDefault() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("SuperUser checking failed.", ex);
            }
        }
    }
}
