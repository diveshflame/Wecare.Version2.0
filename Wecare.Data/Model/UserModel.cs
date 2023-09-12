using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeCare.Data.Model
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public int ?Age { get; set; }
        public string Gender { get; set; }
        public string Email_Address { get; set; }
        public string Phone_Number { get; set; }
        public string Password { get; set; }
        public int Active_Session { get; set; }
        public int Super_User { get; set;}

    }
}
