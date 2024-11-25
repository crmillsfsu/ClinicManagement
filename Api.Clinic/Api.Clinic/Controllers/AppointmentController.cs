using Api.Clinic.Enterprise;
using Library.Clinic.DTO;
using Library.Clinic.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Clinic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly ILogger<AppointmentController> _logger;

        public AppointmentController(ILogger<AppointmentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Appointment> Get()
        {
            return new AppointmentEC().Appointments;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new AppointmentEC().Delete(id);
        }

        [HttpPost("UpdateAppointment")]
        public Appointment Update([FromBody] Appointment appointment)
        {
            return new AppointmentEC().Update(appointment);
        }

        [HttpPost]
        public Appointment Create([FromBody] Appointment appointment)
        {
            return new AppointmentEC().Create(appointment);
        }
    }
}
