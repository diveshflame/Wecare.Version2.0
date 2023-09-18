
using Autofac;
using System.Windows;

using Microsoft.Extensions.DependencyInjection;
using System;
using Views.ViewModel.Admin;
using Wecare.Services.Interfaces;
using Wecare.Services.Service;
using Views.View.Admin;
using Views.ViewModel.Common;
using Wecare.Data.Data.Common;
using WeCare.Data.Data.Doctor;
using WeCare.Data.DataAccess;
using System.Configuration;
using System.Threading.Tasks;
using System.Configuration;

namespace Views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IContainer _container;


        public App()
        {
            ConfigureContainer();
        }

        public void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
      
            builder.RegisterType<SqldataAccess>().As<ISqldataAccess>();
            builder.RegisterType<DoctorService>().As<IDoctorService>();
            builder.RegisterType<DoctorData>().As<IDoctorData>();
            builder.RegisterType<CommonFunctions>().As<ICommonFunctions>(); 
            builder.RegisterType<AddDoctorViewModel>();
            _container = builder.Build();
        
        }


        protected override void OnStartup( StartupEventArgs e)
        {
            base.OnStartup(e);
            var viewModelLocator = new ViewModelLocator(_container);
            var mainWindow = new TestWindow();
            mainWindow.DataContext = viewModelLocator.MainViewModel;
            mainWindow.Show();
        }
    }
    }
