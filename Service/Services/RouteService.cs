using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class RouteService : BaseService<Route>
    {
        private readonly IRouteRepository _routeRepository;
        
        public RouteService(IRouteRepository routeRespository) : base(routeRespository)
        {
            _routeRepository = routeRespository;
        }
    }
}
