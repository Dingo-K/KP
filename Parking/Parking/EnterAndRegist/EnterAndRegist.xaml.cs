using Parking.DataBase;
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
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Parking.ViewModel;

namespace Parking.EnterAndRegist
{
    /// <summary>
    /// Логика взаимодействия для EnterAndRegist.xaml
    /// </summary>
    public partial class EnterAndRegist : Window
    {
        public EnterAndRegist()
        {
            InitializeComponent();
            DataContext = new UserReg();
        }
        
    }
}
