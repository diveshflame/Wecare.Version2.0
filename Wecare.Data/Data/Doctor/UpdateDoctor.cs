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
    public class UpdateDoctor 
    {
        private readonly ISqldataAccess _db;
        public UpdateDoctor(ISqldataAccess db)
        {
            _db = db;
        }

        #region Update Doctor
        //Check Doctor Availability before updating
        public Task<IEnumerable<DoctorAvailabilityModel>> CheckDocAvailability(int DocId) =>_db.LoadData<DoctorAvailabilityModel, dynamic>(checkDocAvailability, new { DocID = DocId });
         
        //UpdateDoctor
        public async Task UpdateDoc(int DocId, int DeptId) => await _db.SaveData(updateDoc, new { DocID = DocId, DeptID = DeptId });

        #endregion

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
