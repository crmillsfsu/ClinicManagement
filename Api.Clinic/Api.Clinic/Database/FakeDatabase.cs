using Library.Clinic.Models;

namespace Api.Clinic.Database
{
    static public class FakeDatabase
    {
        public static int LastKey
        {
            get
            {
                if (Patients.Any())
                {
                    return Patients.Select(x => x.Id).Max();
                }
                return 0;
            }
        }
        private static List<Patient> patients = new List<Patient>
                {
                    new Patient{Id = 1, Name = "John Doe"}
                    , new Patient{Id = 2, Name = "Jane Doe"}
                };
        public static List<Patient> Patients { 
            get
            {
                return patients;
            } 
        }
        public static Patient? AddOrUpdatePatient(Patient? patient)
        {
            if (patient == null)
            {
                return null;
            }

            bool isAdd = false;
            if (patient.Id <= 0)
            {
                patient.Id = LastKey + 1;
                isAdd = true;
            }

            if (isAdd)
            {
                Patients.Add(patient);
            }

            return patient;
        }
    }
}
