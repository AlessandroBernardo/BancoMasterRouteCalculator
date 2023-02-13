using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository.Querys.RouteQuerys
{
    public class GetQueries
    {
        public static string GetRankedRoutesSql(string origin, string destination)
        {
            return $@"WITH routes_cte
                 AS (SELECT Cast(origin + ' -> ' + destination AS VARCHAR(100)) AS OrdenedBestRoute,
                            origin,
                            destination,
                            price,
                            Cast(price AS DECIMAL(18, 2))                       AS
                            RoutePrice
                     FROM   route
                     WHERE  origin = '{origin}'
                     UNION ALL
                     SELECT Cast(r.OrdenedBestRoute + ' -> ' + t.destination AS VARCHAR(100)) AS OrdenedBestRoute,
                            t.origin,
                            t.destination,
                            t.price,
                            Cast(r.RoutePrice + t.price AS DECIMAL(18, 2))         AS
                            RoutePrice
                     FROM   route t
                            join routes_cte r
                              ON t.origin = r.destination
                     WHERE  r.destination <> '{destination}')
            SELECT origin      AS Origin,
                   destination AS Destination,
                   OrdenedBestRoute,
                   RoutePrice
            FROM   routes_cte
            WHERE  destination = '{destination}'
            ORDER  BY RoutePrice;";
        }
    }
}
