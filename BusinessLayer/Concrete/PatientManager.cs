using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PatientManager : IPatientService
    {
        IPatientDal _patientDal;

        public PatientManager(IPatientDal patientDal)
        {
            _patientDal = patientDal;
        }

        public IEnumerable<Patient> GetPatientsByDoctorId(int doctorId)
        {
            var patients = _patientDal.GetListByFilter(p => p.Appointments.Any(a => a.DoctorID == doctorId));

            return patients;
        }

        public void TAdd(Patient t)
        {
            _patientDal.Insert(t);
        }

        public void TDelete(Patient t)
        {
            _patientDal.Delete(t);
        }

        public Patient TGetByID(int id)
        {
            return _patientDal.GetByID(id);
        }

        public List<Patient> TGetList()
        {
            return _patientDal.GetList();
        }

        public void TUpdate(Patient t)
        {
            throw new NotImplementedException();
        }

        public Patient ValidatePatient(string email, string password)
        {
            return _patientDal.GetListByFilter(p => p.Email == email && p.Password == password).FirstOrDefault();
        }
    }
}
