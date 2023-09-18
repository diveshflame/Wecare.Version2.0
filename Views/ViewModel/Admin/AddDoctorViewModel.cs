using MVVM_App.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Views.ViewModel.Common;
using Wecare.Services.Interfaces;
using static System.Net.Mime.MediaTypeNames;
using System.Configuration;
using System.Threading;
using System.Collections.Generic;
using WeCare.Data.Model;

namespace Views.ViewModel.Admin
{
    public class AddDoctorViewModel : ViewModelBase, IAddDoctorViewModel
    {
        private IEnumerable<DepartmentModel> _department;
        private IDoctorService DocService;
        private string selectedDepartment;
        private string DocName;
        public ICommand AddDoctor { get; }

        #region Adding OnpropertyChanged
        public IEnumerable<DepartmentModel> Department
        {
            get { return _department; }
            set
            {

                _department = value;
                OnPropertyChanged(nameof(Department));

            }
        }



        public string SelectedDepartment
        {
            get => selectedDepartment;
            set
            {
                selectedDepartment = value;
                OnPropertyChanged(nameof(SelectedDepartment));
            }
        }


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
        #endregion

        public async Task<IEnumerable<DepartmentModel>> InitializeAsync()
        { 
            var department = await DocService.GetDepartment();
            Department =department;
            string s = Department.FirstOrDefault().ToString();
            return Department;
        }

        public async Task LoadDepartment()
        {
            InitializeAsync().Wait();
        }

        public AddDoctorViewModel(IDoctorService doctorService)
        {
            DocService = doctorService;
            LoadDepartment();

        }


        private void ExecuteAddDoctor(object obj)
        {
            DocService.AddDoctor(DocNameChange, selectedDepartment);
        }
    }
}
