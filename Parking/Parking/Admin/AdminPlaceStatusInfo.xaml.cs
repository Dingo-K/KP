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
    /// Логика взаимодействия для AdminPlaceStatusInfo.xaml
    /// </summary>
    public partial class AdminPlaceStatusInfo : Window
    {
        private ObservableCollection<Place> alls;
        public AdminPlaceStatusInfo()
        {
            InitializeComponent();
        }
        public void Showing(string place)
        {
            using(KPContext kP = new KPContext())
            {
                alls = new ObservableCollection<Place>();
                var place_info = kP.Place.ToList();
                foreach(var i in place_info)
                {
                    if(i.Sector == place)
                    {
                        alls.Add(i);
                    }
                }
                ListPlace.ItemsSource = alls;
            }
        }
    }
}
