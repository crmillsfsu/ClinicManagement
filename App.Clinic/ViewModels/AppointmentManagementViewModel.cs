using Library.Clinic.Models;
using Library.Clinic.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Clinic.ViewModels
{
    public class AppointmentManagementViewModel
    {
        private AppointmentServiceProxy _appSvc = AppointmentServiceProxy.Current;

        public ObservableCollection<AppointmentViewModel> Appointments
        {
            get
            {
                return new ObservableCollection<AppointmentViewModel>(
                    _appSvc.Appointments.Select(a => new AppointmentViewModel(a)));
            }

        }
    }
}
