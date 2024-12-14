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
    public class ClinicManager : IClinicService
    {
        IClinicDal _clinicDal;

        public ClinicManager(IClinicDal clinicDal)
        {
            _clinicDal = clinicDal;
        }

        public void TAdd(Clinic t)
        {
            _clinicDal.Insert(t);
        }

        public void TDelete(Clinic t)
        {
            _clinicDal.Delete(t);
        }

        public Clinic TGetByID(int id)
        {
            return _clinicDal.GetByID(id);
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
