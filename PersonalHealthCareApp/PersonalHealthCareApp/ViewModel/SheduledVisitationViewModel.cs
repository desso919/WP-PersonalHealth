using Hospital.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PersonalHealthCareApp.ViewModel
{
    public class SheduledVisitationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        List<ScheduledVisitation> visitations;
        private ScheduledVisitation selectedVisitation;
        private Boolean hasSelectedTemplate;
  
        #region Constructor

        public SheduledVisitationViewModel()
        {
            GetPatientVisitations();
        }

        #endregion

        #region Properties

        public List<ScheduledVisitation> Visitations { get { return visitations; } set { visitations = value; NotifyPropertyChanged(); } } 

        public ScheduledVisitation SelectedVisitation { get { return selectedVisitation; } set { HasSelectedVisitation = true; selectedVisitation = value; NotifyPropertyChanged(); } }

        public Boolean HasSelectedVisitation { get { return hasSelectedTemplate; } set { hasSelectedTemplate = value; NotifyPropertyChanged(); } }
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
        
        #region Get sheduled Visitation

        public async void GetPatientVisitations()
        {
            string response = await GetPatientVisitationsAsync();
            response = response.TrimStart('\"');
            response = response.TrimEnd('\"');
            response = response.Replace("\\", "");

            Visitations = JsonConvert.DeserializeObject<List<ScheduledVisitation>>(response);
        }

        public async Task<string> GetPatientVisitationsAsync()
        {
            HttpClient http = new HttpClient();
            var myRequest = new HttpRequestMessage(HttpMethod.Get, "http://localhost:6446/HospitalService.svc/record/" + LoggedInPatient.GetPatient().Id);
            var resp = await http.SendAsync(myRequest);
            return await resp.Content.ReadAsStringAsync();
        }

        #endregion
    }
}
