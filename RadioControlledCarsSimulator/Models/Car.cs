using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioControlledCarsSimulator.Models
{
    class Car
    {
        public string Type { get; set; }

        public Coordinates Coordinates { get; set; }

        public char Heading { get; set; }
    }
}
