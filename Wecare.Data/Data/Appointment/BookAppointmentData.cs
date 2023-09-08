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
        private readonly ISqldataAccess dbAccess;
        public BookAppointmentData(ISqldataAccess _dbAccess)
        {
            dbAccess = _dbAccess;


        }
        private readonly string getDepartmentQuery = "SELECT Department_Id from department";
        public Task<IEnumerable<DepartmentModel>> GetDepartmentId() => dbAccess.LoadData<DepartmentModel, dynamic>(getDepartmentQuery, new { });
        public async Task<DoctorModel?> GetDoctorNames(string SelectedDepartment)
        {

            string GetDoc = @"SELECT d.Doctor_name FROM doctor d 
                              JOIN department dp ON d.DEPARTMENT_ID = dp.Department_Id
                              WHERE dp.Department_Name = @SelectedDepartmentParameter;";
            var result = await dbAccess.LoadData<DoctorModel, dynamic>(GetDoc, new { SelectedDepartmentParameter = SelectedDepartment });

            return result.FirstOrDefault();

        }
        //arjun

        public async Task<AppointmentModel?> GetDoctorAvailableTime(string doc, DateTime selectedDate)
        {

            string GetTime = @"SELECT available_starttime, available_endtime
                                FROM doctor_availability da
                                WHERE 
                                    DATE(da.available_starttime) = @time
                                    AND DATE(da.available_endtime) = @time
                                    AND da.doctor_id = (
                                        SELECT Doctor_Id
                                        FROM doctor_table
                                        WHERE Doctor_Name = @doctorName
                                    )
                                EXCEPT
                                SELECT available_starttime, available_endtime
                                FROM booking_table bt
                                JOIN doctor_availability da ON bt.APPOINTMENT_STARTTIME = da.available_starttime
                                WHERE bt.doctor_id = (
                                    SELECT Doctor_Id
                                    FROM doctor_table
                                    WHERE Doctor_Name = @doctorName
                                )
                                AND bt.Deleted_TimeStamp IS NULL
                                ORDER BY available_starttime, available_endtime;
                                ";
            var results = await dbAccess.LoadData<AppointmentModel, dynamic>(GetTime, new { doctorName = doc, time = selectedDate });
            return results.FirstOrDefault();
        }
        public async Task<AppointmentModel?> GetDepartmentID(string selectedDep, string doc)
        {
            string GetDepartmentID = @"SELECT department_id AS id
                                        FROM department
                                        WHERE @depSelected = consultant_desc

                                        UNION

                                        SELECT doctor_Id AS id
                                        FROM doctor
                                        WHERE @d = Doctor_Name;
                                        ";


            var results2 = await dbAccess.LoadData<AppointmentModel, dynamic>(GetDepartmentID, new { docSelected = doc, depSelected = selectedDep });//add userid

            return results2.FirstOrDefault();

        }
        public async Task<AppointmentModel?> GetUserID()
        {
            string userID = "SELECT userid from userdetails where active_session = 1";
            var results2 = await dbAccess.LoadData<AppointmentModel, dynamic>(userID, new { });//add userid
            return results2.FirstOrDefault();
        }
        public async Task InsertAppointment(string selectedDep, DateTime selectedDate, string doc, DateTime StartTime, DateTime EndTime)
        {
            AppointmentModel? DeptID = await GetDepartmentID(selectedDep, doc);
            AppointmentModel? UserID = await GetUserID();
            string insertStatement = "INSERT INTO Booking_Table (userid,department_id,doctor_id,APPOINTMENT_STARTTIME,APPOINTMENT_ENDTIME) VALUES (@userID,@DeptType,@docSelected,@StartSlot,@EndSlot)";

            var parameters = new
            {
                docSelected = doc,
                userID = UserID,
                DeptType = DeptID,
                StartSlot = StartTime,
                EndSlot = EndTime
            };

            await dbAccess.SaveData(insertStatement, parameters);
        }
    }
}
