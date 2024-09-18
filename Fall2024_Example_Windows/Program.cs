using Library.Clinic.Models;
using Library.Clinic.Services;
using System;
namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool isContinue = true;
            do
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("A. Add a Patient");
                Console.WriteLine("Q. Quit");

                string input = Console.ReadLine() ?? string.Empty;

                if (char.TryParse(input, out char choice))
                {
                    switch (choice)
                    {
                        case 'a':
                        case 'A':
                            var name = Console.ReadLine();
                            var newPatient = new Patient { Name = name ?? string.Empty };
                            PatientServiceProxy.Current.AddOrUpdatePatient(newPatient);
                            break;
                        case 'd':
                        case 'D':
                            PatientServiceProxy.Current.Patients.ForEach(x => Console.WriteLine($"{x.Id}. {x.Name}"));
                            int selectedPatient = int.Parse(Console.ReadLine() ?? "-1");
                            PatientServiceProxy.Current.DeletePatient(selectedPatient);

                            break;
                        case 'u':
                        case 'U':
                            break;
                        case 'r':
                        case 'R':
                            break;
                        case 'q':
                        case 'Q':
                            isContinue = false;
                            break;
                        default:
                            Console.WriteLine("That is an invalid choice!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine(choice + " is not a char");
                }
            } while (isContinue);

            foreach (var patient in PatientServiceProxy.Current.Patients)
            {
                Console.WriteLine($"{patient}");
            }

            PatientServiceProxy.Current.Patients.Where(x => x.Name.Contains("John")).ToList().ForEach(Console.WriteLine);
        }
    }
}