using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Model
{
    class AdminReviewModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Time { get; set; }
        public string Review { get; set; }

        public void Add(int _id,string _firstname,string _time, string _review)
        {
            Id = _id;
            Firstname = _firstname;
            Time = _time;
            Review = _review;
        }
    }
}
