using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeCare.Data.Model
{
    public class DoctorAvailabilityModel
    {
        public int Doctor_Id { get; set; }
        public DateTime Avaialable_StartTime { get; set; }
        public DateTime Available_EndtTime { get; set; }
    }
}
