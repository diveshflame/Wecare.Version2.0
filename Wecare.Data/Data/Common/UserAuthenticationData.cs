using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCare.Data.DataAccess;
using WeCare.Data.Model;

namespace Wecare.Data.Data.User_Authentication
{
    public class UserAuthenticationData : IUserAuthenticationData
    {
        private readonly ISqldataAccess _db;

        public UserAuthenticationData(ISqldataAccess db)
        {
            _db = db;
        }
        #region UserRegistration
        public async Task Register(UserModel User)
        {
            string sqlCommand = @"
                INSERT INTO Users (UserName, FullName, Age, Gender, Email, Phone, Password)
                VALUES (@UserName, @FullName, @Age, @Gender, @Email, @Phone, @Password)";
            await _db.SaveData(sqlCommand, User);
        }
        #endregion

        #region CheckIfPatient
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
            var result = await _db.LoadData<int, dynamic>(sqlCommand, parameters);
            return result.FirstOrDefault() > 0;

        }
        #endregion

        #region CheckIfAdmin
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

            var result = await _db.LoadData<int, dynamic>(sqlCommand, parameters);
            return result.FirstOrDefault() > 0;
        }
        #endregion

        #region ChangePassword
        public async Task<bool> UpdatePasswosrd(string userName, string currentPassword, string newPassword)
        {
            string sqlCommand = @"
                UPDATE Users
                SET Password = @NewPassword
                WHERE UserName = @UserName
                AND Password = @CurrentPassword";

            var parameters = new { UserName = userName, CurrentPassword = currentPassword, NewPassword = newPassword };

            await _db.SaveData(sqlCommand, parameters);
            return true;

        }
        #endregion
    }
}
