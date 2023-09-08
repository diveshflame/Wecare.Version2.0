using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCare.Data.DataAccess;
using WeCare.Data.Model;

namespace WeCare.Data.Data.Doctor
{
    public class DoctorData : IDoctorData
    {

        private readonly ISqldataAccess dbAccess;
        public DoctorData(ISqldataAccess _dbAccess)
        {
            dbAccess = _dbAccess;

        }
        #region Update Doctor
        //Check Doctor Availability before updating
        public Task<IEnumerable<DoctorAvailabilityModel>> CheckDocAvailability(int DocId) => dbAccess.LoadData<DoctorAvailabilityModel, dynamic>(checkDocAvailability, new { DocID = DocId });

        //UpdateDoctor
        public async Task UpdateDoc(int DocId, int DeptId) => await dbAccess.SaveData(updateDoc, new { DocID = DocId, DeptID = DeptId });

        #endregion

       
        string GetDepartmentNames = "SELECT consultant_desc AS Department_Name from consultant_type AS Department_Name";

        public Task<IEnumerable<DepartmentModel>> GetDep() => dbAccess.LoadData<DepartmentModel, dynamic>(GetDepartmentNames, new { });
        public async Task AddDoctor(string text, string selectedConsultation)
        {

            string GetConID = "SELECT consultant_id AS Department_Id from consultant_Type where @Selectedconsult = consultant_desc";
            var results = await dbAccess.LoadData<DepartmentModel, dynamic>(GetConID, new { Selectedconsult = selectedConsultation });
            int consultantId = results.FirstOrDefault()?.Department_Id ?? 0;
            string GetDocID = "SELECT doctor_Id from doctor_table where @Doctor_Name=doctor_name";
            var results2 = await dbAccess.LoadData<DoctorModel, dynamic>(GetDocID, new { Doctor_Name = text });

            string InsertDoc = "Insert into doctor_table(Doctor_name,consultant_id) values(@DoctorN,@Consult_Id)";
            if (consultantId != null)
            {
                //This name already Exists

            }
            else
            {
                await dbAccess.SaveData(InsertDoc, new { DoctorN = text, Consult_Id = consultantId });
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
