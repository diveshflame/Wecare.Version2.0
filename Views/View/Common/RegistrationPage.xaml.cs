using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Views.ViewModel;
using Views.ViewModel.Common;
using Wecare.Services.Interfaces;

namespace Views.View.Common
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Window
    {
        private SecureString enteredPassword = new SecureString();
        private bool isMasked = false;
        private string originalText;

        private IUserAuthenticationService userAuthenticationService;
        public RegistrationPage(IUserAuthenticationService userAuthService)
        {
            InitializeComponent();
            userAuthenticationService = userAuthService;
            var registrationViewModel = new RegistrationViewModel(userAuthenticationService);

            DataContext = registrationViewModel();
        }

        private void MaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isMasked)
            {
                originalText = confirmTxtbox.Text;
                confirmTxtbox.Text = MaskText(confirmTxtbox.Text);
            }
            else
            {
                confirmTxtbox.Text = originalText;
            }
            isMasked = !isMasked;
        }

        private string MaskText(string input)
        {
            return new string('*', input.Length);
        }

        private string UnmaskText(string input)
        {
            // Simply return the input
            return input.Replace("*", "");
        }

    }
}

