using Api.Clinic.Enterprise;
using Library.Clinic.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Clinic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;

        public PatientController(ILogger<PatientController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return new PatientEC().Patients;
        }

        [HttpGet("{id}")]
        public Patient? GetById(int id)
        {
            return new PatientEC().GetById(id);
        }

        [HttpDelete("{id}")]
        public Patient? Delete(int id)
        {
            return new PatientEC().Delete(id);
        }

        [HttpPost]
        public Patient? AddOrUpdate([FromBody] Patient? patient)
        {
            return new PatientEC().AddOrUpdate(patient);
        }
    }
}
