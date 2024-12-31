using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PrescriptionManager : IPrescriptionService
    {
        IPrescriptionDal _prescriptionDal;

        public PrescriptionManager(IPrescriptionDal prescriptionDal)
        {
            _prescriptionDal = prescriptionDal;
        }

        public void TAdd(Prescription t)
        {
            _prescriptionDal.Insert(t);
        }

        public void TDelete(Prescription t)
        {
            _prescriptionDal.Delete(t);
        }

        public Prescription TGetByID(int id)
        {
            return _prescriptionDal.GetByID(id);
        }

        public List<Prescription> TGetList()
        {
            return _prescriptionDal.GetList();
        }

        public List<Prescription> TGetListPrescriptionWithAppointment()
        {
            return _prescriptionDal.GetListPrescriptionWithAppointment();
        }

        public void TUpdate(Prescription t)
        {
            _prescriptionDal.Update(t);
        }
    }
}
