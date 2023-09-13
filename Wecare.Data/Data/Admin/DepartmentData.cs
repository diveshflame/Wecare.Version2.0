using Wecare.Data.Data.Interface;
using WeCare.Data.Model;

namespace Wecare.Data.Data.Admin
{
    public class DepartmentData : IDepartmentData
    {
        private readonly ISqldataAccess dbAccess;
        public DepartmentData(ISqldataAccess _dbAccess)
        {
            dbAccess = _dbAccess;

        }

        public async Task<DepartmentModel?> CheckDepartment(string Department)
        {
            string count = "Select COUNT(*) from department where deparmtent_Desc =@_department";
            var DepartmentCount = await dbAccess.LoadData<DepartmentModel, dynamic>(count, new { _department = Department });
            return DepartmentCount.FirstOrDefault();
        }
        public async Task AddDepartment(string Department)
        {
            if (Convert.ToInt32(CheckDepartment(Department).ToString()) > 0)
            {

            }
            else
            {
                string InsertDep = "Insert into department(department_name) values(@_department)";
                await dbAccess.SaveData(InsertDep, new { _department = Department });
            }
        }
    }
}
