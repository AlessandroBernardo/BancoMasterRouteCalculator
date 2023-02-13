using Data.Context;
using Data.Repository.Querys.RouteQuerys;
using Domain.Entities;
using Domain.Entities.DTOResults;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repository
{
    public class InMemoryRouteRepository : IRouteRepository
    {

        protected readonly ContextInMemory _inMemoryContext;
        protected readonly ICustomRoutesValidators _customRoutesValidators;
        protected readonly IInMemoryBaseRepository<Route> _baseRepository;

        public InMemoryRouteRepository(ContextInMemory inMemoryContext, ICustomRoutesValidators customRoutesValidators, IInMemoryBaseRepository<Route> baseRepository)
        {
            _inMemoryContext = inMemoryContext;
            _customRoutesValidators = customRoutesValidators;
            _baseRepository = baseRepository;
        }

        public IList<RankedRouteDTO> CheckCheapestRoute(string origin, string destination)
        {

            var routes = _inMemoryContext.Set<Route>().ToList();

            var firstResult = (from route in routes
                                      where route.Origin == origin
                                      select new
                                      {
                                          OrdenedBestRoute = route.Origin + " -> " + route.Destination,
                                          route.Origin,
                                          route.Destination,
                                          route.Price,
                                          RoutePrice = (decimal)route.Price
                                      }).ToList();

            var result = (from route in routes
                          join secondResult in firstResult
                            on route.Origin equals secondResult.Destination
                          where route.Destination != destination
                          select new
                          {
                              OrdenedBestRoute = secondResult.OrdenedBestRoute + " -> " + route.Destination,
                              route.Origin,
                              route.Destination,
                              route.Price,
                              RoutePrice = secondResult.RoutePrice + route.Price
                          }).Where(r => r.Destination == destination)
                          .OrderBy(r => r.RoutePrice)
                          .Select(r => new
                          {
                              r.Origin,
                              r.Destination,
                              r.OrdenedBestRoute,
                              r.RoutePrice
                          });

            return (IList<RankedRouteDTO>)(RankedRouteDTO)result;
        }       
     }
}
