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
using Autofac;
using Views.ViewModel.Common;

namespace Views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IContainer container;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var builder = new ContainerBuilder();

            // Register services and view models
            builder.RegisterType<UserAuthenticationService>().As<IUserAuthenticationService>();
            builder.RegisterType<RegistrationViewModel>();

            container = builder.Build();

            // Resolving the main window and setting its DataContext
            var mainWindow = new RegistrationPage();
            var registrationViewModel = container.Resolve<RegistrationViewModel>();
            mainWindow.DataContext = registrationViewModel;
            mainWindow.Show();
        }
    }
}
