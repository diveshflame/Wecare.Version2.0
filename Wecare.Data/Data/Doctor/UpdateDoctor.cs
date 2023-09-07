using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCare.Data.DataAccess;
using WeCare.Data.Model;

namespace WeCare.Data.Data.Doctor
{
    public class UpdateDoctor : IUpdateDoctor
    {
        private readonly ISqldataAccess _db;
        public UpdateDoctor(ISqldataAccess db)
        {
            _db = db;
        }

        #region Get Values
        public Task<IEnumerable<DepartmentModel>> GetDepartmentName() => _db.LoadData<DepartmentModel, dynamic>(getDepartmentName, new { });
        public Task<IEnumerable<DoctorModel>> GetDoctorName() => _db.LoadData<DoctorModel, dynamic>(getDoctorName, new { });

        public async Task<DoctorModel?> GetDoctorId(string selectedDocname)
        {
            var results = await _db.LoadData<DoctorModel, dynamic>(getDoctorId, new { DocName = selectedDocname });
            return results.FirstOrDefault();
        }
        public async Task<DepartmentModel?> GetDepartmentID(string selectedDepartName)
        {
            var results = await _db.LoadData<DepartmentModel, dynamic>(getDeptId, new { DeptName = selectedDepartName });
            return results.FirstOrDefault();
        }
        #endregion

        #region Update Doctor
        //Check Availability
        public async Task<DoctorAvailabilityModel?> CheckDocAvailability(int DocId)
        {
            var results = await _db.LoadData<DoctorAvailabilityModel, dynamic>(checkDocAvailability, new { DocID = DocId });
            return results.FirstOrDefault();
        }
        //UpdateDoctor
        public async Task UpdateDoc(int DocId, int DeptId) => await _db.SaveData(updateDoc, new { DocID = DocId, DeptID = DeptId });

        #endregion

        #region Queries
        string getDepartmentName = "SELECT consultant_desc from consultant_type";
        string getDoctorName = "SELECT doctor_name from doctor_table";
        string getDoctorId = "Select Doctor_Id from Doctor_Table where Doctor_Name=@DocName";
        string getDeptId = "Select consultant_Id from Consultant_Type where consultant_Desc=@DeptName";
        string checkDocAvailability = "Select Doctor_Id from Doctor_Availability where Doctor_id=@DocID";
        string updateDoc = @"UPDATE DOCTOR_TABLE
                             SET CONSULTANT_ID = @DeptID
                             WHERE DOCTOR_ID = @DocID
	                            AND DOCTOR_ID NOT IN
		                            (SELECT DOCTOR_ID
			                            FROM DOCTOR_AVAILABILITY);";
        #endregion

    }
}
