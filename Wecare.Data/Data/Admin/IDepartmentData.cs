using System.Threading.Tasks;
using WeCare.Data.Model;

namespace Wecare.Data.Data.Admin
{
    public interface IDepartmentData
    {
        Task AddDepartment(string Department);
        Task<DepartmentModel?> CheckDepartment(string Department);
    }
}