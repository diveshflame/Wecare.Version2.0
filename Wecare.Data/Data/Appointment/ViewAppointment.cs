using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCare.Data.DataAccess;
using WeCare.Data.Model;

namespace WeCare.Data.Data.Appointment
{
    public class ViewAppointment : IViewAppointment
    {
        private readonly ISqldataAccess _db;
        public ViewAppointment(ISqldataAccess db)
        {
            _db = db;
        }

        #region Admin VIew Appointments
        public Task<IEnumerable<AppointmentModel>> ViewAll() => _db.LoadData<AppointmentModel, dynamic>(viewAll, new { });
        public Task<IEnumerable<AppointmentModel>> ViewToday() => _db.LoadData<AppointmentModel, dynamic>(viewToday, new { });
        public Task<IEnumerable<AppointmentModel>> ViewHistory() => _db.LoadData<AppointmentModel, dynamic>(viewHistory, new { });
        #endregion

        #region Patient View Bookings
        public Task<IEnumerable<AppointmentModel>> ViewUserAll() => _db.LoadData<AppointmentModel, dynamic>(viewUserAll, new { });
        public Task<IEnumerable<AppointmentModel>> ViewUserToday() => _db.LoadData<AppointmentModel, dynamic>(viewUserToday, new { });
        public Task<IEnumerable<AppointmentModel>> ViewUserHistory() => _db.LoadData<AppointmentModel, dynamic>(viewUserHistory, new { });
        #endregion


        #region Delete appointment
        public async Task UpdateDoc(int BookId, DateTime DatetimeNow) => await _db.SaveData(updateBookTable, new { BookID = BookId, TDate = DatetimeNow });
        public async Task InsertIntoDocAvailability(int DocId, DateTime Starttime, DateTime Endtime) => await _db.SaveData(insertIntoAvailability, new { DocID = DocId, StartTime = Starttime, EndTime = Endtime });

        #endregion

        #region Queries

        string viewAll = @"SELECT NAME,
	                        DOCTOR_NAME,
	                        STARTTIME,
	                        ENDTIME,
	                        CONSULTANT_DESC
                        FROM USERDETAILS
                        INNER JOIN BOOKING_TABLE ON USERDETAILS.USERID = BOOKING_TABLE.USERID
                        INNER JOIN DOCTOR_TABLE ON BOOKING_TABLE.DOCTOR_ID = DOCTOR_TABLE.DOCTOR_ID
                        INNER JOIN CONSULTANT_TYPE ON DOCTOR_TABLE.CONSULTANT_ID = CONSULTANT_TYPE.CONSULTANT_ID
                        WHERE DELETED_TIMESTAMP IS NULL
	                        AND DATE(STARTTIME) >= CURRENT_DATE
                        ORDER BY STARTTIME";
        string viewToday = @"SELECT NAME,
	                            DOCTOR_NAME,
	                            STARTTIME,
	                            ENDTIME,
	                            CONSULTANT_DESC
                            FROM USERDETAILS
                            INNER JOIN BOOKING_TABLE ON USERDETAILS.USERID = BOOKING_TABLE.USERID
                            INNER JOIN DOCTOR_TABLE ON BOOKING_TABLE.DOCTOR_ID = DOCTOR_TABLE.DOCTOR_ID
                            INNER JOIN CONSULTANT_TYPE ON DOCTOR_TABLE.CONSULTANT_ID = CONSULTANT_TYPE.CONSULTANT_ID
                            WHERE DELETED_TIMESTAMP IS NULL
	                            AND DATE(STARTTIME) = CURRENT_DATE
                            ORDER BY STARTTIME";
        string viewHistory = @"SELECT NAME,
	                                DOCTOR_NAME,
	                                STARTTIME,
	                                ENDTIME,
	                                CONSULTANT_DESC
                               FROM USERDETAILS
                            INNER JOIN BOOKING_TABLE ON USERDETAILS.USERID = BOOKING_TABLE.USERID
                            INNER JOIN DOCTOR_TABLE ON  BOOKING_TABLE.DOCTOR_ID = DOCTOR_TABLE.DOCTOR_ID
                            INNER JOIN CONSULTANT_TYPE ON DOCTOR_TABLE.CONSULTANT_ID = CONSULTANT_TYPE.CONSULTANT_ID
                                AND DELETED_TIMESTAMP IS NULL AND DATE(STARTTIME) < CURRENT_DATE
                            ORDER BY STARTTIME ";

        string viewUserAll = @"SELECT BOOKING_ID,
                                    BOOKING_TABLE.DOCTOR_ID,
	                                CONSULTANT_DESC,
	                                DOCTOR_NAME,
	                                STARTTIME,
	                                ENDTIME
                               FROM BOOKING_TABLE
                               JOIN DOCTOR_TABLE ON BOOKING_TABLE.DOCTOR_ID = DOCTOR_TABLE.DOCTOR_ID
                               JOIN CONSULTANT_TYPE ON BOOKING_TABLE.CONSULTANT_ID = CONSULTANT_TYPE.CONSULTANT_ID
                               WHERE DELETED_TIMESTAMP IS NULL AND DATE(STARTTIME)>= CURRENT_DATE AND BOOKING_TABLE.USERID IN
                                    (SELECT USERID
                                        FROM USERDETAILS
                                        WHERE ACTIVE_SESSION = 1) ORDER BY STARTTIME";
        string viewUserToday = @"SELECT BOOKING_ID,
                                    BOOKING_TABLE.DOCTOR_ID,
	                                CONSULTANT_DESC,
	                                DOCTOR_NAME,
	                                STARTTIME,
	                                ENDTIME
                               FROM BOOKING_TABLE
                               JOIN DOCTOR_TABLE ON BOOKING_TABLE.DOCTOR_ID = DOCTOR_TABLE.DOCTOR_ID
                               JOIN CONSULTANT_TYPE ON BOOKING_TABLE.CONSULTANT_ID = CONSULTANT_TYPE.CONSULTANT_ID
                               WHERE DELETED_TIMESTAMP IS NULL AND DATE(STARTTIME)= CURRENT_DATE AND BOOKING_TABLE.USERID IN
                                    (SELECT USERID
                                        FROM USERDETAILS
                                        WHERE ACTIVE_SESSION = 1) ORDER BY STARTTIME";
        string viewUserHistory = @"SELECT BOOKING_ID,
                                    BOOKING_TABLE.DOCTOR_ID,
	                                CONSULTANT_DESC,
	                                DOCTOR_NAME,
	                                STARTTIME,
	                                ENDTIME
                               FROM BOOKING_TABLE
                               JOIN DOCTOR_TABLE ON BOOKING_TABLE.DOCTOR_ID = DOCTOR_TABLE.DOCTOR_ID
                               JOIN CONSULTANT_TYPE ON BOOKING_TABLE.CONSULTANT_ID = CONSULTANT_TYPE.CONSULTANT_ID
                               WHERE  DELETED_TIMESTAMP IS NULL AND DATE(STARTTIME) <CURRENT_DATE AND  BOOKING_TABLE.USERID IN
                                    (SELECT USERID
                                        FROM USERDETAILS
                                        WHERE ACTIVE_SESSION = 1) ORDER BY STARTTIME";
        string updateBookTable = "UPDATE Booking_Table SET Deleted_TimeStamp = @TDate::timestamp WHERE Booking_Id = @BookID;";
        string insertIntoAvailability = "insert into Doctor_Availability(doctor_id,available_starttime,available_endtime) values (@DocID,@StartTime,@EndTime)";

        #endregion


    }
}

