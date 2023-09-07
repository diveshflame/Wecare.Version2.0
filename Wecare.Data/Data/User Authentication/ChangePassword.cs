using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCare.Data.DataAccess;
using WeCare.Data.Model;

namespace WeCare.Data.Data
{
    public class ChangePassword : IChangePassword
    {
        private readonly ISqldataAccess _db;
        public ChangePassword(ISqldataAccess db)
        {
            _db = db;
        }


        // the SQL command to update the password
        string sqlCommand = @"
                UPDATE Users
                SET Password = @NewPassword
                WHERE UserName = @UserName
                AND Password = @CurrentPassword";

        public async Task<bool> UpdatePasswosrd(string userName, string currentPassword, string newPassword)
        {


            var parameters = new { UserName = userName, CurrentPassword = currentPassword, NewPassword = newPassword };

            try
            {
                //the command to update the password
                await _db.SaveData(sqlCommand, parameters);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Password update failed.", ex);
            }
        }
    }
}
