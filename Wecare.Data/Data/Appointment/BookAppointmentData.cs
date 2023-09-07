using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCare.Data.DataAccess;
using WeCare.Data.Model;
using Autofac;


namespace WeCare.Data.Data
{
    public class BookAppointmentData : IBookAppointmentData
    {
        private readonly ISqldataAccess _dbAccess;
        public BookAppointmentData(ISqldataAccess dbAccess)
        {
            _dbAccess = dbAccess;
 

        }

        List<DateTime> startTimes = new List<DateTime>();
        List<DateTime> endTimes = new List<DateTime>();
        
        string getDepartmentQuery = "SELECT Department_Id from department";
        public Task<IEnumerable<DepartmentModel>> BookGetCo() => _db.LoadData<DepartmentModel, dynamic>(getDepartmentQuery, new { });
        public async Task<AppointmentModel?> BookGetDoc(string SelectedDepartment)
        {
        
            string GetDoc = @"SELECT d.Doctor_name FROM doctor d 
                              JOIN department dp ON d.DEPARTMENT_ID = dp.Department_Id
                              WHERE dp.Department_Name = @SelectedDepartment;";
            var results2 = await _db.LoadData<AppointmentModel, dynamic>(GetDoc, new { SelectedDepartment = SelectedDepartment });
          
            return results2.FirstOrDefault();

        }
        //arjun

        public async Task<AppointmentModel?> BookGetTime(string doc, DateTime selectedDate)
        {

            string GetDocId = "SELECT Doctor_Id from doctor_table where @doctorName=Doctor_Name";
            var results = await _db.LoadData<AppointmentModel, dynamic>(GetDocId, new { doctorName = doc });
            string GetTime = "SELECT available_starttime, available_endtime FROM doctor_availability WHERE DATE(doctor_availability.available_starttime) = @time AND DATE(doctor_availability.available_endtime) = @time AND doctor_availability.doctor_id = @docid EXCEPT SELECT available_starttime, available_endtime FROM booking_table, doctor_availability WHERE booking_table.StartTime = available_starttime AND booking_table.doctor_id = @docid AND booking_table.EndTime = available_endtime AND Deleted_TimeStamp IS NULL ORDER BY available_starttime, available_endtime;";
            var results2 = await _db.LoadData<AppointmentModel, dynamic>(GetTime, new { docid = results, time = selectedDate });

            foreach (var appointment in results)
            {
                startTimes.Add(appointment.StartTime);
                endTimes.Add(appointment.EndTime);
            }
            return results2.FirstOrDefault();
        }
        public async Task<AppointmentModel?> AddBook(string selectedDep, DateTime selectedDate, string doc, DateTime d1, DateTime d2)
        {
            string GetConsultant = "SELECT consultant_id from consultant_Type where @depSelected = consultant_desc";
            var results = await _db.LoadData<AppointmentModel, dynamic>(GetConsultant, new { depSelected = selectedDep });
            string GetDoctor = "SELECT doctor_Id from doctor_table where @d=Doctor_Name";
            var results2 = await _db.LoadData<AppointmentModel, dynamic>(GetDoctor, new { docSelected = doc });//add userid
            string insertStatement = "INSERT INTO Booking_Table (userid,consultant_id,doctor_id,starttime,endtime) VALUES (@p,@consultType,@docSelected,@timeslot,@timeslot2)";
            DateTime dc1 = DateTime.Now;
            DateTime dc2 = DateTime.Now;
            DateTime dc3 = DateTime.Now;
            dc1 = d1;
            dc2 = d2;
            dc3 = d1.AddHours(1);
            var parameters = new
            {
                docSelected = doc

            };

            if (dc1 >= DateTime.Now && dc2 >= DateTime.Now)
            {
                while (dc1 != dc2)
                {
                    await _db.SaveData(insertStatement, parameters);
                    dc1 = dc1.AddHours(1);
                    dc3 = dc3.AddHours(1);
                }
            }

            return results.FirstOrDefault();

        }
    }
}
