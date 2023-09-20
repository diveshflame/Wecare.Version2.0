using Wecare.Data.Data.Interface;
using WeCare.Data.DataAccess;
using WeCare.Data.Model;

namespace Wecare.Data.Data.Admin
{
    public class AdminViewAppointmentData : IAdminViewAppointmentData
    {
        private readonly ISqldataAccess _db;
        public AdminViewAppointmentData(ISqldataAccess db)
        {
            _db = db;
        }

        #region Admin View Appointments
        // Display upcoming appointments of all the patients for the admin 
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
        public Task<IEnumerable<AppointmentModel>> GetAllAppointments() => _db.LoadData<AppointmentModel, dynamic>(getAllAppointments, new { });

        // Display Todays appointments of all the patients for the admin 
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
        public Task<IEnumerable<AppointmentModel>> GetTodayAppointment() => _db.LoadData<AppointmentModel, dynamic>(getTodayAppointment, new { });

        // Display  appointment history of all the patients for the admin 
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
        public Task<IEnumerable<AppointmentModel>> GetAppointmentHistory() => _db.LoadData<AppointmentModel, dynamic>(getAppointmentHistory, new { });

        #endregion




    }
}

