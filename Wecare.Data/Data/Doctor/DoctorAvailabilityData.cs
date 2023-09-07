using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCare.Data.DataAccess;
using Npgsql;
using System.Data;

namespace WeCare.Data.Data.Doctor
{
    public class DoctorAvailabilityData : IDoctorAvailabilityData
    {
        private readonly ISqldataAccess _db;

        public DoctorAvailabilityData(ISqldataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<string>> GET()
        {
            string sqlCommand = "SELECT Doctor_Name FROM Doctor_Table";

            try
            {
                var parameters = new { }; // You can add parameters if needed

                var doctorNames = await _db.LoadData<string, dynamic>(sqlCommand, parameters);

                return doctorNames;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve doctor names.", ex);
            }
        }
        public async Task<IEnumerable<string>> StartTime()
        {
            string sqlCommand = "SELECT demostarttime FROM demo_time";

            try
            {
                var parameters = new { };

                var startTimes = await _db.LoadData<TimeSpan, dynamic>(sqlCommand, parameters);

                return startTimes.Select(startTime => $"{startTime.Hours:D2}:{startTime.Minutes:D2}");
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve start times.", ex);
            }
        }

        public async Task<IEnumerable<string>> GetEndTimesAsync()
        {
            string sqlCommand = "SELECT demoendtime FROM demo_time";

            try
            {
                var parameters = new { }; 

                var endTimes = await _db.LoadData<TimeSpan, dynamic>(sqlCommand, parameters);

                return endTimes.Select(endTime => $"{endTime.Hours:D2}:{endTime.Minutes:D2}");
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve end times.", ex);
            }
        }

        //------------------------------------------------------------------------------------------------

        public async Task<IEnumerable<string>> GetConsultantDescription(string doctorName)
        {
            try
            {
                //Get doctor Id by doctor name
                int doctorId = await GetDoctorID(doctorName);

                //Get consultant Id by doctor Id
                int consultantId = await GetConsultantId(doctorId);

                //Get consultant descriptions by consultant Id
                string sqlCommand = "SELECT consultant_desc FROM consultant_type WHERE consultant_id = @consultantId";
                var parameters = new { consultantId };

                var consultantDescriptions = await _db.LoadData<string, dynamic>(sqlCommand, parameters);

                return consultantDescriptions;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve consultant descriptions.", ex);
            }
        }
        //COMMON----------------------------------------------------------------------------------
        private async Task<int> GetDoctorID(string doctorName)
        {
            string sqlCommand = "SELECT doctor_Id FROM doctor_table WHERE Doctor_Name = @doctorName";
            var parameters = new { doctorName };

            return (await _db.LoadData<int, dynamic>(sqlCommand, parameters)).FirstOrDefault();
        }

        private async Task<int> GetConsultantId(int doctorId)
        {
            string sqlCommand = "SELECT consultant_id FROM doctor_table WHERE doctor_Id = @doctorId";
            var parameters = new { doctorId };

            return (await _db.LoadData<int, dynamic>(sqlCommand, parameters)).FirstOrDefault();
        }



        //------------------------------------------------------------------------------------------------

        public async Task<int> SelectionConchangedAsync(DateTime dat1, string doctorName, DateTime startDate, DateTime EndDate)
        {

            int doctorId = await GetDoctorID(doctorName);

            string query = "SELECT COUNT(*) FROM doctor_availability WHERE TO_CHAR(available_starttime, 'YYYY-MM-DD HH24:MI:SS') = @SelectedDateTime AND doctor_id = @doctorId";
            var parameters = new { SelectedDateTime = dat1.ToString("yyyy-MM-dd HH:mm:ss"), doctorId };

            return (await _db.LoadData<int, dynamic>(query,parameters)).FirstOrDefault();

        }
        //--------------------------------------------------------------------------------------------------

        public async Task InsertAvailability(int doctorId, DateTime startTime, DateTime endTime)
        {
            string insert = "INSERT INTO doctor_availability (doctor_id, available_starttime, available_endtime) VALUES (@doctorId, @startTime, @endTime)";
            var parameters = new { doctorId, startTime, endTime };
            await _db.SaveData(insert, parameters);
        }

        public async Task InsertMultipleAvailabilitiesAsync(int doctorId, DateTime currentDate)
        {
                string insert = "INSERT INTO doctor_availability (Doctor_Id, available_starttime, available_endtime) VALUES ";
                for (int i = 10; i <= 18; i++)
                {
                    DateTime startTime = DateTime.Parse(currentDate.ToString("dd/MM/yyyy ") + $"{i:D2}:00:00.000");
                    DateTime endTime = DateTime.Parse(currentDate.ToString("dd/MM/yyyy ") + $"{i + 1:D2}:00:00.000");

                    insert += $"(@doctorId, @startTime{i}, @endTime{i}),";
                }

                // Remove the trailing comma
                insert = insert.TrimEnd(',');

                var parameters = new
                {
                    doctorId,
                    startTime10 = DateTime.Parse(currentDate.ToString("dd/MM/yyyy ") + "10:00:00.000"),
                    endTime10 = DateTime.Parse(currentDate.ToString("dd/MM/yyyy ") + "11:00:00.000"),
                    startTime11 = DateTime.Parse(currentDate.ToString("dd/MM/yyyy ") + "11:00:00.000"),
                    endTime11 = DateTime.Parse(currentDate.ToString("dd/MM/yyyy ") + "12:00:00.000"),
                    startTime12 = DateTime.Parse(currentDate.ToString("dd/MM/yyyy ") + "12:00:00.000"),
                    endTime12 = DateTime.Parse(currentDate.ToString("dd/MM/yyyy ") + "13:00:00.000"),
                    startTime13 = DateTime.Parse(currentDate.ToString("dd/MM/yyyy ") + "13:00:00.000"),
                    endTime13 = DateTime.Parse(currentDate.ToString("dd/MM/yyyy ") + "14:00:00.000"),
                    startTime14 = DateTime.Parse(currentDate.ToString("dd/MM/yyyy ") + "14:00:00.000"),
                    endTime14 = DateTime.Parse(currentDate.ToString("dd/MM/yyyy ") + "15:00:00.000"),
                    startTime15 = DateTime.Parse(currentDate.ToString("dd/MM/yyyy ") + "15:00:00.000"),
                    endTime15 = DateTime.Parse(currentDate.ToString("dd/MM/yyyy ") + "16:00:00.000"),
                    startTime16 = DateTime.Parse(currentDate.ToString("dd/MM/yyyy ") + "16:00:00.000"),
                    endTime16 = DateTime.Parse(currentDate.ToString("dd/MM/yyyy ") + "17:00:00.000"),
                    startTime17 = DateTime.Parse(currentDate.ToString("dd/MM/yyyy ") + "17:00:00.000"),
                    endTime17 = DateTime.Parse(currentDate.ToString("dd/MM/yyyy ") + "18:00:00.000"),
                };
            await _db.SaveData(insert, parameters);         
        }
    }
}
