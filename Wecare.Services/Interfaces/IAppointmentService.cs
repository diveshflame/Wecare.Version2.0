using WeCare.Data.Model;

namespace Wecare.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<DepartmentModel>> GetDepartmentId();
    }
}