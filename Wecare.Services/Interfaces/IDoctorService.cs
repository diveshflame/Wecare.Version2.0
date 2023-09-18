using WeCare.Data.Model;

namespace Wecare.Services.Interfaces
{
    public interface IDoctorService
    {
        Task AddDoctor(string text, string selectedDepartment);
        Task<IEnumerable<DepartmentModel>> GetDepartment();
        Task<IEnumerable<DepartmentModel>> GetDepartmentName();
        Task<string?> GetDocID(string DocName);
        Task<IEnumerable<DoctorModel>> GetDoctorName();
        Task UpdateDoctor(string selectedDocName, string selectedDepartName);
    }
}