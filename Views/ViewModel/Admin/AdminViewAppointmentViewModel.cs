using MVVM_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Views.View;
using Wecare.Services.Interfaces;
using WeCare.Data.Model;

namespace Views.ViewModel.Admin
{
    public class AdminViewAppointmentViewModel:ViewModelBase
    {
        private ObservableCollection<AppointmentModel> appointmentModel;
        public ObservableCollection<AppointmentModel> AppointmentModel { get => appointmentModel; set { appointmentModel = value; OnPropertyChanged(nameof(AppointmentModel)); } }

        #region Commands
        public ICommand ViewAllAppointment { get; }
        public ICommand ViewTodayAppointment { get; }
        public ICommand ViewAppointmentHistory { get; }

        private readonly IViewAppointmentService _viewAppointmentService;

        #endregion

        public AdminViewAppointmentViewModel(IViewAppointmentService viewAppointmentService)
        {
            _viewAppointmentService = viewAppointmentService;
            ViewAllAppointment = new ViewModelCommand(ExecuteViewAllAppointment);
            ViewTodayAppointment = new ViewModelCommand(ExecuteViewTodayAppointment);
            ViewAppointmentHistory = new ViewModelCommand(ExecuteViewAppointmentHistory);
        }

        #region Execute Command
        private void ExecuteViewAppointmentHistory(object obj)
        {
            _viewAppointmentService.GetAllAppointments();
        }

        private void ExecuteViewTodayAppointment(object obj)
        {
            _viewAppointmentService.GetTodayAppointment();
        }

        private void ExecuteViewAllAppointment(object obj)
        {
            _viewAppointmentService.GetAppointmentHistory(); ;
        }
        #endregion
       

    }
}
