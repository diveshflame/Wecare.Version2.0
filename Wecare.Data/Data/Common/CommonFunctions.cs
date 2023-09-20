
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeCare.Data.DataAccess;
using WeCare.Data.Model;

namespace Wecare.Data.Data.Common
{
    public class CommonFunctions : ICommonFunctions
    {
        private readonly ISqldataAccess _db;
        public CommonFunctions(ISqldataAccess db)
        {
            _db = db;
        }



        #region Get Values

        public async Task<List<string?>> GetDepartmentName()
        {
            var results = await _db.LoadData<DepartmentModel, dynamic>(getDepartmentName, new { });
            var departmentNames = results.Select(department => department.Department_Name);
            List<string> departmentNamesList = results.Select(department => department.Department_Name).ToList();
            return departmentNamesList;
        }

        public Task<IEnumerable<DoctorModel>> GetDoctorName() => _db.LoadData<DoctorModel, dynamic>(getDoctorName, new { });
        public async Task<DoctorModel?> GetDoctorId(string selectedDoctorName)
        {
            var results = await _db.LoadData<DoctorModel, dynamic>(getDoctorId, new { DocName = selectedDoctorName });
            return results.FirstOrDefault();
        }

        #endregion

        # region Get Department ID
        //To get the department Id using department name from department table
        string getDepartmentId = "SELECT DEPARTMENT_ID FROM DEPARTMENT WHERE DEPARTMENT_NAME =@DeptName";
        public async Task<DepartmentModel?> GetDepartmentID(string selectedDepartName)
        {
            var results = await _db.LoadData<DepartmentModel, dynamic>(getDepartmentId, new { DeptName = selectedDepartName });
            return results.FirstOrDefault();
        }
        #endregion



    }
}
