using WeCare.Data.Model;

namespace Wecare.Services.Service
{
    public interface IDoctorService
    {
        Task AddDoctor(string text, string selectedDepartment);
        Task<DepartmentModel?> GetDepartment();
        Task<IEnumerable<DepartmentModel>> GetDepartmentName();
        Task<IEnumerable<DoctorModel>> GetDoctorName();
        Task<bool> UpdateDoctor(string selectedDocName, string selectedDepartName);
    }
        
}