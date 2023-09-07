using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeCare.Data.Model
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ChangePassword { get; set; }

    }
}
