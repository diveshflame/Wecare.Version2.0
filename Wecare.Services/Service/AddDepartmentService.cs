
using Wecare.Data.Data.Admin;
using Wecare.Services.Interfaces;

namespace Wecare.Services.Service
{
    public class AddDepartmentService : IAddDepartmentService
    {
        public async Task AddDepartment(string Department)
        {
            await _departmentData.AddDepartment(Department);
        }
        private readonly IDepartmentData _departmentData;
        public AddDepartmentService(IDepartmentData departmentData)
        {
            departmentData = _departmentData;

        }

    }
}
