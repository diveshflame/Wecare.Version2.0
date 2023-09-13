using WeCare.Data.Model;

namespace Wecare.Services.Interfaces
{
    public interface IAdminViewAppointmentService
    {
        Task<IEnumerable<AppointmentModel>> GetAllAppointments();
        Task<IEnumerable<AppointmentModel>> GetAppointmentHistory();
        Task<IEnumerable<AppointmentModel>> GetTodayAppointment();
    }
}