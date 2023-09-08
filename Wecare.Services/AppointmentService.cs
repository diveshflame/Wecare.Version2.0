using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCare.Data.Data;
using WeCare.Data.DataAccess;
using WeCare.Data.Model;

namespace Wecare.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IBookAppointmentData dbAccess;
        public AppointmentService(IBookAppointmentData _dbAccess)
        {
            dbAccess = _dbAccess;

        }

        public async Task<IEnumerable<DepartmentModel>> GetDepartmentName()
        {
            return await dbAccess.GetDepartmentName();
        }
      

            public async Task<AppointmentModel?> GetDepartmentIdForDoctor(string selectedDep, string doc)
        {
            return await dbAccess.GetDepartmentIdForDoctor(selectedDep, doc);
        }

        public async Task<AppointmentModel?> GetDoctorAvailableTime(string doc, DateTime selectedDate)
        {
            return await dbAccess.GetDoctorAvailableTime(doc, selectedDate);
        }

        public async Task<DoctorModel?> GetDoctorNames(string SelectedDepartment)
        {
            return await dbAccess.GetDoctorNames(SelectedDepartment);
        }

        public async Task<AppointmentModel?> GetUserID()
        {
            return await dbAccess.GetUserID();
        }


        public async Task InsertAppointment(string selectedDep, DateTime selectedDate, string doc, DateTime StartTime, DateTime EndTime)
        {
            var department_id= await dbAccess.GetDepartmentId(selectedDep); 
            var department=department_id.FirstOrDefault().ToString();
            await dbAccess.InsertAppointment(department, selectedDate, doc, StartTime, EndTime);
        }
    }
}
