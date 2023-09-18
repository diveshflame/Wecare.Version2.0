
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
        public async Task<IEnumerable<DepartmentModel>> GetDepartmentName() => await _db.LoadData<DepartmentModel, dynamic>(getDepartmentName, new { });
        public Task<IEnumerable<DoctorModel>> GetDoctorName() => _db.LoadData<DoctorModel, dynamic>(getDoctorName, new { });


        
        public async Task<DoctorModel?> GetDoctorId(string selectedDoctorName)
        {
            var results = await _db.LoadData<DoctorModel, dynamic>(getDoctorId, new { DocName = selectedDoctorName });
            return results.FirstOrDefault();
        }
        public async Task<DepartmentModel?> GetDepartmentID(string selectedDepartName)
        {
            var results = await _db.LoadData<DepartmentModel, dynamic>(getDepartmentId, new { DeptName = selectedDepartName });
            return results.FirstOrDefault();
        }
        #endregion



        #region Queries
        string getDepartmentName = "SELECT DEPARTMENT_NAME FROM DEPARTMENT;";
        string getDoctorName = "SELECT DOCTOR_NAME FROM DOCTOR;";
        string getDoctorId = "SELECT DOCTOR_ID FROM DOCTOR WHERE DOCTOR_NAME = @DocName";
        string getDepartmentId = "SELECT DEPARTMENT_ID FROM DEPARTMENT WHERE DEPARTMENT_NAME =@DeptName";
        #endregion
    }
}
