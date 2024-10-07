using Library.Clinic.Models;
using Library.Clinic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Clinic.ViewModels
{
    public class AppointmentViewModel
    {
        public Appointment? Model { get; set; }

        public string PatientName
        {
            get
            {
                if(Model != null && Model.PatientId > 0)
                {
                    if(Model.Patient == null)
                    {
                        Model.Patient = PatientServiceProxy
                            .Current
                            .Patients
                            .FirstOrDefault(p => p.Id == Model.PatientId);
                    }
                }

                return Model?.Patient?.Name ?? string.Empty;
            }
        }

        public AppointmentViewModel() { }
        public AppointmentViewModel(Appointment a)
        {
            Model = a;
        }
    }
}
