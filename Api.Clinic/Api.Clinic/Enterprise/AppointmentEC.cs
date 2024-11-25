using Api.Clinic.Database;
using Library.Clinic.Models;

namespace Api.Clinic.Enterprise
{
    public class AppointmentEC
    {
        public IEnumerable<Appointment> Appointments
        {
            get
            {
                var apps = new MsSqlContext().GetAppointments();
                return apps;
            }
        }

        public Appointment Update(Appointment app)
        {
            new MsSqlContext().UpdateAppointment(app);

            return app;
        }

        public Appointment Create(Appointment app)
        {
            return new MsSqlContext().CreateAppointment(app);
        }

        public void Delete(int id)
        {
            new MsSqlContext().DeleteAppointment(id);
            return;
        }
    }
}
