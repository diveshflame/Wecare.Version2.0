using WeCare.Data.Model;

namespace WeCare.Data.Data.Appointment
{
    public interface IViewAppointment
    {
        Task<IEnumerable<AppointmentModel>> ViewAll();
        Task<IEnumerable<AppointmentModel>> ViewHistory();
        Task<IEnumerable<AppointmentModel>> ViewToday();
        Task<IEnumerable<AppointmentModel>> ViewUserAll();
        Task<IEnumerable<AppointmentModel>> ViewUserHistory();
        Task<IEnumerable<AppointmentModel>> ViewUserToday();
    }
}