using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.AllReview
{
    class AllRev
    {
        public string Firstname { get; set; }
        public string Time { get; set; }
        public string Review { get; set; }

        public void Add(string _firstname,string _time,string _review)
        {
            Firstname = _firstname;
            Time = _time;
            Review = _review;
        }
    }
}
