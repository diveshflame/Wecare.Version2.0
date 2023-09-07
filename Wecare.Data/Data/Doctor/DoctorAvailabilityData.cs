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
                var parameters = new { }; // You can add parameters if needed

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
                var parameters = new { }; // You can add parameters if needed

                var endTimes = await _db.LoadData<TimeSpan, dynamic>(sqlCommand, parameters);

                return endTimes.Select(endTime => $"{endTime.Hours:D2}:{endTime.Minutes:D2}");
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve end times.", ex);
            }
        }

        //------------------------------------------------------------------------------------------------

        public async Task<IEnumerable<string>> GetConsultantDescriptions(string doctorName)
        {
            try
            {
                //Get doctor Id by doctor name
                int doctorId = await GetDoctorName(doctorName);

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

        private async Task<int> GetDoctorName(string doctorName)
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
    }


}
