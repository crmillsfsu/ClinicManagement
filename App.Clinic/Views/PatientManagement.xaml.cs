namespace App.Clinic.Views;

public partial class PatientManagement : ContentPage
{
	public PatientManagement()
	{
		InitializeComponent();
	}

    private void CancelClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//MainPage");
    }
}