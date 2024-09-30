using Library.Clinic.Models;
using Library.Clinic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Clinic.ViewModels
{
    public class PatientViewModel
    {
        public Patient? Model { get; set; }

        public int Id
        {
            get
            {
                if(Model == null)
                {
                    return -1;
                }

                return Model.Id;
            }

            set
            {
                if(Model != null && Model.Id != value) {
                    Model.Id = value;
                }
            }
        }

        public string Name
        {
            get => Model?.Name ?? string.Empty;
            set
            {
                if(Model != null)
                {
                    Model.Name = value;
                }
            }
        }

        public PatientViewModel()
        {
            Model = new Patient();
        }

        public PatientViewModel(Patient? _model)
        {
            Model = _model;
        }

        public void ExecuteAdd()
        {
            if (Model != null)
            {
                PatientServiceProxy
                .Current
                .AddOrUpdatePatient(Model);
            }

            Shell.Current.GoToAsync("//Patients");
        }
    }
}
