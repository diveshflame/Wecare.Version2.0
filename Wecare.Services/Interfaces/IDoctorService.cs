using WeCare.Data.Model;

namespace Wecare.Services.Service
{
    public interface IAddDoctorService
    {
        Task AddDoctor(string text, string selectedDepartment);
        Task<DepartmentModel?> GetDepartment();
    }
}