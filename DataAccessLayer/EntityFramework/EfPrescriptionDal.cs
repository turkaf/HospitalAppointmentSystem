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
    public class EfPrescriptionDal : GenericRepository<Prescription>, IPrescriptionDal
    {
        public List<Prescription> GetListPrescriptionWithAppointment()
        {
            using (var c = new Context())
            {
                return c.Prescriptions
                    .Include(x => x.Appointment)
                        .ThenInclude(d => d.Doctor)
                            .ThenInclude(c => c.Clinic)
                    .ToList();
            }
        }
    }
}
