using WeCare.Data.Model;

namespace WeCare.Data.Data.Doctor
{
    public interface IUpdateDoctor
    {
        Task<DoctorAvailabilityModel?> CheckDocAvailability(int DocId);
        Task<DepartmentModel?> GetDepartmentID(string selectedDepartName);
        Task<IEnumerable<DepartmentModel>> GetDepartmentName();
        Task<DoctorModel?> GetDoctorId(string selectedDocname);
        Task<IEnumerable<DoctorModel>> GetDoctorName();
        Task UpdateDoc(int DocId, int DeptId);
    }
}