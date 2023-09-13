﻿using Wecare.Services.Interfaces;

namespace Wecare.Services.Service
{
    public class DoctorAvailabilityService : IDoctorAvailabilityService
    {
        private readonly IDoctorAvailabilityService _doctorAvailabilityData;

        public DoctorAvailabilityService(IDoctorAvailabilityService doctorAvailabilityData)
        {
            _doctorAvailabilityData = doctorAvailabilityData;
        }

        public async Task<string?> GetDoctorNames()
        {
            var doctorNames = await _doctorAvailabilityData.GetDoctorNames();
            return doctorNames.FirstOrDefault().ToString();
        }
        public async Task<IEnumerable<string>> GetStartTimes()
        {
            return await _doctorAvailabilityData.GetStartTimes();
        }

        public async Task<IEnumerable<string>> GetEndTimes()
        {
            return await _doctorAvailabilityData.GetEndTimes();
        }

        public async Task<string?> GetDepartmentDescriptions(string doctorName)
        {
            var departmentNames = await _doctorAvailabilityData.GetDepartmentDescriptions(doctorName);
            return departmentNames.FirstOrDefault().ToString();
        }

        public async Task<int> CheckDoctorAvailability(DateTime selectedDateTime, string doctorName, DateTime startDate, DateTime endDate)
        {
            return await _doctorAvailabilityData.CheckDoctorAvailability(selectedDateTime, doctorName, startDate, endDate);
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

