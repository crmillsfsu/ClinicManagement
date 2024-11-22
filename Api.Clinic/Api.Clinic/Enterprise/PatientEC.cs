using Api.Clinic.Database;
using Library.Clinic.DTO;
using Library.Clinic.Models;

namespace Api.Clinic.Enterprise
{
    public class PatientEC
    {
        public PatientEC() { }

        public IEnumerable<PatientDTO> Patients
        {
            get
            {
                var appointments = new AppointmentEC().Appointments;
                return FakeDatabase.Patients.Take(100).Select(p => new PatientDTO(p));
            }
        }

        public IEnumerable<PatientDTO>? Search(string query)
        {
            return FakeDatabase.Patients
                .Where(p => p.Name.ToUpper()
                    .Contains(query?.ToUpper() ?? string.Empty))
                .Select(p => new PatientDTO(p));
        }

        public PatientDTO? GetById(int id)
        {
            var patient = FakeDatabase
                .Patients
                .FirstOrDefault(p => p.Id == id);
            if(patient != null)
            {
                return new PatientDTO(patient);
            }

            return null;
        }

        public PatientDTO? Delete(int id)
        {
            var patientToDelete = FakeDatabase.Patients.FirstOrDefault(p => p.Id == id);
            if (patientToDelete != null)
            {
                FakeDatabase.Patients.Remove(patientToDelete);
                return new PatientDTO(patientToDelete);
            }

            return null;
        }

        public Patient? AddOrUpdate(PatientDTO? patient)
        {
            if(patient == null)
            {
                return null;
            }
            return FakeDatabase.AddOrUpdatePatient(new Patient(patient));
        }
    }
}
