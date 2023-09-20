using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeCare.Data.Model;

namespace WeCare.Data.Data.Appointment
{
    public interface IViewAppointmentData
    {
        Task<IEnumerable<AppointmentModel>> GetAllAppointments();
        Task<IEnumerable<AppointmentModel>> GetAppointmentHistory();
        Task<IEnumerable<AppointmentModel>> GetPatientAllApointments();
        Task<IEnumerable<AppointmentModel>> GetPatientAppointmentHistory();
        Task<IEnumerable<AppointmentModel>> GetPatientTodayAppointment();
        Task<IEnumerable<AppointmentModel>> GetTodayAppointment();
        Task InsertIntoDocAvailability(int DocId, DateTime Starttime, DateTime Endtime);
        Task UpdateAppointmentTable(int BookId, DateTime DatetimeNow);
    }
}