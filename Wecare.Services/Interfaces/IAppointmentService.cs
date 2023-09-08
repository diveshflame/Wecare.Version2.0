using WeCare.Data.Model;

namespace Wecare.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<DepartmentModel>> GetDepartmentId();
    }
}