using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class RouteRepository : BaseRepository<Route>
    {
        public RouteRepository(SqlContext context) : base(context)
        {

        }

    }
}
