using Library.Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Clinic.DTO
{
    public class PatientDTO
    {
        public override string ToString()
        {
            return $"[{Id}] {Name}";
        }

        //TODO: Remove this and put it on a ViewModel instead
        public string Display
        {
            get
            {
                return $"[{Id}] {Name}";
            }
        }
        public int Id { get; set; }
        public string? Name { get; set;}
        public DateTime Birthday { get; set; }
        public string? Address { get; set; }
        public string? SSN { get; set; }

        public PatientDTO() { }
        public PatientDTO(Patient p)
        {
            Id = p.Id;
            Name = p.Name;
            Birthday = p.Birthday;
            Address = p.Address;
            SSN = p.SSN;
        }
    }
}
