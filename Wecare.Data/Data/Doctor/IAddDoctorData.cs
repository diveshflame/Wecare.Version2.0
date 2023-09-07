using WeCare.Data.Model;

namespace WeCare.Data.Data.Doctor
{
    public interface IAddDoctorData
    {
        Task AddDoctor(string text, string selectedConsultation);
        Task<IEnumerable<DepartmentModel>> GetDep();
    }
}