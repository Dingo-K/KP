using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Model
{
    class AdminTimeParkingModel
    {
        public string Firstname { get; set; }
        public string Number { get; set; }
        public string Timestart { get; set; }
        public string Timeend { get; set; }
        public void Add(string firstname,string number,string timestart,string timeend)
        {
            Firstname = firstname;
            Number = number;
            Timestart = timestart;
            Timeend = timeend;
        }
    }
}
