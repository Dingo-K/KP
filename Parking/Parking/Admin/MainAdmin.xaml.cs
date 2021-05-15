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
            AdminReview adminReview = new AdminReview();
            adminReview.Show();
            
        }

        private void Place_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            AdminUserMain adminUser = new AdminUserMain();
            adminUser.Show();
        }
    }
}
