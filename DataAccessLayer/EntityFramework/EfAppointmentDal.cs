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
    public class EfAppointmentDal : GenericRepository<Appointment>, IAppointmentDal
    {
        public List<Appointment> GetListAppointmentWithPatient()
        {
            using (var c = new Context())
            {
                return c.Appointments
                    .Include(x => x.Patient)
                    .Include(x => x.Doctor)
                        .ThenInclude(d => d.Clinic)
                    .ToList();
            }
        }
    }
}
