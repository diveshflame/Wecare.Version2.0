using MVVM_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Wecare.Services.Interfaces;
using Wecare.Services.Service;

namespace Views.ViewModel.Admin
{
   public class AddTimingsViewModel : ViewModelBase
    {
        public ICommand SelectionChangedCommand { get; }
        public IDoctorAvailabilityService DoctorAvailabilityService;
        private string _doctorNames;
        public string DoctorNames
        {
            get { return _doctorNames; }
            set
            {

                _doctorNames = value;
                OnPropertyChanged(nameof(DoctorNames));
            }
        }

                public AddTimingsViewModel() 
        {

            SelectionChangedCommand = new RelayCommand<EventArgs>(ExecuteSelectionChanged);
        }
        private void ExecuteSelectionChanged(EventArgs e)
        {
            LoadDoctorNames();

        }
        private async Task LoadDoctorNames()
        {
            var docNames = await DoctorAvailabilityService.GetDoctorNames();
            _doctorNames = docNames;


        }
    }
}
