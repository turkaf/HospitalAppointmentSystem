using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfDoctorDal : GenericRepository<Doctor>, IDoctorDal
    {
        public List<Doctor> GetListDoctorWithClinic()
        {
            using(var c = new Context())
            {
                return c.Doctors.Include(x => x.Clinic).ToList();
            }
        }
    }
}
