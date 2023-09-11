using WeCare.Data.Model;

namespace Wecare.Services.Service
{
    public interface IAppointmentService
    {
        Task<AppointmentModel?> GetDoctorAvailableTime(string doc, DateTime selectedDate);
        Task InsertAppointment(string selectedDep, DateTime selectedDate, string doctor, DateTime StartTime, DateTime EndTime);
    }
}