using WeCare.Data.Model;

namespace WeCare.Data.Data
{
    public interface IBookAppointmentData
    {
        Task<AppointmentModel?> AddBook(string selectedDep, DateTime selectedDate, string doc, DateTime d1, DateTime d2);
        Task<IEnumerable<DepartmentModel>> BookGetCo();
        Task<AppointmentModel?> BookGetDoc(string selectedConsultation);
        Task<AppointmentModel?> BookGetTime(string doc, DateTime selectedDate);
    }
}