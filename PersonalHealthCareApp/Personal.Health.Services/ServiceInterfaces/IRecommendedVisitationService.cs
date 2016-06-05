﻿using Personal.Health.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Health.Services.ServiceInterfaces
{
    public interface IRecommendedVisitationService
    {
        RecommendedVisitation GetRecommendedVisitation(long id);

        List<RecommendedVisitation> GetRecommendedVisitationForPatient(int age);
    }
}
