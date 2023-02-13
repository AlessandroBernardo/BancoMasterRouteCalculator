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


//public Route CreateRoute(Route route)
//{
//    try
//    {

//        //var _routes = Get();
//        CustomValidator customValidator = new CustomValidator();
//        IReadOnlyList<Route> _routes = (IReadOnlyList<Route>)Get();
//        if (customValidator.RouteExists(_routes, route))
//        {
//            throw new Exception("Já existe essa rota");
//        }
//        Add<RouteValidator>(route);
//        return route;
//    }
//    catch (Exception ex)
//    {
//        throw new Exception(ex.Message);
//    }

//}