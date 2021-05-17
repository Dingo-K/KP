using DevExpress.Mvvm;
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
    class AdminTimeParkingViewModel : ViewModelBase
    {
        public ObservableCollection<AdminTimeParkingModel> bookings { get; set; }
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
            }
        }
        private string number;
        public string Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }
        private string timestart;
        public string Timestart
        {
            get
            {
                return timestart;
            }
            set
            {
                timestart = value;
            }
        }
        private string timeend;
        public string Timeend
        {
            get
            {
                return timeend;
            }
            set
            {
                timeend =value;
            }
        }
        public AdminTimeParkingViewModel()
        {
            using(KPContext kP = new KPContext())
            {
                bookings = new ObservableCollection<AdminTimeParkingModel>();
                var bookinginfo = kP.Booking.ToList();
                foreach(var i in bookinginfo)
                {
                    AdminTimeParkingModel adminTimeParkingModel = new AdminTimeParkingModel();
                    adminTimeParkingModel.Add("Имя Пользователя: " + i.Users.Firstname,"Номер Места: " + i.Place.Number.ToString(),"Начало времени: " + i.TimeStart.ToString(), "Конец времени: " + i.TimeEnd.ToString());
                    bookings.Add(adminTimeParkingModel);
                }
            }
        }
    }
}
