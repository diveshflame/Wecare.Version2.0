using Wecare.Data.Data.Admin;
using Wecare.Services.Interfaces;
using WeCare.Data.Model;

namespace Wecare.Services.Service
{
    public class AdminViewAppointmentService : IAdminViewAppointmentService
    {
        private readonly IAdminViewAppointmentData _adminViewAppointmentData;

        public AdminViewAppointmentService(IAdminViewAppointmentData adminViewAppointmentData)
        {
            _adminViewAppointmentData = adminViewAppointmentData;
        }

        #region Admin View Appointment
        public Task<IEnumerable<AppointmentModel>> GetAllAppointments() => _adminViewAppointmentData.GetAllAppointments();
        public Task<IEnumerable<AppointmentModel>> GetTodayAppointment() => _adminViewAppointmentData.GetTodayAppointment();
        public Task<IEnumerable<AppointmentModel>> GetAppointmentHistory() => _adminViewAppointmentData.GetAppointmentHistory();
        #endregion
    }
}
