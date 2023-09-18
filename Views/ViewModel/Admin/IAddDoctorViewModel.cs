using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using WeCare.Data.Model;

namespace Views.ViewModel.Admin
{
    public interface IAddDoctorViewModel
    {
        ICommand AddDoctor { get; }
        IEnumerable<DepartmentModel> Department { get; set; }
        string DocNameChange { get; set; }
        string SelectedDepartment { get; set; }

        Task<IEnumerable<DepartmentModel>> InitializeAsync();
        Task LoadDepartment();
    }
}