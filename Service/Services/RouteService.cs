using Domain.Entities;
using Domain.Entities.DTOResults;
using Domain.Interfaces;
using Service.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class RouteService : IRouteService
    {
        private readonly IRouteRepository _routeRepository;

        public RouteService(IRouteRepository routeRespository)
        {
            _routeRepository = routeRespository;
        }

        public IList<RankedRouteDTO> CheckCheapestRoute(string origin, string destination)
        {
            return _routeRepository.CheckCheapestRoute(origin, destination);
        }
    }
}