using WeCare.Data.Model;

namespace Wecare.Data.Data.Admin
{
    public interface IAdminViewAppointmentData
    {
        Task<IEnumerable<AppointmentModel>> GetAllAppointments();
        Task<IEnumerable<AppointmentModel>> GetAppointmentHistory();
        Task<IEnumerable<AppointmentModel>> GetTodayAppointment();
    }
}