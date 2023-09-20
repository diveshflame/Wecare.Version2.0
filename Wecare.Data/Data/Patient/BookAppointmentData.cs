
using System;
using System.Linq;
using System.Threading.Tasks;
using WeCare.Data.DataAccess;
using WeCare.Data.Model;



namespace WeCare.Data.Data
{
    public class BookAppointmentData : IBookAppointmentData
    {
        private readonly ISqldataAccess _dbAccess;
        public BookAppointmentData(ISqldataAccess dbAccess)
        {
            _dbAccess = dbAccess;


        }

        #region Get Doctor names according to department
        public async Task<DoctorModel?> GetDoctorNames(string selectedDepartment)
        {

            string getDoc = @"SELECT d.Doctor_name FROM doctor d 
                              JOIN department dp ON d.DEPARTMENT_ID = dp.Department_Id
                              WHERE dp.Department_Name = @SelectedDepartmentParameter;";
            var result = await _dbAccess.LoadData<DoctorModel, dynamic>(getDoc, new { SelectedDepartmentParameter = selectedDepartment });

            return result.FirstOrDefault();

        }
        #endregion

        #region Getting available slot times

        public async Task<AppointmentModel?> GetDoctorAvailableTime(string doc, DateTime selectedDate)
        {

            string getTime = @"SELECT da.available_starttime, da.available_endtime
                                FROM doctor_availability da
                                LEFT JOIN booking_table bt ON da.available_starttime = bt.APPOINTMENT_STARTTIME
                                WHERE DATE(da.available_starttime) = @time
                                  AND DATE(da.available_endtime) = @time
                                  AND da.doctor_id = (
                                      SELECT Doctor_Id
                                      FROM doctor_table
                                      WHERE Doctor_Name = @doctorName
                                  )
                                  AND (bt.doctor_id IS NULL OR bt.Deleted_TimeStamp IS NULL)
                                ORDER BY da.available_starttime, da.available_endtime;
                                ";
            var results = await _dbAccess.LoadData<AppointmentModel, dynamic>(getTime, new { doctorName = doc, time = selectedDate });
            return results.FirstOrDefault();
        }
        #endregion

        #region Get Department Id
        public async Task<AppointmentModel?> GetDepartmentIdForDoctor(string selectedDep, string doc)
        {
            string getDepartmentID = @"SELECT department_id AS id
                                        FROM department
                                        WHERE @depSelected = consultant_desc

                                        UNION

                                        SELECT doctor_Id AS id
                                        FROM doctor
                                        WHERE @d = Doctor_Name;
                                        ";


            var results2 = await _dbAccess.LoadData<AppointmentModel, dynamic>(getDepartmentID, new { docSelected = doc, depSelected = selectedDep });

            return results2.FirstOrDefault();

        }
        #endregion

        #region Getting the user ID
        public async Task<AppointmentModel?> GetUserID()
        {
            string userID = "SELECT userid from userdetails where active_session = 1";
            var results2 = await _dbAccess.LoadData<AppointmentModel, dynamic>(userID, new { });//add userid
            return results2.FirstOrDefault();
        }
        #endregion

        #region Adding the Appointment
                public async Task InsertAppointment(int UserID, string DeptID, DateTime selectedDate, string doc, DateTime StartTime, DateTime EndTime)
                {

                    string insertStatement = "INSERT INTO Booking_Table (userid,department_id,doctor_id,APPOINTMENT_STARTTIME,APPOINTMENT_ENDTIME) VALUES (@userID,@deptType,@docSelected,@startSlot,@endSlot)";

                    var parameters = new
                    {
                        docSelected = doc,
                        userID = UserID,
                        deptType = DeptID,
                        startSlot = StartTime,
                        endSlot = EndTime
                    };

                    await _dbAccess.SaveData(insertStatement, parameters);
                }
                #endregion
    }
}
