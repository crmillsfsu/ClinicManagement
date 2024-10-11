using App.Clinic.ViewModels;

namespace App.Clinic.Views;

public partial class AppointmentView : ContentPage
{
	public AppointmentView()
	{
		InitializeComponent();
		BindingContext = new AppointmentViewModel();
	}

    private void CancelClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//Appointments");
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as AppointmentViewModel)?.AddOrUpdate();
        Shell.Current.GoToAsync("//Appointments");
    }

    private void TimePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        (BindingContext as AppointmentViewModel)?.RefreshTime();
    }
}