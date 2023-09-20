using Autofac;


namespace WeCare.Data.DataAccess
{
    class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqldataAccess>().As<ISqldataAccess>();
        }
    }
}
