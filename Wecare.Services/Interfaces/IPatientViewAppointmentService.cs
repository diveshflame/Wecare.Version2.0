using WeCare.Data.Model;

namespace Wecare.Services.Interfaces
{
    public interface IPatientViewAppointmentService
    {
        Task DeleteAppointment(AppointmentModel appointmentModel);
        Task<IEnumerable<AppointmentModel>> GetPatientAllApointments();
        Task<IEnumerable<AppointmentModel>> GetPatientAppointmentHistory();
        Task<IEnumerable<AppointmentModel>> GetPatientTodayAppointment();
    }
}