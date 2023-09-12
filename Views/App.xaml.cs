using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Views.View.Common;
using Wecare.Services.Interfaces;
using Wecare.Services.Service;

namespace Views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IUserAuthenticationService userAuthService = new UserAuthenticationService();

            var window = new RegistrationPage(userAuthService);

            window.Show();
        }
    }
}
