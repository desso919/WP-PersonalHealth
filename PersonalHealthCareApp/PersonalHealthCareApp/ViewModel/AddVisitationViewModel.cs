using Hospital.Models;
using PersonalHealthCareApp.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PersonalHealthCareApp.ViewModel
{
    public class AddVisitationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand addVisitationCommand;
        private ScheduledVisitation visitation;

        public AddVisitationViewModel()
        {
            visitation = new ScheduledVisitation();
            addVisitationCommand = new MyRelayCommand(AddVisitation);
        }

        #region Properties

        public ScheduledVisitation Visitation
        {
            get { return visitation; }
            set { visitation = value; NotifyPropertyChanged(); }
        }

        public ICommand AddVisitationCommand
        {
            get { return addVisitationCommand; }
            set { addVisitationCommand = value; }
        }

        #endregion

        #region INotifyPropertyChanged

        private void NotifyPropertyChanged([CallerMemberName] string propName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));

            }
        }

        #endregion

        #region Add Visitation Code

        public void AddVisitation(Object obj)
        {
          
        }

        #endregion
    }
}
