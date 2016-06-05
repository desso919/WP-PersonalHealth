using PersonalHealthCareApp.Common;
using PersonalHealthCareApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PersonalHealthCareApp.ViewModel
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool canExecute = true;
        private string username;
        private ICommand profileCommand;
        private ICommand historyCommand;
        private ICommand visitationCommand;
        private ICommand addVisitationCommand;
    
        public HomeViewModel()
        {
            profileCommand = new MyRelayCommand(profile);
            historyCommand = new MyRelayCommand(history);
            visitationCommand = new MyRelayCommand(visitation);
            addVisitationCommand = new MyRelayCommand(addVisitation);
            toggleExecuteCommand = new RelayCommand(ChangeCanExecute);
            Username = "Welcome, " + LoggedInPatient.GetPatient().FirstName;
        }

        private void addVisitation(object obj)
        {
            ((Frame)Window.Current.Content).Navigate(typeof(AddVisitationView));
        }

        private void visitation(object obj)
        {
            ((Frame)Window.Current.Content).Navigate(typeof(SheduledVisitationView));
        }

        private void history(object obj)
        {
            ((Frame)Window.Current.Content).Navigate(typeof(HistoryView));
        }

        private void profile(object obj)
        {
           
        }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));

            }
        }

        private ICommand toggleExecuteCommand { get; set; }

        public ICommand ProfileCommand
        {
            get { return profileCommand; }
            set { profileCommand = value; }
        }

        public ICommand HistoryCommand
        {
            get { return historyCommand; }
            set { historyCommand = value; }
        }

        public ICommand AddVisitationCommand
        {
            get { return addVisitationCommand; }
            set { addVisitationCommand = value; }
        }

        public ICommand VisitationCommand
        {
            get { return visitationCommand; }
            set { visitationCommand = value; }
        }

        public bool CanExecute
        {
            get { return this.canExecute; }
            set { this.canExecute = value; }
        }

        public ICommand ToggleExecuteCommand
        {
            get { return toggleExecuteCommand; }
            set { toggleExecuteCommand = value; }
        }


        public void ChangeCanExecute()
        {
            canExecute = !canExecute;
        }
    }
}
