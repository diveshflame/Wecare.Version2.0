using WeCare.Data.DataAccess;
using WeCare.Data.Model;

namespace WeCare.Data.Data.Appointment
{
    public class ViewAppointmentData : IViewAppointmentData
    {
        private readonly ISqldataAccess _db;
        public ViewAppointmentData(ISqldataAccess db)
        {
            _db = db;
        }

        #region Admin View Appointments
        public Task<IEnumerable<AppointmentModel>> GetAllAppointments() => _db.LoadData<AppointmentModel, dynamic>(getAllAppointments, new { });
        public Task<IEnumerable<AppointmentModel>> GetTodayAppointment() => _db.LoadData<AppointmentModel, dynamic>(getTodayAppointment, new { });
        public Task<IEnumerable<AppointmentModel>> GetAppointmentHistory() => _db.LoadData<AppointmentModel, dynamic>(getAppointmentHistory, new { });
        #endregion

        #region Patient View Bookings
        public Task<IEnumerable<AppointmentModel>> GetPatientAllApointments() => _db.LoadData<AppointmentModel, dynamic>(getPatientAllAppointments, new { });
        public Task<IEnumerable<AppointmentModel>> GetPatientTodayAppointment() => _db.LoadData<AppointmentModel, dynamic>(getPatientTodayAppointment, new { });
        public Task<IEnumerable<AppointmentModel>> GetPatientAppointmentHistory() => _db.LoadData<AppointmentModel, dynamic>(getPatientAppointmentHistory, new { });
        #endregion


        #region Delete appointment
        public async Task UpdateAppointmentTable(int Appointment_Id, DateTime DatetimeNow) => await _db.SaveData(updateAppointment, new { Appointment_ID = Appointment_Id, TDate = DatetimeNow });
        public async Task InsertIntoDocAvailability(int DocId, DateTime StartTime, DateTime EndTime) => await _db.SaveData(insertIntoAvailability, new { DocID = DocId, StartTime = StartTime, EndTime = EndTime });

        #endregion

        #region Queries
        string getAllAppointments = @"SELECT NAME,
	                                    DOCTOR_NAME,
	                                    APPOINTMENT_STARTTIME,
	                                    APPOINTMENT_ENDTIME,
	                                    DEPARTMENT_NAME
                                    FROM USERDETAILS
                                    INNER JOIN APPOINTMENT ON USERDETAILS.USERID = APPOINTMENT.USERID
                                    INNER JOIN DOCTOR ON APPOINTMENT.DOCTOR_ID = DOCTOR.DOCTOR_ID
                                    INNER JOIN DEPARTMENT ON DOCTOR.DEPARTMENT_ID = DEPARTMENT.DEPARTMENT_ID
                                    WHERE DELETED_TIMESTAMP IS NULL
	                                    AND DATE(APPOINTMENT_STARTTIME) >= CURRENT_DATE
                                    ORDER BY APPOINTMENT_STARTTIME";
        string getTodayAppointment = @"SELECT NAME,
	                                    DOCTOR_NAME,
	                                    APPOINTMENT_STARTTIME,
	                                    APPOINTMENT_ENDTIME,
	                                    DEPARTMENT_NAME
                                    FROM USERDETAILS
                                    INNER JOIN APPOINTMENT ON USERDETAILS.USERID = APPOINTMENT.USERID
                                    INNER JOIN DOCTOR ON APPOINTMENT.DOCTOR_ID = DOCTOR.DOCTOR_ID
                                    INNER JOIN DEPARTMENT ON DOCTOR.DEPARTMENT_ID = DEPARTMENT.DEPARTMENT_ID
                                    WHERE DELETED_TIMESTAMP IS NULL
	                                    AND DATE(APPOINTMENT_STARTTIME) = CURRENT_DATE
                                    ORDER BY APPOINTMENT_STARTTIME";
        string getAppointmentHistory = @"SELECT NAME,
	                                    DOCTOR_NAME,
	                                    APPOINTMENT_STARTTIME,
	                                    APPOINTMENT_ENDTIME,
	                                    DEPARTMENT_NAME
                                    FROM USERDETAILS
                                    INNER JOIN APPOINTMENT ON USERDETAILS.USERID = APPOINTMENT.USERID
                                    INNER JOIN DOCTOR ON APPOINTMENT.DOCTOR_ID = DOCTOR.DOCTOR_ID
                                    INNER JOIN DEPARTMENT ON DOCTOR.DEPARTMENT_ID = DEPARTMENT.DEPARTMENT_ID
                                    WHERE DELETED_TIMESTAMP IS NULL
	                                    AND DATE(APPOINTMENT_STARTTIME) < CURRENT_DATE
                                    ORDER BY APPOINTMENT_STARTTIME";
        //User Appointment
        string getPatientAllAppointments = @"SELECT APPOINTMENT_ID,
	                                            APPOINTMENT.DOCTOR_ID,
	                                            DOCTOR_NAME,
	                                            APPOINTMENT_STARTTIME,
	                                            APPOINTMENT_ENDTIME,
	                                            DEPARTMENT_NAME
                                            FROM APPOINTMENT
                                            JOIN DOCTOR ON APPOINTMENT.DOCTOR_ID = DOCTOR.DOCTOR_ID
                                            JOIN DEPARTMENT ON APPOINTMENT.DEPARTMENT_ID = DEPARTMENT.DEPARTMENT_ID
                                            WHERE DELETED_TIMESTAMP IS NULL
	                                            AND DATE(APPOINTMENT_STARTTIME) >= CURRENT_DATE
	                                            AND APPOINTMENT.USERID IN
		                                            (SELECT USERID
			                                            FROM USERDETAILS
			                                            WHERE ACTIVE_SESSION = 1)
                                            ORDER BY APPOINTMENT_STARTTIME";

