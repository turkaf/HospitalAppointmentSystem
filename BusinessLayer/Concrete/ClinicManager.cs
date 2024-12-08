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
    public class ClinicManager : IClinicService
    {
        IClinicDal _clinicDal;

        public ClinicManager(IClinicDal clinicDal)
        {
            _clinicDal = clinicDal;
        }

        public void TAdd(Clinic t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Clinic t)
        {
            throw new NotImplementedException();
        }

        public Clinic TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Clinic> TGetList()
        {
            return _clinicDal.GetList();
        }

        public void TUpdate(Clinic t)
        {
            throw new NotImplementedException();
        }
    }
}
