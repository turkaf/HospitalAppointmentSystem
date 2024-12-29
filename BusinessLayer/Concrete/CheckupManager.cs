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
    public class CheckupManager : ICheckupService
    {
        ICheckupDal _checkupDal;

        public CheckupManager(ICheckupDal checkupDal)
        {
            _checkupDal = checkupDal;
        }

        public void TAdd(Checkup t)
        {
            _checkupDal.Insert(t);
        }

        public void TDelete(Checkup t)
        {
            _checkupDal.Delete(t);
        }

        public Checkup TGetByID(int id)
        {
            return _checkupDal.GetByID(id);
        }

        public List<Checkup> TGetList()
        {
            return _checkupDal.GetList();
        }

        public void TUpdate(Checkup t)
        {
            _checkupDal.Update(t);
        }
    }
}
