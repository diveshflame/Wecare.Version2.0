using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCare.Data.DataAccess;
using WeCare.Data.Model;
using Wecare.Data.Data.Interface;

namespace WeCare.Data.Data.Doctor
{
    public class DoctorData : IDoctorData
    {

        private readonly ISqldataAccess dbAccess;
        public DoctorData(ISqldataAccess _dbAccess)
        {
            dbAccess = _dbAccess;

        }

        private readonly ICommonFunctions CommonAccess;


        #region Update Doctor
        //Check Doctor Availability before updating
        public Task<IEnumerable<DoctorAvailabilityModel>> CheckDocAvailability(int DocId) => dbAccess.LoadData<DoctorAvailabilityModel, dynamic>(checkDocAvailability, new { DocID = DocId });

        //UpdateDoctor
        public async Task UpdateDoc(int DocId, int DeptId) => await dbAccess.SaveData(updateDoc, new { DocID = DocId, DeptID = DeptId });

        #endregion


        public async Task AddDoctor(string DoctorName, string selectedDepartment)
        {


            var results = await CommonAccess.GetDepartmentID(selectedDepartment);

            int DepartmentId = results.Department_Id;

            var results2 = await CommonAccess.GetDoctorId(DoctorName);

            string InsertDoc = "Insert into doctor(doctor_name,department_id) values(@Doctor_Name,@Department_Id)";
            if (DepartmentId != null)
            {
                //This name already Exists

            }
            else
            {
                await dbAccess.SaveData(InsertDoc, new { Doctor_Name = DoctorName, Department_Id = DepartmentId });
            }
        }

        #region Queries

        string checkDocAvailability = "SELECT DOCTOR_ID FROM DOCTOR_AVAILABILITY WHERE DOCTOR_ID =@DocID";
        string updateDoc = @"UPDATE DOCTOR
                             SET DEPARTMENT_ID = @DeptID
                             WHERE DOCTOR_ID = @DocID
	                            AND DOCTOR_ID NOT IN
		                            (SELECT DOCTOR_ID
			                            FROM DOCTOR_AVAILABILITY);";
        #endregion



    }
}
