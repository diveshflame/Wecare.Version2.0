
using Wecare.Data.Data.Common;

using WeCare.Data.Data;

using WeCare.Data.Model;

namespace Wecare.Services.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IBookAppointmentData _dbAccess;
        private readonly ICommonFunctions _functions;
        public AppointmentService(IBookAppointmentData dbAccess,ICommonFunctions functions)
        {
            _dbAccess = dbAccess;
            _functions=functions;   
        }

        #region Get Availability time of doctors
        public async Task<AppointmentModel?> GetDoctorAvailableTime(string doc, DateTime selectedDate)
        {
            var doctor = await _functions.GetDoctorId(doc);
            var doctor_id = doctor.ToString();
            var availableTime = await _dbAccess.GetDoctorAvailableTime(doctor_id, selectedDate);
            return availableTime;

        }
        #endregion 
        #region Insert the Appointment
        public async Task InsertAppointment(string selectedDep, DateTime selectedDate, string doctor, DateTime StartTime, DateTime EndTime)
        {
            var department_id = await _dbAccess.GetDepartmentIdForDoctor(selectedDep, doctor);
            var department = department_id.ToString();
            var doctorTemp = await _functions.GetDoctorId(doctor);
            var doctor_id = doctor.ToString();
            var user = await _dbAccess.GetUserID();
            var user_id = Convert.ToInt32(user.ToString());
            DateTime tempDate1 = DateTime.Now;
            DateTime tempDate2 = DateTime.Now;
            DateTime tempDate3 = DateTime.Now;

            tempDate1 = StartTime;
            tempDate2 = EndTime;
            tempDate3 = StartTime.AddHours(1);
            if (tempDate1 >= DateTime.Now && tempDate2 >= DateTime.Now)
            {
                while (tempDate1 != tempDate2)
                {
                    await _dbAccess.InsertAppointment(user_id, department, selectedDate, doctor_id, StartTime, EndTime);
                    tempDate1 = tempDate1.AddHours(1);
                    tempDate3 = tempDate3.AddHours(1);
                }
            }
        }
        #endregion
    }
}
