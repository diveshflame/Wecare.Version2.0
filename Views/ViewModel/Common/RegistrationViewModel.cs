using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Views.Model;
using Views.ViewModel.Admin;
using Wecare.Services.Interfaces;
using System.ComponentModel;
using Microsoft.Win32;
using Wecare.Services.Service;
using WeCare.Data.Model;
using Microsoft.VisualBasic.ApplicationServices;
using MVVM_App.ViewModels;

namespace Views.ViewModel.Common
{
    public class RegistrationViewModel : ViewModelBase
    {
        private UserDetails _userDetails;
        private List<string> _genders;

        public event PropertyChangedEventHandler PropertyChanged;

        public UserDetails UserDetails
        {
            get { return _userDetails; }
            set
            {
                _userDetails = value;
                OnPropertyChanged(nameof(UserDetails));
            }
        }

        public List<string> Genders
        {
            get { return _genders; }
            set
            {
                _genders = value;
                OnPropertyChanged(nameof(_genders));
            }
        }

        public ICommand RegisterCommand { get; set; }
        private IUserAuthenticationService userAuthService;

        public RegistrationViewModel(IUserAuthenticationService userAuthService)
        {
            this.userAuthService = userAuthService;
            UserDetails = new UserDetails();
            Genders = new List<string> { "Male", "Female", "Other" }; //To Be Changed
            RegisterCommand = new ViewModelCommand(Register, CanRegister);
        }

        private async void Register(object obj)
        {
            var userModel = new UserModel
            {
                UserName = UserDetails.Username,
                Name = UserDetails.FullName,
                Age = (int)UserDetails.Age,
                Gender = UserDetails.Gender,
                Email_Address = UserDetails.Email,
                Phone_Number = UserDetails.PhoneNumber,
                Password = UserDetails.Password
            };
            try
            {
                await userAuthService.Register(userModel);
            }
            catch (Exception ex)
            {
                
            }
        }

        private bool CanRegister(object obj)
        {
            return true; 
        }
    }
}
