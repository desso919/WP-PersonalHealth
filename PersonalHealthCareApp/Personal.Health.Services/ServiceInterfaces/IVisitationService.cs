﻿using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Services
{
    public interface IVisitationService
    {
        ScheduledVisitation GetVisitation(long id);

        List<ScheduledVisitation> GetAllScheduledVisitationsForThisPatient(long patientId);

        Boolean MakeVisitationHistory(long id, string diagnose);

        Boolean AddNewScheduleVisitation(ScheduledVisitation visitatin);

        Boolean EditVisitation(ScheduledVisitation visitatin);
    }
}
