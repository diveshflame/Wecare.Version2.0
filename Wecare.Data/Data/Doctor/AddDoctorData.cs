using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCare.Data.DataAccess;
using WeCare.Data.Model;

namespace WeCare.Data.Data.Doctor
{
    public class AddDoctorData : IAddDoctorData
    {
        private readonly ISqldataAccess _db;
        public AddDoctorData(ISqldataAccess db)
        {
            _db = db;
        }
        string GetCon = "SELECT consultant_desc from consultant_type";
        public Task<IEnumerable<DepartmentModel>> Get() => _db.LoadData<DepartmentModel, dynamic>(GetCon, new { });
        public Task<IEnumerable<DepartmentModel>> GetDep() => _db.LoadData<DepartmentModel, dynamic>(GetCon, new { });
        public async Task AddDoctor(string text, string selectedConsultation)
        {
            string GetConID = "SELECT consultant_id from consultant_Type where @Selectedconsult = consultant_desc";
            var results = await _db.LoadData<DoctorModel, dynamic>(GetConID, new { Selectedconsult = selectedConsultation });
            string GetDocID = "SELECT doctor_Id from doctor_table where @Doctor_Name=doctor_name";
            var results2 = await _db.LoadData<AppointmentModel, dynamic>(GetDocID, new { Doctor_Name = text });
            string InsertDoc = "insert into doctor_table(Doctor_name,consultant_id) values(@DoctorN,@Consult_Id)";
            if (results2 != null)
            {
                //This name already Exists
            }
            else
            {
                await _db.SaveData(InsertDoc, new { DoctorN = text, Consult_Id = results });
            }
        }

    }
}
