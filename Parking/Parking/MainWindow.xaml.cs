using Parking.DataBase;
using Parking.ViewModel;
using Parking.EnterAndRegist;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Parking
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                using(KPContext kP = new KPContext())
                {
                    var costplaceinfo = kP.Place.ToList();
                    var cost = costplaceinfo.First();
                    CostPlace.Text = cost.cost.ToString() + " копеек/минута";
                }
            }
            catch(Exception)
            {
                MessageBox.Show("попробуйте позже");
            }
        }
        internal void UserInfo(int id, string firstname, string secondname, string email, string mobile)
        {
            UserId.Text = Convert.ToString(id);
            UserFirstname.Text = firstname;
            UserSecondname.Text = secondname;
            UserEmail.Text = email;
            UserPhone.Text = mobile;
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MyMessege.Text != null || MyMessege.Text.Length < 300 || MyMessege.Text.Length > 1 )
                {
                    using (KPContext kp = new KPContext())
                    {
                        Review review = new Review()
                        {
                            UserId = Convert.ToInt32(UserId.Text),
                            ParkingId = 1,
                            Review1 = MyMessege.Text,
                            TimeRev = GetNetworkDateTime()
                        };
                        MyMessege.Clear();
                        kp.Review.Add(review);
                        kp.SaveChanges();
                        MessageBox.Show("Спасибо! Ваш отзыв очень ценен для нас.");
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Попробуйте позже");
            }
        }

        private void Allrevi_Click(object sender, RoutedEventArgs e)
        {
            AllReview.AllReview Comments = new AllReview.AllReview();
            Comments.Showing();
            Comments.Show();
        }

        private void Reload_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (KPContext kP = new KPContext())
                {
                    FreeBusy.Text = " ";
                    float all = 0;
                    float busy = 0;
                    var inf = kP.Place.ToList();
                    if (inf != null)
                    {
                        foreach (var i in inf)
                        {
                            all++;
                            if (i.Status == false)
                            {
                                busy++;
                            }
                        }
                        if (busy == all)
                        {
                            FreeBusy.Text = "Переполнено";
                        }
                        if (busy != all && busy > 0)
                        {
                            FreeBusy.Text = Convert.ToString(busy / all * 100) + "%";
                        }
                        if (busy == 0)
                        {
                            FreeBusy.Text = "Все свободны";
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Попробуйте позже");
            }
        }

        private void EnterExitPark_Click(object sender, RoutedEventArgs e)
        {
            string sector = " ";
            if (CheckA.IsChecked == true)
            {
                sector = CheckA.Content.ToString();
            }
            if (CheckB.IsChecked == true)
            {
                sector = CheckB.Content.ToString();
            }
            if (CheckC.IsChecked == true)
            {
                sector = CheckC.Content.ToString();
            }
            using (KPContext kP = new KPContext())
            {
                
                try
                {
                    PlaceClear();
                    var ForEnterOrExit = kP.Database.SqlQuery<Booking>($"select * from Booking where Booking.UserID = '{UserId.Text}'");
                    if (ForEnterOrExit != null)
                    {
                        var info = ForEnterOrExit.LastOrDefault();
                        var PlaceInfo = kP.Place.ToList();
                        if (info != null)
                        {
                            if (info.TimeEnd != null) //Парковка
                            {
                                foreach (var i in PlaceInfo)
                                {
                                    if (i.Status == true)
                                    {
                                        if(i.Sector == sector)
                                        {
                                            //int intodata = kP.Database.ExecuteSqlCommand($"insert into Booking (UserID,PlaceID,TimeStart) values ({Convert.ToInt32(UserId.Text)},{Convert.ToInt32(i.PlaceId)},'GETDATE()'");
                                            Booking booking = new Booking();
                                            booking.UserID = Convert.ToInt32(UserId.Text);
                                            booking.PlaceID = Convert.ToInt32(i.PlaceId);
                                            booking.TimeStart = GetNetworkDateTime();
                                            kP.Booking.Add(booking);
                                            kP.SaveChanges();
                                            int upd = kP.Database.ExecuteSqlCommand($"Update Place set Status = 'false' where PlaceId = {i.PlaceId}");
                                            MessageBox.Show("Проезжайте к месту и сектору указаному ниже");
                                            PlaceSector.Text = "Сектор: " + i.Sector;
                                            PlaceNumber.Text = "Номер: " + i.Number;
                                            break;
                                        }
                                    }
                                }


                            }
                            if (info.TimeEnd == null) // выезд из парковки
                            {
                                double endcost;
                                DateTime dateTime = new DateTime();
                                dateTime = GetNetworkDateTime();
                                int chnge = kP.Database.ExecuteSqlCommand($"Update Booking set TimeEnd = '{dateTime}' where BookingId = {Convert.ToInt32(info.BookingId)}");
                                int upd2 = kP.Database.ExecuteSqlCommand($"Update Place set Status = 'true' where PlaceId = {Convert.ToInt32(info.PlaceID)}");
                                var aboutcost = PlaceInfo.Last();
                                endcost = CheckTime(info.TimeStart, dateTime);
                                PlaceSector.Text = "Время стоянки: " + Convert.ToString(endcost);
                                endcost = endcost * aboutcost.cost;
                                PlaceNumber.Text = "Стоимость: " + Convert.ToString(endcost);
                            }
                        }
                        if (info == null)
                        {
                            foreach (var i in PlaceInfo)
                            {
                                if (i.Status == true)
                                {
                                    if (i.Sector == sector)
                                    {
                                        //int intodata = kP.Database.ExecuteSqlCommand($"insert into Booking (UserID,PlaceID,TimeStart) values ({Convert.ToInt32(UserId.Text)},{Convert.ToInt32(i.PlaceId)},'GETDATE()'");
                                        Booking booking = new Booking();
                                        booking.UserID = Convert.ToInt32(UserId.Text);
                                        booking.PlaceID = Convert.ToInt32(i.PlaceId);
                                        booking.TimeStart = GetNetworkDateTime();
                                        kP.Booking.Add(booking);
                                        kP.SaveChanges();
                                        int upd = kP.Database.ExecuteSqlCommand($"Update Place set Status = 'false' where PlaceId = {i.PlaceId}");
                                        MessageBox.Show("Проезжайте к месту и сектору указаному ниже");
                                        PlaceSector.Text = "Сектор: " + i.Sector;
                                        PlaceNumber.Text = "Номер: " + i.Number;
                                        break;
                                    }
                                }
                            }
                        }
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Попробуйте в другое время");
                }
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PlaceClear()
        {
            PlaceNumber.Text = " ";
            PlaceSector.Text = " ";
        }
        private double CheckTime(DateTime start, DateTime end)
        {
            TimeSpan span = new TimeSpan();
            span = end.Subtract(start);
            return span.TotalMinutes;
        }
        public static DateTime GetNetworkDateTime()
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    socket.Connect("time.nist.gov", 13);
                    using (StreamReader rstream = new StreamReader(new NetworkStream(socket)))
                    {
                        string value = rstream.ReadToEnd().Trim();
                        MatchCollection matches = Regex.Matches(value, @"((\d*)-(\d*)-(\d*))|((\d*):(\d*):(\d*))");
                        string[] dd = matches[0].Value.Split('-');
                        return DateTime.Parse($"{matches[1].Value} {dd[2]}.{dd[1]}.{dd[0]}");
                    }
                }
                catch(Exception)
                {
                    return default(DateTime);
                }

            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
