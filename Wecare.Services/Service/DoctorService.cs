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
        public DoctorService(IDoctorData _dbAccess, ICommonFunctions _functions)
        {
            dbAccess = _dbAccess;
            functions = _functions;

        }
        public async Task<DepartmentModel?> GetDepartment()
        {
            var Department = await dbAccess.GetDepartment();
            return Department.FirstOrDefault();
        }
        public async Task AddDoctor(string text, string selectedDepartment)
        {
            await dbAccess.AddDoctor(text, selectedDepartment);
            string message = "Succesfully Inserted";
        }
         public async Task UpdateDoctor(string selectedDocName, string selectedDepartName)
        {
          
           var getDoctorId= await functions.GetDoctorId(selectedDocName);
           var getDepartmentId= await functions.GetDepartmentID(selectedDepartName);
         //  await dbAccess.UpdateDoc(getDoctorId, getDepartmentId);
            
        }


    }
}
