
using Wecare.Services.Interfaces;


namespace Wecare.Services.Service
{
    public class DoctorAvailabilityService : IDoctorAvailabilityService
    {
        private readonly IDoctorAvailabilityService _doctorAvailabilityData;
        #region Get the Doctor Names
        public DoctorAvailabilityService(IDoctorAvailabilityService doctorAvailabilityData)
        {
            _doctorAvailabilityData = doctorAvailabilityData;
        }

        public async Task<string?> GetDoctorNames()
        {
            var DoctorNames = await _doctorAvailabilityData.GetDoctorNames();
            return DoctorNames.FirstOrDefault().ToString();
        }

        #endregion
        #region Get End time and start time
        public async Task<IEnumerable<string>> GetStartTimes()
        {
            return await _doctorAvailabilityData.GetStartTimes();
        }

        public async Task<IEnumerable<string>> GetEndTimes()
        {
            return await _doctorAvailabilityData.GetEndTimes();
        }
        #endregion
        #region get department and check the doctor availability if that
        public async Task<string?> GetDepartmentDescriptions(string doctorName)
        {
            var DepartmentNames = await _doctorAvailabilityData.GetDepartmentDescriptions(doctorName);
            return DepartmentNames.FirstOrDefault().ToString();
        }


        public async Task<int> CheckDoctorAvailability(DateTime selectedDateTime, string doctorName, DateTime startDate, DateTime endDate)
        {
            return await _doctorAvailabilityData.CheckDoctorAvailability(selectedDateTime, doctorName, startDate, endDate);
        }
        #endregion
        #region insert doctor timings
        public async Task InsertAvailability(int doctorId, DateTime startTime, DateTime endTime)
        {
            await _doctorAvailabilityData.InsertAvailability(doctorId, startTime, endTime);
        }

        public async Task InsertMultipleAvailabilities(int doctorId, DateTime currentDate)
        {
            await _doctorAvailabilityData.InsertMultipleAvailabilities(doctorId, currentDate);
        }
        #endregion

    }
}

