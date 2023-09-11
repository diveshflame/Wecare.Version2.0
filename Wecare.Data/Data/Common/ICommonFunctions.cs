using WeCare.Data.Model;

namespace Wecare.Data.Data.Common
{
    public interface ICommonFunctions
    {
        Task<DepartmentModel?> GetDepartmentID(string selectedDepartName);
        Task<IEnumerable<DepartmentModel>> GetDepartmentName();
        Task<DoctorModel?> GetDoctorId(string selectedDoctorname);
        Task<IEnumerable<DoctorModel>> GetDoctorName();
    }
}