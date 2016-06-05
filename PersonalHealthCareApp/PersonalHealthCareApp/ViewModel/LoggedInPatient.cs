using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalHealthCareApp.ViewModel
{
    public sealed class LoggedInPatient
    {
        private static readonly object syncLock = new object();
        private static Patient loggedInPatient;

        public static void Init(Patient patient)
        {
            if (patient != null)
            {
                loggedInPatient = patient;
            }
        }

        public static Patient GetPatient()
        {
            lock (syncLock)
            {
                return loggedInPatient;
            }
        }

        public static void LogoutPatient()
        {
            lock (syncLock)
            {
                loggedInPatient = null;
            }

        }
    }
}
