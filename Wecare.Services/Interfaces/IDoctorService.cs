using WeCare.Data.Model;

namespace Wecare.Services.Interfaces
{
    public interface IDoctorService
    {
        Task AddDoctor(string text, string selectedDepartment);
        Task<string?> GetDepartment();
        Task<IEnumerable<DepartmentModel>> GetDepartmentName();
        Task<IEnumerable<DoctorModel>> GetDoctorName();
        Task<bool> UpdateDoctor(string selectedDocName, string selectedDepartName);
    }
}