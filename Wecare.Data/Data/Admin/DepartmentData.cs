using System;
using System.Linq;
using System.Threading.Tasks;
using WeCare.Data.DataAccess;
using WeCare.Data.Model;
using Wecare.Data.Data.Interface;

namespace Wecare.Data.Data.Admin
{
    public class DepartmentData : IDepartmentData
    {
        private readonly ISqldataAccess _dbAccess;
        public DepartmentData(ISqldataAccess dbAccess)
        {
            _dbAccess = dbAccess;

        }
        #region Checking Department
        public async Task<DepartmentModel?> CheckDepartment(string department)
        {
            string count = "Select COUNT(*) from department where deparmtent_Desc =@_department";
            var departmentCount = await _dbAccess.LoadData<DepartmentModel, dynamic>(count, new { _department = department });
            return departmentCount.FirstOrDefault();
        }
        #endregion
        #region AddDepartment
        public async Task AddDepartment(string department)
        {
            string departmentStatus;
            if (Convert.ToInt32(CheckDepartment(department).ToString()) > 0)
            {
                departmentStatus = "Already Exists";
            }
            else
            {
                string insertDepartment = "Insert into department(department_name) values(@_department)";
                await _dbAccess.SaveData(insertDepartment, new { _department = department });
            }
        }
        #endregion
    }
}
