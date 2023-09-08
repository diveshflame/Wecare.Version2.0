using WeCare.Data.Model;

namespace WeCare.Data.Data.Appointment
{
    public interface IViewAppointment
    {
        Task<IEnumerable<AppointmentModel>> GetAllAppointments();
        Task<IEnumerable<AppointmentModel>> GetAppointmentHistory();
        Task<IEnumerable<AppointmentModel>> GetPatientAllApointments();
        Task<IEnumerable<AppointmentModel>> GetPatientAppointmentHistory();
        Task<IEnumerable<AppointmentModel>> GetPatientTodayAppointment();
        Task<IEnumerable<AppointmentModel>> GetTodayAppointment();
        Task InsertIntoDocAvailability(int DocId, DateTime Starttime, DateTime Endtime);
        Task UpdateDoc(int BookId, DateTime DatetimeNow);
    }
}