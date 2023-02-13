using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class RankedRouteModel
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal RoutePrice { get; set; }
        public string OrdenedBestRoute { get; set; }
    }
}
