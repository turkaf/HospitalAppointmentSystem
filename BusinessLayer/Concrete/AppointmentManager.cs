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
    public class AppointmentManager : IAppointmentService
    {
        private readonly IAppointmentDal _appointmentDal;

        public AppointmentManager(IAppointmentDal appointmentDal)
        {
            _appointmentDal = appointmentDal;
        }

        public List<Appointment> GetAppointmentsByDoctorId(int doctorId)
        {
            return _appointmentDal.GetListByFilter(a => a.DoctorID == doctorId).ToList();
        }

        public List<Appointment> GetAppointmentsByPatientId(int patientId)
        {
            return _appointmentDal.GetListByFilter(a => a.PatientID == patientId).ToList();
        }

        public void TAdd(Appointment t)
        {
            _appointmentDal.Insert(t);
        }

        public void TDelete(Appointment t)
        {
            _appointmentDal.Delete(t);
        }

        public Appointment TGetByID(int id)
        {
            return _appointmentDal.GetByID(id);
        }

        public List<Appointment> TGetList()
        {
            return _appointmentDal.GetList();
        }

        public List<Appointment> TGetListAppointmentWithPatient()
        {
            return _appointmentDal.GetListAppointmentWithPatient();
        }

        public void TUpdate(Appointment t)
        {
            _appointmentDal.Update(t);
        }
    }
}
