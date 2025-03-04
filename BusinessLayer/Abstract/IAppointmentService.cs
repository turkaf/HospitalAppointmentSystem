﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAppointmentService : IGenericService<Appointment>
    {
        List<Appointment> GetAppointmentsByDoctorId(int doctorId);
        List<Appointment> GetAppointmentsByPatientId(int patientId);
        List<Appointment> TGetListAppointmentWithPatient();
    }
}
