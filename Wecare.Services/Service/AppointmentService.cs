
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
        public async Task InsertAppointment(string selectedDep, DateTime selectedDate, string doctor, DateTime startTime, DateTime endTime)
        {
            try
            {

                if (string.IsNullOrEmpty(selectedDep) || string.IsNullOrEmpty(doctor) || startTime >= endTime)
                {

                    throw new ArgumentException("Invalid input parameters.");
                }

                var department_id = await _dbAccess.GetDepartmentIdForDoctor(selectedDep, doctor);
                var department = department_id.ToString();
                var doctorTemp = await _functions.GetDoctorId(doctor);
                var doctor_id = doctorTemp.ToString();
                var user = await _dbAccess.GetUserID();
                var user_id = Convert.ToInt32(user.ToString());

                DateTime tempDate = startTime;

                while (tempDate < endTime)
                {
                    await _dbAccess.InsertAppointment(user_id, department, selectedDate, doctor_id, tempDate, tempDate.AddHours(1));
                    tempDate = tempDate.AddHours(1);
                }
            }
            catch (Exception ex)
            {

                throw ex;

               
            }
        }

        #endregion
    }
}
