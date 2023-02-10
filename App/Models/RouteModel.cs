using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class RouteModel : BaseModel
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal Value { get; set; }
    }
}
