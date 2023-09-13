using Autofac.Features.ResolveAnything;
using Autofac;
using System.Windows;
using Views.View.Admin;
using Wecare.Services.Interfaces;
using Wecare.Services.Service;
using Views.View.Common;
using Views.ViewModel.Common;

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
            var builder = new ContainerBuilder();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
          
            builder.RegisterType<DoctorService>().As<IDoctorService>().SingleInstance();
            builder.RegisterType<TestWindow>().AsSelf();
            
            IContainer container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
               /* AddDoctorViewModel viewModel = container.Resolve<AddDoctorViewModel>();*/
               var window=scope.Resolve<TestWindow>();   
                window.Show();  
            }



        }                           
    }
}
