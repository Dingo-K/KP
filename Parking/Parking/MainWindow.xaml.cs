using Parking.DataBase;
using Parking.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
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
            if(MyMessege.Text != null)
            {
                using (KPContext kp = new KPContext())
                {
                    Review review = new Review()
                    {
                        UserId = Convert.ToInt32(UserId.Text),
                        ParkingId = 1,
                        Review1 = MyMessege.Text,
                        TimeRev = DateTime.Now
                    };
                    MyMessege.Clear();
                    kp.Review.Add(review);
                    kp.SaveChanges();
                    MessageBox.Show("Спасибо! Ваш отзыв очень ценен для нас.");
                }
            }
        }

        private void Allrevi_Click(object sender, RoutedEventArgs e)
        {
            AllReview.AllReview Comments = new AllReview.AllReview();
            Comments.Showing();
            Comments.Show();
        }
    }
}
