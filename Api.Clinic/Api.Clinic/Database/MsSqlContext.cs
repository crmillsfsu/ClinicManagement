using Library.Clinic.Models;
using Microsoft.Data.SqlClient;

namespace Api.Clinic.Database
{
    public class MsSqlContext
    {
        private string connectionString = "Server=CMILLS;Database=Clinic;Trusted_Connection=True;TrustServerCertificate=True";

        public MsSqlContext() { }

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
                                , StartTime = DateTime.Parse(reader["Date"].ToString() ?? "1901-01-01")
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
    }
}
