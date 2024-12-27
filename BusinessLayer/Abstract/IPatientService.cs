using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPatientService : IGenericService<Patient>
    {
        Patient ValidatePatient(string email, string password);
        IEnumerable<Patient> GetPatientsByDoctorId(int doctorId);
    }
}
