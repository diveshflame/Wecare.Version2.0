using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wecare.Data.Data.Common;
using Wecare.Services.Interfaces;
using WeCare.Data.Data;
using WeCare.Data.Data.Doctor;
using WeCare.Data.Model;

namespace Wecare.Services.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorData dbAccess;
        private readonly ICommonFunctions functions;
        public DoctorService(IDoctorData _dbAccess)
        {
            dbAccess = _dbAccess;
          
        }
        public async Task<string?> GetDepartment()
        {
            var Department = await functions.GetDepartmentName();
            return Department.FirstOrDefault().ToString();

        }
        public async Task AddDoctor(string text, string selectedDepartment)
        {
            await dbAccess.AddDoctor(text, selectedDepartment);
            string message = "Succesfully Inserted";
        }

        #region Display the values in view
        public Task<IEnumerable<DepartmentModel>> GetDepartmentName() => functions.GetDepartmentName();
        public Task<IEnumerable<DoctorModel>> GetDoctorName() => functions.GetDoctorName();
        #endregion


        #region Update Doctor
        public async Task<bool> UpdateDoctor(string selectedDocName, string selectedDepartName)
        {

            var getDoctorId = await functions.GetDoctorId(selectedDocName);
            var getDepartmentId = await functions.GetDepartmentID(selectedDepartName);
            var count = await dbAccess.CheckDocAvailability(getDoctorId.Doctor_Id);
            //count.FirstOrDefault();
            bool valid = false;
            if (count == null)
            {
                return !valid;
            }
            else
            {
                await dbAccess.UpdateDoc(getDoctorId.Doctor_Id, getDepartmentId.Department_Id);
            }
            return valid;
        }
        #endregion
    }
}
