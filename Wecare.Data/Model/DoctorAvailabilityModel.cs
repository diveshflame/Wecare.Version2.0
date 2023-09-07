using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeCare.Data.Model
{
    public class DoctorAvailabilityModel
    {
        public int doctor_id { get; set; }
        public DateTime avaialable_starttime { get; set; }
        public DateTime available_endttime { get; set; }
    }
}
