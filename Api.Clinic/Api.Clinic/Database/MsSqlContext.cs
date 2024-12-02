using Library.Clinic.Models;
using Microsoft.Data.SqlClient;

namespace Api.Clinic.Database
{
    public class MsSqlContext
    {
        private string connectionString = "Server=CMILLS;Database=Clinic;Trusted_Connection=True;TrustServerCertificate=True";

        public MsSqlContext() { }

        public IEnumerable<Patient> GetPatients()
        {
            var returnVal = new List<Patient>();
            using (var conn = new SqlConnection(connectionString))
            {
                var str = "select * from Patient";
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = str;

                    try
                    {
                        conn.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var newApp = new Patient
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"].ToString()
                            };

                            returnVal.Add(newApp);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }

            return returnVal;
        }

        public List<Appointment> GetAppointments()
        {
            var returnVal = new List<Appointment>();
            using (var conn = new SqlConnection(connectionString))
            {
                var str = "select * from Appointments";
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = str;

                    try { 
                        conn.Open();
                        var reader = cmd.ExecuteReader();
                        while(reader.Read())
                        {
                            var newApp = new Appointment
                            {
                                Id = (int)reader["Id"]
                                , PatientId = (int)reader["PatientId"]
                                , StartTime = DateTime.Parse(reader["StartTime"].ToString() ?? "1901-01-01")
                                , EndTime = DateTime.Parse(reader["EndTime"].ToString() ?? "1901-01-01")
                            };

                            returnVal.Add(newApp);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }

            return returnVal;
        }

        public void DeleteAppointment(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var str = "Appointments.[Delete]";
                using (var cmd = new SqlCommand(str, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var param = new SqlParameter("@appointmentId", id);
                    cmd.Parameters.Add(param);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void UpdateAppointment(Appointment app)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var str = "Appointments.[Update]";
                using (var cmd = new SqlCommand(str, conn))
                {
                    /*exec Appointments.[Update] 
@date = '2025-08-01'
, @physicianId = 6
, @patientId = 1003
, @appointmentId = 1*/

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@date", app.StartTime));
                    cmd.Parameters.Add(new SqlParameter("@physicianId", 3));
                    cmd.Parameters.Add(new SqlParameter("@patientId", app.PatientId));
                    cmd.Parameters.Add(new SqlParameter("@appointmentId", app.Id));
                    cmd.Parameters.Add(new SqlParameter("@startTime", app.StartTime));
                    cmd.Parameters.Add(new SqlParameter("@endTime", app.StartTime));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public Appointment CreateAppointment(Appointment app)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var str = "Appointments.[Create]";
                using (var cmd = new SqlCommand(str, conn))
                {
                    /*declare @id int
                    exec Appointments.[Create] 
                    @patientId = 1003 
                    , @physicianId = 6
                    , @date = '2025-03-01'
                    , @appointmentId = @id output
                    select @id*/

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@date", app.StartTime));
                    cmd.Parameters.Add(new SqlParameter("@physicianId", 3));
                    cmd.Parameters.Add(new SqlParameter("@patientId", app.PatientId));
                    cmd.Parameters.Add(new SqlParameter("@startTime", app.StartTime));
                    cmd.Parameters.Add(new SqlParameter("@endTime", app.EndTime));
                    var param = new SqlParameter("@appointmentId", app.Id);
                    param.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    app.Id = (int)param.Value;
                    conn.Close();
                }

                return app;
            }
        }

    }
}
