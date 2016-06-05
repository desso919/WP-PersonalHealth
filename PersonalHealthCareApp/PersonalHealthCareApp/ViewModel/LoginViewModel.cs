using Hospital.Models;
using Newtonsoft.Json;
using PersonalHealthCareApp.Common;
using PersonalHealthCareApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PersonalHealthCareApp.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public const string EMPTY_JSON = "{}";
        private string loginStatus;
        private string username;
        private string password;

        private ICommand loginCommand;
        private bool canExecute = true;

        public LoginViewModel()
        {
            loginCommand = new RelayCommand(LoginPatient);
            toggleExecuteCommand = new RelayCommand(ChangeCanExecute);
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    NotifyPropertyChanged();
                }
            }
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

     
        public string LoginStatus
        {
            get
            {
                return loginStatus;
            }
            set
            {
                loginStatus = value;
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

        public ICommand LoginCommand
        {
            get { return loginCommand; }
            set { loginCommand = value; }
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

        public async void LoginPatient()
        {
           string response = await LoginPatientAsync();
           response = response.TrimStart('\"');
           response = response.TrimEnd('\"');
           response = response.Replace("\\", "");

           if (response.Equals(EMPTY_JSON) || Username == null || Password == null )
           {
               LoginStatus = "Invalid username or password";
           }
           else
           {
               Patient user = JsonConvert.DeserializeObject<Patient>(response);
               LoggedInPatient.Init(user);

               ((Frame)Window.Current.Content).Navigate(typeof(HomeView));
           }           
        }

        public async Task<string> LoginPatientAsync()
        {
            HttpClient http = new HttpClient();
            var myRequest = new HttpRequestMessage(HttpMethod.Get, "http://localhost:6446/HospitalService.svc/patient/" + Username + "/password/" + Password);
            var resp = await http.SendAsync(myRequest);
            return await resp.Content.ReadAsStringAsync();
        }


    }
}
