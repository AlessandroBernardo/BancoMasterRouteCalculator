using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class RouteModel : BaseModel
    {
        private string _origin;
        private string _destination;

        public string Origin
        {
            get { return _origin; }
            set { _origin = value.ToUpper(); }
        }

        public string Destination
        {
            get { return _destination; }
            set { _destination = value.ToUpper(); }
        }

        public decimal Price { get; set; }
    }
}
