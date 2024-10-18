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

        public Patient? GetById(int id)
        {
            return FakeDatabase.Patients.FirstOrDefault(p => p.Id == id);
        }

        public Patient? Delete(int id)
        {
            var patientToDelete = FakeDatabase.Patients.FirstOrDefault(p => p.Id == id);
            if (patientToDelete != null)
            {
                FakeDatabase.Patients.Remove(patientToDelete);
            }

            return patientToDelete;
        }

        public Patient? AddOrUpdate(Patient? patient)
        {
            return FakeDatabase.AddOrUpdatePatient(patient);
        }
    }
}
