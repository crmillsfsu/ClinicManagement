namespace App.Clinic.Views;

public partial class AppointmentManagementView : ContentPage
{
	public AppointmentManagementView()
	{
		InitializeComponent();
	}

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}