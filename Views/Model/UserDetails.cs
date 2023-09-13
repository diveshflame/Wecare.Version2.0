

namespace Views.Model
{
    public class UserDetails
    {
        private string _username;
        private string _fullName;
        private int? _age;
        private string _gender;
        private string _email;
        private string _phoneNumber;
        private string _password;
        private string _confirmPassword;

        private string _changeUsername;
        private string _changePassword;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
            }
        }


        public string FullName
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
            }
        }

        public int? Age
        {
            get { return _age; }
            set
            {
                _age = value;
            }
        }


        public string Gender
        {
            get { return _gender; }
            set
            {
                _gender = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
            }
        }

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
            }
        }

        public string ChangeUsername { get { return _changeUsername; } set { _changeUsername = value; } }
        public string ChangePassword { get { return _changePassword; } set { _changePassword = value; } }
    }
}
