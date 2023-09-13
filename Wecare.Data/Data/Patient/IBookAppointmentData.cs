using WeCare.Data.Model;

namespace WeCare.Data.Data
{
    public interface IBookAppointmentData
    {
        Task<AppointmentModel?> GetDepartmentIdForDoctor(string selectedDep, string doc);
        Task<AppointmentModel?> GetDoctorAvailableTime(string doc, DateTime selectedDate);
        Task<DoctorModel?> GetDoctorNames(string SelectedDepartment);
        Task<AppointmentModel?> GetUserID();
        Task InsertAppointment(int UserID, string DeptID, DateTime selectedDate, string doc, DateTime StartTime, DateTime EndTime);
    }
}