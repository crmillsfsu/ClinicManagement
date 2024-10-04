﻿namespace App.Clinic
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void PatientsClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Patients");
        }

        private void AppointmentsClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Appointments");
        }
    }

}
