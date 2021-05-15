using Parking.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
using System.Windows.Shapes;

namespace Parking.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminUserFind.xaml
    /// </summary>
    public partial class AdminUserFind : Window
    {
        public AdminUserFind()
        {
            InitializeComponent();
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            using(KPContext kP = new KPContext())
            {
                ObservableCollection<Users> collect = new ObservableCollection<Users>();
                string regularfname = $"{Fname.Text}";
                var userinfo = kP.Users.ToList();
                foreach(var i in userinfo)
                {
                    if (Regex.IsMatch(i.email, regularfname))
                    {
                        collect.Add(i);
                    }
                }
                AdminUserFindResult adminUserFindResult = new AdminUserFindResult();
                adminUserFindResult.Showing(collect);
                adminUserFindResult.Show();
                this.Close();
            }
        }
    }
}
