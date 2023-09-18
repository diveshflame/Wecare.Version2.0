using Autofac;
using Wecare.Services.Interfaces;
using Wecare.Services.Service;

public class AppModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // Register your services and implementations here
        builder.RegisterType<DoctorService>().As<IDoctorService>();

    }
}