using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.DTOResults
{
    public class RankedRouteDTO
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal RoutePrice { get; set; }
        public string OrdenedBestRoute { get; set; }
    }
}
