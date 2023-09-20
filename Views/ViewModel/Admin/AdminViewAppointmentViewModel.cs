using MVVM_App.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Views.Model;
using Wecare.Services.Interfaces;
using Wecare.Services.Service;

namespace Views.ViewModel.Admin
{
     class AdminViewAppointmentViewModel:ViewModelBase
    {
        private ObservableCollection<AppointmentModel> appointmentModel;
        public ObservableCollection<AppointmentModel> AppointmentModel { get => appointmentModel; set { appointmentModel = value; OnPropertyChanged(nameof(AppointmentModel)); } }

        #region Commands
        public ICommand ViewAllAppointment { get; }
        public ICommand ViewTodayAppointment { get; }
        public ICommand ViewAppointmentHistory { get; }

        private readonly IAdminViewAppointmentService _adminViewAppointmentService;

        #endregion

        public AdminViewAppointmentViewModel(IAdminViewAppointmentService viewAppointmentService)
        {
            _adminViewAppointmentService = viewAppointmentService;
            ViewAllAppointment = new ViewModelCommand(ExecuteViewAllAppointment);
            ViewTodayAppointment = new ViewModelCommand(ExecuteViewTodayAppointment);
            ViewAppointmentHistory = new ViewModelCommand(ExecuteViewAppointmentHistory);
        }

        #region Execute Command
        private void ExecuteViewAppointmentHistory(object obj)
        {
            _adminViewAppointmentService.GetAllAppointments();
        }

        private void ExecuteViewTodayAppointment(object obj)
        {
            _adminViewAppointmentService.GetTodayAppointment();
        }

        private void ExecuteViewAllAppointment(object obj)
        {
            _adminViewAppointmentService.GetAppointmentHistory(); ;
        }
        #endregion
       

    }
}
