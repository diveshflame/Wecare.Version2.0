
using WeCare.Data.DataAccess;
using WeCare.Data.Model;
using Wecare.Data.Data.Common;
using System.Threading.Tasks;
using System.Collections.Generic;
using Wecare.Data.Data.Interface;
namespace WeCare.Data.Data.Doctor
{
    public class DoctorData : IDoctorData
    {

        private readonly ISqldataAccess _dbAccess;
        public DoctorData(ISqldataAccess dbAccess)
        {
            _dbAccess = dbAccess;

        }

        private readonly ICommonFunctions _commonAccess;


        #region Update Doctor
        //Check Doctor Availability before updating
        string checkDocAvailability = "SELECT DOCTOR_ID FROM DOCTOR_AVAILABILITY WHERE DOCTOR_ID =@DocID";

        public Task<IEnumerable<DoctorAvailabilityModel>> CheckDocAvailability(int DocId) => _dbAccess.LoadData<DoctorAvailabilityModel, dynamic>(checkDocAvailability, new { DocID = DocId });
       
        //UpdateDoctor
        string updateDoc = @"UPDATE DOCTOR
                             SET DEPARTMENT_ID = @DeptID
                             WHERE DOCTOR_ID = @DocID
	                            AND DOCTOR_ID NOT IN
		                            (SELECT DOCTOR_ID
			                            FROM DOCTOR_AVAILABILITY);";
        public async Task UpdateDoc(int docId, int deptId) => await _dbAccess.SaveData(updateDoc, new { DocID = docId, DeptID = deptId });

        #endregion

        #region Add Doctor
        public async Task AddDoctor(string doctorName, string selectedDepartment)
        {


            var results = await _commonAccess.GetDepartmentID(selectedDepartment);

            int departmentId = results.Department_Id;

            var results2 = await _commonAccess.GetDoctorId(doctorName);

            string insertDoc = "Insert into doctor(doctor_name,department_id) values(@Doctor_Name,@Department_Id)";
            if (departmentId != null)
            {
                //This name already Exists

            }
            else
            {
                await _dbAccess.SaveData(insertDoc, new { Doctor_Name = doctorName, Department_Id = departmentId });
            }
        }


        #endregion


    }
}
