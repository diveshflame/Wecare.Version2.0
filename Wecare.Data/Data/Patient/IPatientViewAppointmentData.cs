using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeCare.Data.Model;

namespace WeCare.Data.Data.Appointment
{
    public interface IPatientViewAppointmentData
    {
        Task<IEnumerable<AppointmentModel>> GetPatientAllApointments();
        Task<IEnumerable<AppointmentModel>> GetPatientAppointmentHistory();
        Task<IEnumerable<AppointmentModel>> GetPatientTodayAppointment();
        Task InsertIntoDocAvailability(int DocId, DateTime StartTime, DateTime EndTime);
        Task UpdateAppointmentTable(int Appointment_Id, DateTime DatetimeNow);
    }
}