        string getPatientTodayAppointment = @"SELECT APPOINTMENT_ID,
	                                            APPOINTMENT.DOCTOR_ID,
	                                            DOCTOR_NAME,
	                                            APPOINTMENT_STARTTIME,
	                                            APPOINTMENT_ENDTIME,
	                                            DEPARTMENT_NAME
                                            FROM APPOINTMENT
                                            JOIN DOCTOR ON APPOINTMENT.DOCTOR_ID = DOCTOR.DOCTOR_ID
                                            JOIN DEPARTMENT ON APPOINTMENT.DEPARTMENT_ID = DEPARTMENT.DEPARTMENT_ID
                                            WHERE DELETED_TIMESTAMP IS NULL
	                                            AND DATE(APPOINTMENT_STARTTIME) = CURRENT_DATE
	                                            AND APPOINTMENT.USERID IN
		                                            (SELECT USERID
			                                            FROM USERDETAILS
			                                            WHERE ACTIVE_SESSION = 1)
                                            ORDER BY APPOINTMENT_STARTTIME";
        string getPatientAppointmentHistory = @"SELECT APPOINTMENT_ID,
	                                            APPOINTMENT.DOCTOR_ID,
	                                            DOCTOR_NAME,
	                                            APPOINTMENT_STARTTIME,
	                                            APPOINTMENT_ENDTIME,
	                                            DEPARTMENT_NAME
                                            FROM APPOINTMENT
                                            JOIN DOCTOR ON APPOINTMENT.DOCTOR_ID = DOCTOR.DOCTOR_ID
                                            JOIN DEPARTMENT ON APPOINTMENT.DEPARTMENT_ID = DEPARTMENT.DEPARTMENT_ID
                                            WHERE DELETED_TIMESTAMP IS NULL
	                                            AND DATE(APPOINTMENT_STARTTIME) < CURRENT_DATE
	                                            AND APPOINTMENT.USERID IN
		                                            (SELECT USERID
			                                            FROM USERDETAILS
			                                            WHERE ACTIVE_SESSION = 1)
                                            ORDER BY APPOINTMENT_STARTTIME";
        //Update the appointment table set the DeletedTimeStamp value to the current time
        string updateAppointment = "UPDATE APPOINTMENT SET DELETED_TIMESTAMP = @TDATE::timestamp WHERE APPOINTMENT_ID = @Appointment_Id;";
        //Insert the deleted slot to Doctor_Availability table
        string insertIntoAvailability = "INSERT INTO DOCTOR_AVAILABILITY(DOCTOR_ID,AVAILABLE_STARTTIME,AVAILABLE_ENDTIME) VALUES  (@DocID,@StartTime,@EndTime)";

        #endregion


    }
}

