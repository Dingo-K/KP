using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.AllReview
{
    class AllRev
    {
        public string firstname { get; set; }
        public string time { get; set; }
        public string review { get; set; }

        public void Add(string _firstname,string _time,string _review)
        {
            firstname = _firstname;
            time = _time;
            review = _review;
        }
    }
}
