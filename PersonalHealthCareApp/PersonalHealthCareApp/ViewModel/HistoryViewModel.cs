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
    public class HistoryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private static HistoryViewModel instance;
        private List<History> histories;
        private History selectedHistory;

        #region Constructor

        public HistoryViewModel()
        {
            GetPatientHistory();

        }

        private void ViewSelectedHistory(object obj)
        {
            //ViewHistory viewHistory = new ViewHistory(SelectedHistory);
           //viewHistory.ShowDialog();
        }

        #endregion

        #region Properties

        public List<History> Histories { get { return histories; } set { histories = value; NotifyPropertyChanged(); } }

        public History SelectedHistory { get { return selectedHistory; } set { selectedHistory = value; NotifyPropertyChanged(); } }

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

        public async void GetPatientHistory()
        {
            string response = await GetPatientHistoryAsync();
            response = response.TrimStart('\"');
            response = response.TrimEnd('\"');
            response = response.Replace("\\", "");

            Histories = JsonConvert.DeserializeObject<List<History>>(response);
        }

        public async Task<string> GetPatientHistoryAsync()
        {
            HttpClient http = new HttpClient();
            var myRequest = new HttpRequestMessage(HttpMethod.Get, "http://localhost:6446/HospitalService.svc/record/" + LoggedInPatient.GetPatient().Id);
            var resp = await http.SendAsync(myRequest);
            return await resp.Content.ReadAsStringAsync();
        }
    }
}
