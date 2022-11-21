using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_API
{
    public class WindInfo
    {
        public WindInfo()
        {

        }

        public double speed { get; set; } //Wind Speed in Meters/Sec or Miles/Hour.
        public double deg { get; set; } //Wind direction in degrees.
    }
}
