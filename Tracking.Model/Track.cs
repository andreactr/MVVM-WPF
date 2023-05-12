using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking.Model
{
    public class Track
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string Tracking { get; set; }
        public bool Check { get; set; }
    }
}
