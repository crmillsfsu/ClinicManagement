using App.Clinic.ViewModels;

namespace App.Clinic.Views;

public partial class AppointmentManagementView : ContentPage
{
	public AppointmentManagementView()
	{
		InitializeComponent();
        BindingContext = new AppointmentManagementViewModel();
	}

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AppointmentDetails");
    }
}