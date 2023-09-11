using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wecare.Services.Interfaces;
using WeCare.Data.Data;
using WeCare.Data.Data.Doctor;
using WeCare.Data.Model;

namespace Wecare.Services.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorData dbAccess;
        public DoctorService(IDoctorData _dbAccess)
        {
            dbAccess = _dbAccess;

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



    }
}
