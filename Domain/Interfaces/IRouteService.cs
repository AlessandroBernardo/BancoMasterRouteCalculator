using Domain.Entities;
using Domain.Entities.DTOResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IRouteService
    {
        IList<RankedRouteDTO> CheckCheapestRoute(string origin, string destination);
    }
}
