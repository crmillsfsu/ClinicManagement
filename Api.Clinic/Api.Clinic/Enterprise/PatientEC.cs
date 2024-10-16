using Api.Clinic.Database;
using Library.Clinic.Models;

namespace Api.Clinic.Enterprise
{
    public class PatientEC
    {
        public PatientEC() { }

        public IEnumerable<Patient> Patients
        {
            get
            {
                return FakeDatabase.Patients;
            }
        }
    }
}
