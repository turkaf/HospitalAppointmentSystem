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
    public class PatientAnswersManager : IPatientAnswersService
    {
        IPatientAnswersDal _patientAnswersDal;

        public PatientAnswersManager(IPatientAnswersDal patientAnswersDal)
        {
            _patientAnswersDal = patientAnswersDal;
        }

        public void TAdd(PatientAnswers t)
        {
            _patientAnswersDal.Insert(t);
        }

        public void TDelete(PatientAnswers t)
        {
            _patientAnswersDal.Delete(t);
        }

        public PatientAnswers TGetByID(int id)
        {
            return _patientAnswersDal.GetByID(id);
        }

        public List<PatientAnswers> TGetList()
        {
            return _patientAnswersDal.GetList();
        }

        public void TUpdate(PatientAnswers t)
        {
            _patientAnswersDal.Update(t);
        }
    }
}
