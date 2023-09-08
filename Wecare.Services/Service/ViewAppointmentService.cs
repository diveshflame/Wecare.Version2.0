using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wecare.Data.Data.User_Authentication;
using Wecare.Services.Interfaces;
using WeCare.Data.Data.Appointment;
using WeCare.Data.Model;

namespace Wecare.Services.Service
{
    public class ViewAppointmentService : IViewAppointmentService
    {
        private readonly IViewAppointmentData _viewAppointmentData;

        public ViewAppointmentService(IViewAppointmentData viewAppointmentData)
        {
            _viewAppointmentData = viewAppointmentData;
        }

        #region Admin View Appointment

        public Task<IEnumerable<AppointmentModel>> GetAllAppointments() => _viewAppointmentData.GetAllAppointments();
        public Task<IEnumerable<AppointmentModel>> GetTodayAppointment() => _viewAppointmentData.GetTodayAppointment();
        public Task<IEnumerable<AppointmentModel>> GetAppointmentHistory() => _viewAppointmentData.GetAppointmentHistory();
        #endregion

        #region Patient View Bookings
        public Task<IEnumerable<AppointmentModel>> GetPatientAllApointments() => _viewAppointmentData.GetPatientAllApointments();
        public Task<IEnumerable<AppointmentModel>> GetPatientTodayAppointment() => _viewAppointmentData.GetPatientTodayAppointment();
        public Task<IEnumerable<AppointmentModel>> GetPatientAppointmentHistory() => _viewAppointmentData.GetPatientAppointmentHistory();
        #endregion

        #region Delete appointment

        public async Task<bool> DeleteAppointment(AppointmentModel appointmentModel)
        {

            var Differencedate = appointmentModel.Appointment_StartTime - DateTime.Now;
            bool _canDelete = false;
            if (Differencedate.Days < 2)
            {
                return _canDelete;
            }
            else
            {
                DateTime dateTime = DateTime.Now;
                await _viewAppointmentData.UpdateDoc(appointmentModel.Appointment_Id, dateTime);
                await _viewAppointmentData.InsertIntoDocAvailability(appointmentModel.Doctor_Id, appointmentModel.Appointment_StartTime, appointmentModel.Appointment_EndTime);
            }
            return !_canDelete;
        }
        #endregion
    }
}