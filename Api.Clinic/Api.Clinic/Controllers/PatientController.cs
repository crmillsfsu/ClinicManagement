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

        [HttpGet("GetById")]
        public IEnumerable<Patient> GetById()
        {
            return new PatientEC().Patients;
        }
    }
}
