using WeCare.Data.Model;

namespace WeCare.Data.Data.Doctor
{
    public interface IDoctorData
    {
        Task AddDoctor(string DoctorName, string selectedDepartment);
        Task<IEnumerable<DoctorAvailabilityModel>> CheckDocAvailability(int DocId);
        Task UpdateDoc(int DocId, int DeptId);
    }
}