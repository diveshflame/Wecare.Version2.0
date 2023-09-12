using MVVM_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Views.View;
using WeCare.Data.Data.Doctor;
using Wecare.Services.Interfaces;
using static System.Net.Mime.MediaTypeNames;
using WeCare.Data.DataAccess;

namespace Views.ViewModel.Admin
{
    public class AddDoctorViewModel : ViewModelBase, IAddDoctorViewModel
    {
        private string _department;
        public string Department
        {
            get { return _department; }
            set
            {

                _department = value;
                OnPropertyChanged(nameof(Department));

            }
        }
        private IDoctorService DocService;

        public ICommand AddDoctor { get; }

        private string selectedDepartment;
        public string SelectedDepartment
        {
            get => selectedDepartment;
            set
            {
                selectedDepartment = value;
                OnPropertyChanged(nameof(SelectedDepartment));
            }
        }

        private string DocName;
        public string DocNameChange
        {
            get { return DocName; }
            set
            {
                if (DocName != value)
                {
                    DocName = value;
                    OnPropertyChanged(nameof(Text));
                }
            }

        }


        private async Task LoadDepartment(IDoctorService doctorService)
        {
            if (doctorService != null)
            {
                DocService = doctorService;
                var department = await DocService.GetDepartment();
                Department = department;
            }
            else
            {
               
            }
        }
        public AddDoctorViewModel(IDoctorService doctorService)
        {
            DocService= doctorService;
            AddDoctor = new ViewModelCommand(ExecuteAddDoctor);
            LoadDepartment(doctorService);

        }
        public AddDoctorViewModel():this(null)
        {
        }


        private void ExecuteAddDoctor(object obj)
        {
            DocService.AddDoctor(DocNameChange, selectedDepartment);
        }
    }
}
