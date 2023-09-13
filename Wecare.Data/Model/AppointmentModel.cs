
namespace WeCare.Data.Model
{
    public class AppointmentModel
    {
        public int Appointment_Id { get; set; }
        public int UserID { get; set; } 
        public int Doctor_Id { get; set; }
        public int Department_Id { get; set; }
        public DateTime Appointment_StartTime { get; set;}
        public DateTime Appointment_EndTime { get; set; }
        public DateTime?  Deleted_TimeStamp { get; set; }
        public string Name { get; set; }
        public string Doctor_Name { get; set; }
        public string Department_Name { get;set; }
       

    }
}
