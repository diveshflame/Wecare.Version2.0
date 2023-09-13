using MVVM_App.ViewModels;
using System.Threading.Tasks;
using System.Windows.Input;
using Wecare.Services.Interfaces;
using static System.Net.Mime.MediaTypeNames;


namespace Views.ViewModel.Admin
{
    public class AddDoctorViewModel : ViewModelBase, IAddDoctorViewModel
    {
        private string _department;
        private IDoctorService DocService;
        private string selectedDepartment;
        private string DocName;
        public ICommand AddDoctor { get; }

        #region Adding OnpropertyChanged
        public string Department
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
