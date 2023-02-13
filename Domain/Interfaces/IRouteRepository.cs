﻿using Domain.Entities;
using Domain.Entities.DTOResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IRouteRepository
    {

        IList<RankedRouteDTO> CheckCheapestRoute(string origin, string destination);

        //void CreateRoute(Route route);
    }
}
