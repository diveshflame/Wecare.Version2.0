using System.Threading.Tasks;
using WeCare.Data.Model;

namespace Wecare.Data.Data.Interface
{
    public interface IDepartmentData
    {
        Task AddDepartment(string Department);
        Task<DepartmentModel?> CheckDepartment(string Department);
    }
}