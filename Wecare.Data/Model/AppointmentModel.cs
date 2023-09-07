using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeCare.Data.Model
{
    public class AppointmentModel
    {
        public int BookID { get; set; }
        public int UserID { get; set; } 
        public int Doctor_Id { get; set; }
        public int Consultant_Id { get; set; }
        public DateTime StartTime { get; set;}
        public DateTime EndTime { get; set; }

    }
}
