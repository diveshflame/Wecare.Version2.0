﻿namespace WeCare.Data.Data.Doctor
{
    public interface IDoctorAvailabilityData
    {
        Task<IEnumerable<string>> GET();
        Task<IEnumerable<string>> GetConsultantDescription(string doctorName);
        Task<IEnumerable<string>> GetEndTimesAsync();
        Task<IEnumerable<string>> StartTime();
    }
}