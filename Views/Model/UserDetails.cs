

namespace Views.Model
{
    public class UserDetails
    {
        private string userName;
        private string fullName;
        private int? age;
        private string gender;
        private string email;
        private string phoneNumber;
        private string password;
        private string confirmPassword;
        private string changeUsername;
        private string changePassword;

        public string Username { get { return userName; } set { userName = value; } }

        public string FullName { get { return fullName; } set { fullName = value; } }

        public int? Age { get { return age; } set { age = value; } }

        public string Gender { get { return gender; } set { gender = value; } }

        public string Email { get { return email; } set { email = value; } }

        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }

        public string Password { get { return password; } set { password = value; } }

        public string ConfirmPassword { get { return confirmPassword; } set { confirmPassword = value; } }

        public string ChangeUsername { get { return changeUsername; } set { changeUsername = value; } }
        public string ChangePassword { get { return changePassword; } set { changePassword = value; } }
    }
}
