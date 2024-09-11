using Library.Clinic.Models;
using Library.Clinic.Services;

namespace App.Clinic.Views;

public partial class PatientManagement : ContentPage
{
	public List<Patient> Patients
	{
		get
		{
			return PatientServiceProxy.Current.Patients;
		}
	}
	public PatientManagement()
	{
		InitializeComponent();
		BindingContext = this;
	}

    private void CancelClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//MainPage");
    }
}