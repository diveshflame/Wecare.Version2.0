using WeCare.Data.Model;

namespace Wecare.Services.Interfaces
{
    public interface IViewAppointmentService
    {
        Task<bool> DeleteAppointment(AppointmentModel appointmentModel);
        Task<IEnumerable<AppointmentModel>> GetAllAppointments();
        Task<IEnumerable<AppointmentModel>> GetAppointmentHistory();
        Task<IEnumerable<AppointmentModel>> GetPatientAllApointments();
        Task<IEnumerable<AppointmentModel>> GetPatientAppointmentHistory();
        Task<IEnumerable<AppointmentModel>> GetPatientTodayAppointment();
        Task<IEnumerable<AppointmentModel>> GetTodayAppointment();
    }
}