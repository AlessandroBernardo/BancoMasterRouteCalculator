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
    public class RouteRepository : IRouteRepository
    {

        protected readonly SqlContext _sqlContext;
        protected readonly ICustomRoutesValidators _customRoutesValidators;
        protected readonly IInMemoryBaseRepository<Route> _baseRepository;

        public RouteRepository(SqlContext sqlContext, ICustomRoutesValidators customRoutesValidators, IInMemoryBaseRepository<Route> baseRepository)
        {
            _sqlContext = sqlContext;
            _customRoutesValidators = customRoutesValidators;
            _baseRepository = baseRepository;
        }

        public IList<RankedRouteDTO> CheckCheapestRoute(string origin, string destination)
        {
            string sql = GetQueries.GetRankedRoutesSql(origin, destination);

            var result = _sqlContext.RankedRouteDTOs.FromSqlRaw(sql).ToList();

            return result;
        }       
     }
}
