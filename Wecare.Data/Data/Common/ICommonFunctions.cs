using WeCare.Data.Model;

namespace Wecare.Data.Data.Common
{
    public interface ICommonFunctions
    {
        Task<DepartmentModel?> GetDepartmentID(string selectedDepartName);
        Task<List<string?>> GetDepartmentName();
        Task<DoctorModel?> GetDoctorId(string selectedDoctorName);
        Task<IEnumerable<DoctorModel>> GetDoctorName();
    }
}