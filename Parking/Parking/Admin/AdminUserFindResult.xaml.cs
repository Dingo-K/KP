using Parking.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для AdminUserFindResult.xaml
    /// </summary>
    public partial class AdminUserFindResult : Window
    {
        public AdminUserFindResult()
        {
            InitializeComponent();
        }
        public void Showing(ObservableCollection<Users> collect)
        {
            ListUser.ItemsSource = collect;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
           using(KPContext kP = new KPContext())
            {
                Users users = new Users();
                users = (Users)ListUser.SelectedItem;
                int numbofdelete = kP.Database.ExecuteSqlCommand($"delete from Users where Users.UserId = {users.UserId}");
                int revofdelete = kP.Database.ExecuteSqlCommand($"delete from Review where UserId = {users.UserId}");
                MessageBox.Show("Пользователь успешно удален");
                this.Close();
            } 
        }
    }
}
