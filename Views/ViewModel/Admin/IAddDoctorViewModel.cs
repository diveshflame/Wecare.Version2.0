using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Views.ViewModel.Admin
{
    public interface IAddDoctorViewModel
    {
        ICommand AddDoctor { get; }
        List<string> Department { get; set; }
        string DocNameChange { get; set; }
        string SelectedDepartment { get; set; }

        Task<List<string?>> InitializeAsync();
    }
}