using Library.Clinic.Models;
using Library.Clinic.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace App.Clinic.ViewModels
{
    public class PatientManagementViewModel: INotifyPropertyChanged
    {
        public PatientManagementViewModel() {
            SortChoices = new List<SortChoiceEnum>
            {
               SortChoiceEnum.NameAscending
              , SortChoiceEnum.NameDescending
            };

            SortChoice = SortChoiceEnum.NameAscending;
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<SortChoiceEnum> SortChoices { get; set; }

        private SortChoiceEnum sortChoice;
        public SortChoiceEnum SortChoice { 
            get
            {
                return sortChoice;
            }
            set
            {
                if (sortChoice != value)
                {
                    sortChoice = value;
                    NotifyPropertyChanged("Patients");
                }
            }
        }

        public PatientViewModel? SelectedPatient { get; set; }
        public string? Query { get; set; }
        public ObservableCollection<PatientViewModel> Patients
        {
            get
            {
                var retVal = new ObservableCollection<PatientViewModel>(
                    PatientServiceProxy
                    .Current
                    .Patients
                    .Where(p=>p != null)
                    .Where(p => p.Name.ToUpper().Contains(Query?.ToUpper() ?? string.Empty))
                    .Select(p => new PatientViewModel(p))
                    );

                if(SortChoice == SortChoiceEnum.NameAscending)
                {
                    return
                        new ObservableCollection<PatientViewModel>(retVal.OrderBy(p => p.Name));
                } else
                {
                    return
                        new ObservableCollection<PatientViewModel>(retVal.OrderByDescending(p => p.Name));
                }
            }
        }

        public void Delete()
        {
            if(SelectedPatient == null)
            {
                return;
            }
            PatientServiceProxy.Current.DeletePatient(SelectedPatient.Id);

            Refresh();
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Patients));
        }

        public async void Search()
        {
            if (Query != null)
            {
                await PatientServiceProxy.Current.Search(Query);
            }
            Refresh();
        }
    }
}
