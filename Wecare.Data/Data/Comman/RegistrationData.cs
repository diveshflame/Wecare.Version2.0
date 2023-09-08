using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCare.Data.DataAccess;
using WeCare.Data.Model;

namespace WeCare.Data.Data
{
    public class RegistrationData : IRegistrationData
    {
        private readonly ISqldataAccess _db;

        public RegistrationData(ISqldataAccess db)
        {
            _db = db;
        }

        public async Task Register(UserModel User)
        {
            if (User == null)
                throw new ArgumentNullException(nameof(User));

            string sqlCommand = @"
                INSERT INTO Users (UserName, FullName, Age, Gender, Email, Phone, Password)
                VALUES (@UserName, @FullName, @Age, @Gender, @Email, @Phone, @Password)";

            try
            {
                await _db.SaveData(sqlCommand, User);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the registration process
                throw new Exception("User registration failed.", ex);
            }
        }
    }
}
