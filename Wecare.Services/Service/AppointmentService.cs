using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wecare.Services.Interfaces;
using WeCare.Data.Data;
using WeCare.Data.DataAccess;
using WeCare.Data.Model;

namespace Wecare.Services.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IBookAppointmentData dbAccess;
        public AppointmentService(IBookAppointmentData _dbAccess)
        {
            dbAccess = _dbAccess;

        }

        public async Task<AppointmentModel?> GetDoctorAvailableTime(string doc, DateTime selectedDate)
        {
            var doctor = await dbAccess.GetDoctorId(doc);
            var doctor_id = doctor.ToString();
            var availableTime = await dbAccess.GetDoctorAvailableTime(doctor_id, selectedDate);
            return availableTime;

        }


        public async Task InsertAppointment(string selectedDep, DateTime selectedDate, string doctor, DateTime StartTime, DateTime EndTime)
        {
            var department_id = await dbAccess.GetDepartmentIdForDoctor(selectedDep, doctor);
            var department = department_id.ToString();
            var doctorTemp = await dbAccess.GetDoctorId(doctor);
            var doctor_id = doctor.ToString();
            var user = await dbAccess.GetUserID();
            var user_id = Convert.ToInt32(user.ToString());
            DateTime TempDate1 = DateTime.Now;
            DateTime TempDate2 = DateTime.Now;
            DateTime TempDate3 = DateTime.Now;

            TempDate1 = StartTime;
            TempDate2 = EndTime;
            TempDate3 = StartTime.AddHours(1);
            if (TempDate1 >= DateTime.Now && TempDate2 >= DateTime.Now)
            {
                while (TempDate1 != TempDate2)
                {
                    await dbAccess.InsertAppointment(user_id, department, selectedDate, doctor_id, StartTime, EndTime);
                    TempDate1 = TempDate1.AddHours(1);
                    TempDate3 = TempDate3.AddHours(1);
                }
            }
        }
    }
}
