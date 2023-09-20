using Autofac;
using Wecare.Services.Interfaces;
using Wecare.Services.Service;

public class AppModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
       
        builder.RegisterType<DoctorService>().As<IDoctorService>();

    }
}