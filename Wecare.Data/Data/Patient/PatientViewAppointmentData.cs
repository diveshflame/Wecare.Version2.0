using Wecare.Data.Data.Interface;
using WeCare.Data.DataAccess;
using WeCare.Data.Model;

namespace WeCare.Data.Data.Appointment
{
    public class PatientViewAppointmentData : IPatientViewAppointmentData
    {
        private readonly ISqldataAccess _db;
        public PatientViewAppointmentData(ISqldataAccess db)
        {
            _db = db;
        }


        #region Patient View Bookings
        // Display upcoming appointments for the Patient 

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
        public Task<IEnumerable<AppointmentModel>> GetPatientAllApointments() => _db.LoadData<AppointmentModel, dynamic>(getPatientAllAppointments, new { });

        // Display Today's appointments for the Patient 
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
        public Task<IEnumerable<AppointmentModel>> GetPatientTodayAppointment() => _db.LoadData<AppointmentModel, dynamic>(getPatientTodayAppointment, new { });

        // Display appointment history of the Patient
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
        public Task<IEnumerable<AppointmentModel>> GetPatientAppointmentHistory() => _db.LoadData<AppointmentModel, dynamic>(getPatientAppointmentHistory, new { });
        #endregion


        #region Delete appointment

        //Update the appointment table by setting the DeletedTimeStamp to the current time
        string updateAppointment = "UPDATE APPOINTMENT SET DELETED_TIMESTAMP = @TDATE::timestamp WHERE APPOINTMENT_ID = @Appointment_Id;";
        public async Task UpdateAppointmentTable(int Appointment_Id, DateTime DatetimeNow) => await _db.SaveData(updateAppointment, new { Appointment_ID = Appointment_Id, TDate = DatetimeNow });

        //Inserting the deleted slot to Doctor_Availability table
        string insertIntoAvailability = "INSERT INTO DOCTOR_AVAILABILITY(DOCTOR_ID,AVAILABLE_STARTTIME,AVAILABLE_ENDTIME) VALUES  (@DocID,@StartTime,@EndTime)";
        public async Task InsertIntoDocAvailability(int DocId, DateTime StartTime, DateTime EndTime) => await _db.SaveData(insertIntoAvailability, new { DocID = DocId, StartTime = StartTime, EndTime = EndTime });

        #endregion



    }
}

