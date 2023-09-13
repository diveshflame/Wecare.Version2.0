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

        #region Get Department Name
        //To get all the department name form the department Table
        string getDepartmentName = "SELECT DEPARTMENT_NAME FROM DEPARTMENT;";
        public Task<IEnumerable<DepartmentModel>> GetDepartmentName() => _db.LoadData<DepartmentModel, dynamic>(getDepartmentName, new { });
        #endregion

        #region Get Doctor Name
        //To get all the doctor name form the doctor Table
        string getDoctorName = "SELECT DOCTOR_NAME FROM DOCTOR;";
        public Task<IEnumerable<DoctorModel>> GetDoctorName() => _db.LoadData<DoctorModel, dynamic>(getDoctorName, new { });

        #endregion

        #region Get Doctor Id
        //To get the doctor Id using doctor name from doctor table
        string getDoctorId = "SELECT DOCTOR_ID FROM DOCTOR WHERE DOCTOR_NAME = @DocName";
        public async Task<DoctorModel?> GetDoctorId(string selectedDoctorname)
        {
            var results = await _db.LoadData<DoctorModel, dynamic>(getDoctorId, new { DocName = selectedDoctorname });
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
