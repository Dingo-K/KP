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
using System.Windows;
using System.Windows.Input;

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
                try
                {
                    var revi = kP.Review.ToList();
                    Reviews = new ObservableCollection<AdminReviewModel>();
                    var sortrevi = from t in revi
                                   orderby t.TimeRev
                                   select t;
                    foreach (var r in sortrevi)
                    {
                        AdminReviewModel model = new AdminReviewModel();
                        model.Add(r.ReviewId, r.Users.Firstname, r.TimeRev.ToString(), r.Review1);
                        Reviews.Add(model);
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Попробуйте позже");
                }
            }
        }
        public ICommand delete => new DelegateCommand(Delete);
        public void Delete()
        {
            using (KPContext kP = new KPContext())
            {
                try
                {
                    int numberofdelete = kP.Database.ExecuteSqlCommand($"delete from Review where ReviewId = {review.Id}");
                    MessageBox.Show("Комментарий удален");
                    foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
                    {
                        if (window.DataContext == this)
                        {
                            window.Close();
                        }
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Попробуйте позже");
                }
            }
        }
    }
}
