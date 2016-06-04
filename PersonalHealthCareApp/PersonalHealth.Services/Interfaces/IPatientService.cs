using PersonalHealth.Models.AppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalHealth.Services.Interfaces
{
    public interface IPatientService
    {
        Patient GetPatient(long id);

        Patient Login(string username, string password);

        Boolean RegisterUser(Patient patientToBeAdded);
    }
}
