using WeCare.Data.Model;

namespace WeCare.Data.Data.Doctor
{
    public interface IDoctorData
    {
        Task AddDoctor(string text, string selectedConsultation);
        Task<IEnumerable<DoctorAvailabilityModel>> CheckDocAvailability(int DocId);
     
        Task<IEnumerable<DepartmentModel>> GetDepartment();
        Task UpdateDoc(int DocId, int DeptId);
    }
}