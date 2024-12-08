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
    public class DoctorManager : IDoctorService
    {
        IDoctorDal _doctorDal;

        public DoctorManager(IDoctorDal doctorDal)
        {
            _doctorDal = doctorDal;
        }
        public void TAdd(Doctor t)
        {
            _doctorDal.Insert(t);
        }

        public void TDelete(Doctor t)
        {
            _doctorDal.Delete(t);
        }

        public Doctor TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> TGetList()
        {
            return _doctorDal.GetList();
        }

        public void TUpdate(Doctor t)
        {
            _doctorDal.Update(t);
        }
    }
}
