using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wecare.Data.Data.Interface;
using WeCare.Data.Data;
using WeCare.Data.Model;

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
