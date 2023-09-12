﻿using Autofac.Features.ResolveAnything;
using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Views.View;
using Views.View.Admin;
using Wecare.Services.Interfaces;
using Wecare.Services.Service;
using Views.ViewModel.Admin;
using static Views.View.AddDoctor;
using Microsoft.OpenApi.Writers;
using Views.View.Common;
using Wecare.Services.Interfaces;
using Wecare.Services.Service;
using System.Windows.Documents;
using Wecare.Services.Service;
using Wecare.Services.Interfaces;
using Views.ViewModel.Admin;

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


            builder.RegisterType<ViewAppointmentService>().As<IViewAppointmentService>().SingleInstance();

            //builder.RegisterType<TestWindow>().AsSelf();


            IContainer container = builder.Build();
            AdminViewAppointmentViewModel adminViewAppointmentViewModel = container.Resolve<AdminViewAppointmentViewModel>();
           

                //using (var scope = container.BeginLifetimeScope())

                //{

                //    /* AddDoctorViewModel viewModel = container.Resolve<AddDoctorViewModel>();*/

                //    //var window = scope.Resolve<TestWindow>();

                //    window.Show();

                //}


            }
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
