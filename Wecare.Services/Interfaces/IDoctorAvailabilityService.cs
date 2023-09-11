namespace Wecare.Services.Interfaces
{
    public interface IDoctorAvailabilityService
    {
        Task<int> CheckDoctorAvailability(DateTime selectedDateTime, string doctorName, DateTime startDate, DateTime endDate);
        Task<IEnumerable<string>> GetConsultantDescriptions(string doctorName);
        Task<IEnumerable<string>> GetDoctorNames();
        Task<IEnumerable<string>> GetEndTimes();
        Task<IEnumerable<string>> GetStartTimes();
        Task InsertAvailability(int doctorId, DateTime startTime, DateTime endTime);
        Task InsertMultipleAvailabilities(int doctorId, DateTime currentDate);
    }
}