using System.Windows.Input;

namespace Views.ViewModel.Admin
{
    public interface IAddDoctorViewModel
    {
        ICommand AddDoctor { get; }
        string Department { get; set; }
        string DocNameChange { get; set; }
        string SelectedDepartment { get; set; }
    }
}