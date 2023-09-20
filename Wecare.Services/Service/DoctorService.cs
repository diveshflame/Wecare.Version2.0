
using Wecare.Data.Data.Common;
using Wecare.Services.Interfaces;
using WeCare.Data.Data.Doctor;
using WeCare.Data.Model;
using Wecare.Data.Data.Interface;
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


        #region Get the departments
        public async Task<List<string>> GetDepartment()
        {

            var departmentResult = await functions.GetDepartmentName();
            return departmentResult;
        }
        public async Task<string?> GetDocID(string DocName)
        {
            var docID = await functions.GetDoctorId(DocName);
            return docID.ToString();
        }
        public async Task AddDoctor(string text, string selectedDepartment)
        {
            await dbAccess.AddDoctor(text, selectedDepartment);
            string message = "Succesfully Inserted";
        }
        #endregion
        #region Display the values in view
        public Task<List<string>> GetDepartmentName() => functions.GetDepartmentName();
        public Task<IEnumerable<DoctorModel>> GetDoctorName() => functions.GetDoctorName();
        #endregion
        #region Update Doctor
        public async Task UpdateDoctor(string selectedDocName, string selectedDepartName)
        {
            var getDoctorId = await functions.GetDoctorId(selectedDocName);
            var getDepartmentId = await functions.GetDepartmentID(selectedDepartName);
            var count = await dbAccess.CheckDocAvailability(getDoctorId.Doctor_Id);
            if (count == null)
            {
                string message = "You Cannot update!!!!The doctor is already booked";
            }
            else
            {
                await dbAccess.UpdateDoc(getDoctorId.Doctor_Id, getDepartmentId.Department_Id);
                string message2 = "Successfully Updated";
            }
        }
        #endregion


    }
}
