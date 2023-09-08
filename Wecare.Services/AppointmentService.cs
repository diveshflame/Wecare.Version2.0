using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCare.Data.Data;
using WeCare.Data.DataAccess;
using WeCare.Data.Model;

namespace Wecare.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IBookAppointmentData dbAccess;
        public AppointmentService(IBookAppointmentData _dbAccess)
        {
            dbAccess = _dbAccess;

        }

        public async Task<IEnumerable<DepartmentModel>> GetDepartmentId()
        {
            return await dbAccess.GetDepartmentId();
        }



    }
}
