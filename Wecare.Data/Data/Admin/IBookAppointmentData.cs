using WeCare.Data.Model;

namespace WeCare.Data.Data
{
    public interface IBookAppointmentData
    {
        Task<IEnumerable<DepartmentModel>> GetDepartmentId(string departmentName);
        Task<AppointmentModel?> GetDepartmentIdForDoctor(string selectedDep, string doc);
        Task<IEnumerable<DepartmentModel>> GetDepartmentName();
        Task<AppointmentModel?> GetDoctorAvailableTime(string doc, DateTime selectedDate);
        Task<DoctorModel?> GetDoctorNames(string SelectedDepartment);
        Task<AppointmentModel?> GetUserID();
        Task InsertAppointment(string selectedDep, DateTime selectedDate, string doc, DateTime StartTime, DateTime EndTime);
    }
}