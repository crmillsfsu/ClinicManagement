using App.Clinic.ViewModels;
using Library.Clinic.Models;
using Library.Clinic.Services;


namespace App.Clinic.Views;

[QueryProperty(nameof(PatientId), "patientId")]
public partial class PatientView : ContentPage
{
	public PatientView()
	{
		InitializeComponent();
		
	}
    public int PatientId { get; set; }

    private void CancelClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//Patients");
    }

    private void AddClicked(object sender, EventArgs e)
    {
        (BindingContext as PatientViewModel)?.ExecuteAdd();
    }

    private void PatientView_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        //TODO: this really needs to be in a view model
        if(PatientId > 0)
        {
            var model = PatientServiceProxy.Current
                .Patients.FirstOrDefault(p => p.Id == PatientId);
            if(model != null)
            {
                BindingContext = new PatientViewModel(model);
            } else
            {
                BindingContext = new PatientViewModel();
            }
            
        } else
        {
            BindingContext = new PatientViewModel();
        }
        
    }
}