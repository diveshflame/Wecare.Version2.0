using MVVM_App.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows;
using Wecare.Services.Service;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Views.ViewModel.Admin
{
    public class UpdateDoctorViewModel : ViewModelBase
    {
        //Fileds
        private List<string> doctorNames;
        private List<string> consult;
        private string selectedDoctorName;
        private string selectedConsultationtype;
        public List<string> DoctorNames { get => doctorNames; set { doctorNames = value; OnPropertyChanged(nameof(DoctorNames)); } }

        public List<string> Consult { get => consult; set { consult = value; OnPropertyChanged(nameof(Consult)); } }

        public string SelectedDoctorName { get => selectedDoctorName; set { selectedDoctorName = value; OnPropertyChanged(nameof(SelectedDoctorName)); } }
        public string SelectedConsultationtype { get => selectedConsultationtype; set { selectedConsultationtype = value; OnPropertyChanged(nameof(SelectedConsultationtype)); } }

        //Commands
        public ICommand UpdateDoctor { get; }
        private readonly IDoctorService _doctorService;



        //Constructor
        public UpdateDoctorViewModel(IDoctorService doctorService)
        {
            _doctorService = doctorService;
            _doctorService.GetDepartment();
            _doctorService.GetDoctorName();
            UpdateDoctor = new ViewModelCommand(ExecuteUpdateDoctor);
        }

        
        
        private void ExecuteUpdateDoctor(object obj)
        {
            _doctorService.UpdateDoctor(SelectedDoctorName, SelectedConsultationtype);
        }
    }
}
