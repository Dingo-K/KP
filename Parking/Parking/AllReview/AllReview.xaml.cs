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

namespace Parking.AllReview
{
    /// <summary>
    /// Логика взаимодействия для AllReview.xaml
    /// </summary>
    public partial class AllReview : Window
    {
        private ObservableCollection<AllRev> alls;
        public AllReview()
        {
            InitializeComponent();
        }
        public void Showing()
        {
            try
            {
                using (KPContext kp = new KPContext())
                {

                    var revs = kp.Review.ToList();
                    alls = new ObservableCollection<AllRev>();
                    foreach (var i in revs)
                    {
                        AllRev allRev = new AllRev();
                        allRev.Add(i.Users.Firstname, i.TimeRev.ToString(), i.Review1);
                        alls.Add(allRev);
                    }
                    ListReview.ItemsSource = alls;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Попробуйте позже");
            }
        }
    }
}
