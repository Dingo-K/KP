using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Parking.Admin
{
    /// <summary>
    /// Логика взаимодействия для MainAdmin.xaml
    /// </summary>
    public partial class MainAdmin : Window
    {
        public MainAdmin()
        {
            InitializeComponent();
        }

        private void AdRev_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AdminReview adminReview = new AdminReview();
                adminReview.Show();
            }
            catch(Exception)
            {
                MessageBox.Show("Попробуйте позже");
            }
        }

        private void Place_Click(object sender, RoutedEventArgs e)
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
            try
            {
                AdminPlaceStatusInfo adminPlaceStatusInfo = new AdminPlaceStatusInfo();
                adminPlaceStatusInfo.Showing(sector);
                adminPlaceStatusInfo.Show();
            }
            catch(Exception)
            {
                MessageBox.Show("Попробуйте позже");
            }
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AdminUserMain adminUser = new AdminUserMain();
                adminUser.Show();
            }
            catch(Exception)
            {
                MessageBox.Show("Попробуйте позже");
            }
        }

        private void TimePark_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AdminTimeParking adminTimeParking = new AdminTimeParking();
                adminTimeParking.Show();
            }
            catch(Exception)
            {
                MessageBox.Show("Попробуйте позже");
            }
        }
        public void Showing(string name)
        {
            AdminName.Text = name;
        }
    }
}
