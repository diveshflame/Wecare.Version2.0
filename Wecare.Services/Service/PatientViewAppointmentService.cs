using Wecare.Services.Interfaces;
using WeCare.Data.Data.Appointment;
using WeCare.Data.Model;

namespace Wecare.Services.Service
{
    public class PatientViewAppointmentService : IPatientViewAppointmentService
    {
        private readonly IPatientViewAppointmentData _patientViewAppointmentData;

        public PatientViewAppointmentService(IPatientViewAppointmentData patientViewAppointmentData)
        {
            _patientViewAppointmentData = patientViewAppointmentData;
        }

        //patient view booking
        #region Patient View Bookings
        public Task<IEnumerable<AppointmentModel>> GetPatientAllApointments() => _patientViewAppointmentData.GetPatientAllApointments();
        public Task<IEnumerable<AppointmentModel>> GetPatientTodayAppointment() => _patientViewAppointmentData.GetPatientTodayAppointment();
        public Task<IEnumerable<AppointmentModel>> GetPatientAppointmentHistory() => _patientViewAppointmentData.GetPatientAppointmentHistory();
        #endregion


        #region Delete appointment
        // Delete appointment by calculating the time difference between the appointment start time and the current time.
        public async Task DeleteAppointment(AppointmentModel appointmentModel)
        {
            var Differencedate = appointmentModel.Appointment_StartTime - DateTime.Now;
            if (Differencedate.Days < 2)
            {
                string message = "You cannnot Cancel the appointment 48 hours prior to the appointment.Please Contact the doctor's office.";
            }
            else
            {
                DateTime dateTime = DateTime.Now;
                await _patientViewAppointmentData.UpdateAppointmentTable(appointmentModel.Appointment_Id, dateTime);
                await _patientViewAppointmentData.InsertIntoDocAvailability(appointmentModel.Doctor_Id, appointmentModel.Appointment_StartTime, appointmentModel.Appointment_EndTime);
            }
        }
        #endregion
    }
}