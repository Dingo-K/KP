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
    /// Логика взаимодействия для AdminUserMain.xaml
    /// </summary>
    public partial class AdminUserMain : Window
    {
        public AdminUserMain()
        {
            InitializeComponent();
        }

        private void Regist_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AdminUser adminUser = new AdminUser();
                adminUser.Show();
                this.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Попробуйте позже");
            }
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AdminUserFind adminUserFind = new AdminUserFind();
                adminUserFind.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Попробуйте позже");
            }
        }
    }
}
