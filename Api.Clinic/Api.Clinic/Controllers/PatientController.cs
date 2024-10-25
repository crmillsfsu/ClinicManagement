using Api.Clinic.Enterprise;
using Library.Clinic.DTO;
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
        public IEnumerable<PatientDTO> Get()
        {
            return new PatientEC().Patients;
        }

        [HttpGet("{id}")]
        public PatientDTO? GetById(int id)
        {
            return new PatientEC().GetById(id);
        }

        [HttpDelete("{id}")]
        public PatientDTO? Delete(int id)
        {
            return new PatientEC().Delete(id);
        }

        [HttpPost]
        public Patient? AddOrUpdate([FromBody] PatientDTO? patient)
        {
            return new PatientEC().AddOrUpdate(patient);
        }
    }
}
