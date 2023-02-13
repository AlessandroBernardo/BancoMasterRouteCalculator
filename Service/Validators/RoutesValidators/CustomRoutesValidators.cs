using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Services
{
    public class CustomRoutesValidators : ICustomRoutesValidators
    {
        private readonly SqlContext _sqlContext;

        public CustomRoutesValidators(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public bool RouteExists(Route route)
        {            
            return _sqlContext.Routes.Any(r => r.Origin == route.Origin 
                                       && r.Destination == route.Destination 
                                       && r.Price == route.Price);
        }
    }
}
