using WeCare.Data.Model;

namespace Wecare.Services.Interfaces
{
    public interface IDoctorService
    {
        Task AddDoctor(string text, string selectedDepartment);
        Task<List<string>> GetDepartment();
        Task<List<string>> GetDepartmentName();
        Task<string?> GetDocID(string DocName);
        Task<IEnumerable<DoctorModel>> GetDoctorName();
        Task UpdateDoctor(string selectedDocName, string selectedDepartName);
    }
}