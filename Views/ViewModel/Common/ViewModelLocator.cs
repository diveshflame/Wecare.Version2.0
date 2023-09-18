
using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Views.ViewModel.Admin;
using Wecare.Services.Interfaces;
using Wecare.Services.Service;
using WeCare.Data.DataAccess;

namespace Views.ViewModel.Common
{
    public class ViewModelLocator
    {
        private readonly IContainer _container;

        public ViewModelLocator(IContainer container)
        {
            _container = container;
        }

        public AddDoctorViewModel MainViewModel => _container.Resolve<AddDoctorViewModel>();
    }
}

