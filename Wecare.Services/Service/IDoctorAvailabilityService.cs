namespace Wecare.Services.Service
{
    public interface IDoctorAvailabilityService
    {
        Task<int> CheckDoctorAvailability(DateTime selectedDateTime, string doctorName, DateTime startDate, DateTime endDate);
        Task<string?> GetDepartmentDescriptions(string doctorName);
        Task<string?> GetDoctorNames();
        Task<IEnumerable<string>> GetEndTimes();
        Task<IEnumerable<string>> GetStartTimes();
        Task InsertAvailability(int doctorId, DateTime startTime, DateTime endTime);
        Task InsertMultipleAvailabilities(int doctorId, DateTime currentDate);
    }
}