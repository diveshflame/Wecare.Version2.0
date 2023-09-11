using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCare.Data.Data.Doctor;

namespace Wecare.Services.Service
{
    public class DoctorAvailabilityService : IDoctorAvailabilityService
    {
        private readonly IDoctorAvailabilityService _doctorAvailabilityData;

        public DoctorAvailabilityService(IDoctorAvailabilityService doctorAvailabilityData)
        {
            _doctorAvailabilityData = doctorAvailabilityData;
        }

        public async Task<IEnumerable<string>> GetDoctorNames()
        {
            return await _doctorAvailabilityData.GetDoctorName();
        }

        public async Task<IEnumerable<string>> GetStartTimes()
        {
            return await _doctorAvailabilityData.StartTime();
        }

        public async Task<IEnumerable<string>> GetEndTimes()
        {
            return await _doctorAvailabilityData.GetEndTimesAsync();
        }

        public async Task<IEnumerable<string>> GetConsultantDescriptions(string doctorName)
        {
            return await _doctorAvailabilityData.GetConsultantDescription(doctorName);
        }

        public async Task<int> CheckDoctorAvailability(DateTime selectedDateTime, string doctorName, DateTime startDate, DateTime endDate)
        {
            return await _doctorAvailabilityData.SelectionConchanged(selectedDateTime, doctorName, startDate, endDate);
        }

        public async Task InsertAvailability(int doctorId, DateTime startTime, DateTime endTime)
        {
            await _doctorAvailabilityData.InsertAvailability(doctorId, startTime, endTime);
        }

        public async Task InsertMultipleAvailabilities(int doctorId, DateTime currentDate)
        {
            await _doctorAvailabilityData.InsertMultipleAvailabilities(doctorId, currentDate);
        }

    }
}
