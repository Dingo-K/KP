using DevExpress.Mvvm;
using Parking.Admin;
using Parking.AllReview;
using Parking.DataBase;
using Parking.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.ViewModel
{
    class AdminReviewViewModel : ViewModelBase
    {
        private AdminReviewModel review;
        public ObservableCollection<AdminReviewModel> Reviews { get; set; }
        public AdminReviewModel Review
        {
            get
            {
                return review;
            }
            set
            {
                review = value;
                RaisePropertiesChanged("Review");
            }
        }
        private string firstname;
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
                RaisePropertiesChanged("Firstname");
            }
        }
        private string time;
        public string Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
                RaisePropertiesChanged("Time");
            }
        }
        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                RaisePropertiesChanged("Id");
            }
        }
        public AdminReviewViewModel()
        {
            using(KPContext kP = new KPContext())
            {
                var revi = kP.Review.ToList();
                Reviews = new ObservableCollection<AdminReviewModel>();
                foreach(var r in revi)
                {
                    AdminReviewModel model = new AdminReviewModel();
                    model.Add(r.UserId, r.Users.Firstname, r.TimeRev.ToString(), r.Review1);
                    Reviews.Add(model);
                }
                
            }
        }
    }
}
