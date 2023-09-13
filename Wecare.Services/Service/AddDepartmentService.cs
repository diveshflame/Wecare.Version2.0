using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wecare.Data.Data.Interface;
using WeCare.Data.DataAccess;
using WeCare.Data.Model;

namespace Wecare.Services.Service
{
    public class AddDepartmentService 
    {
        public Task AddDepartment(string Department)
        {
            
        }
        private readonly IDepartmentData _departmentData;
        public AddDepartmentService(IDepartmentData departmentData)
        {
            departmentData = _dbAccess;

        }

    }
}
