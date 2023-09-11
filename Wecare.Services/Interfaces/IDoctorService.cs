using WeCare.Data.Model;

namespace Wecare.Services.Service
{
    public interface IDoctorService
    {
        Task AddDoctor(string text, string selectedDepartment);
        Task<DepartmentModel?> GetDepartment();
    }
}