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
    public class EfPatientAnswersDal : GenericRepository<PatientAnswers>, IPatientAnswersDal
    {
        public List<PatientAnswers> GetListAnswersWithCheckups()
        {
            using (var c = new Context())
            {
                return c.PatientAnswers.Include(x => x.Checkup).ToList();
            }
        }
    }
}
