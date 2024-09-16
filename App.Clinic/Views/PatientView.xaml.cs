using Library.Clinic.Models;
using Library.Clinic.Services;
using System.ComponentModel;

namespace App.Clinic.Views;

public partial class PatientView : ContentPage
{
	public PatientView()
	{
		InitializeComponent();
		
	}

    private void CancelClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//Patients");
    }

    private void AddClicked(object sender, EventArgs e)
    {
        var patientToAdd = BindingContext as Patient;
        if (patientToAdd != null)
        {
            PatientServiceProxy
            .Current
            .AddPatient(patientToAdd);
        }

        Shell.Current.GoToAsync("//Patients");
    }

    private void PatientView_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new Patient();
    }
}