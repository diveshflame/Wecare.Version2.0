using System.Collections.Generic;
using System.Threading.Tasks;
using WeCare.Data.Model;

namespace Wecare.Data.Data.Interface
{
    public interface IDoctorData
    {
        Task AddDoctor(string DoctorName, string selectedDepartment);
        Task<IEnumerable<DoctorAvailabilityModel>> CheckDocAvailability(int DocId);
        Task UpdateDoc(int DocId, int DeptId);
    }
}