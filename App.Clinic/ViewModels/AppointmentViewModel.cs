using Library.Clinic.Models;
using Library.Clinic.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public Patient? SelectedPatient { 
            get
            {
                return Model?.Patient;
            }

            set
            {
                var selectedPatient = value;
                if(Model != null)
                {
                    Model.Patient = selectedPatient;
                    Model.PatientId = selectedPatient?.Id ?? 0;
                }

            }
         }
        public ObservableCollection<Patient> Patients { 
            get
            {
                return new ObservableCollection<Patient>(PatientServiceProxy.Current.Patients);
            }
        }

        public AppointmentViewModel() {
            Model = new Appointment();
        }
        public AppointmentViewModel(Appointment a)
        {
            Model = a;
        }

        public void AddOrUpdate()
        {
            if(Model != null)
            {
                AppointmentServiceProxy.Current.AddOrUpdate(Model);
            }
            
        }
    }
}
