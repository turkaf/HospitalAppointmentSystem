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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void TAdd(Admin t)
        {
            _adminDal.Insert(t);
        }

        public void TDelete(Admin t)
        {
            _adminDal.Delete(t);
        }

        public Admin TGetByID(int id)
        {
            return _adminDal.GetByID(id);
        }

        public List<Admin> TGetList()
        {
            return _adminDal.GetList();
        }

        public void TUpdate(Admin t)
        {
            _adminDal.Update(t);
        }

        public Admin ValidateAdmin(string username, string password)
        {
            return _adminDal.GetListByFilter(a => a.UserName == username && a.Password == password).FirstOrDefault();
        }
    }
}
