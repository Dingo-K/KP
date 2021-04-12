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
        }
        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            using (KPContext kP = new KPContext())
            {
                var users = kP.Users.ToList();
                foreach (var u in users)
                {
                    if (EmailFE.Text == u.email && GetHashString(PasswordFE.Password.ToString().Trim()) == u.password)
                    {
                        MessageBox.Show("EnterSuccses");
                        //this.Close();
                    }
                }
            }
        }
        private void ButtonRegistr_Click(object sender, RoutedEventArgs e) // Регистрация
        {
            char[] Firstnamech = FirstnameB.Text.ToCharArray();
            char[] Secondnamech = SecondnameB.Text.ToCharArray();
            string regular_mobile = "[+]{1}[0-9]{12}";
            string regular_email = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            using (KPContext kP = new KPContext())
            {
                try
                {
                    if (Regex.IsMatch(EmailB.Text, regular_email, RegexOptions.IgnoreCase) == false || EmailB.Text.Length > 100)
                    {
                        throw new Exception("Email введен не корректно");
                    }
                    foreach (char i in Firstnamech)
                    {
                        if (char.IsLetter(i) == false || Firstnamech.Length > 50)
                        {
                            throw new Exception("Имя введено не корректно");
                        }
                    }
                    foreach (char i in Secondnamech)
                    {
                        if (char.IsLetter(i) == false || Secondnamech.Length > 50)
                        {
                            throw new Exception("Фамилия введена не корректно");
                        }
                    }
                    if (Regex.IsMatch(TelephoneB.Text, regular_mobile, RegexOptions.IgnoreCase) == false)
                    {
                        throw new Exception("Номер телефона введен не корректно");
                    }
                    if (PasswordB.Password.ToString() != PasswordAgain.Password.ToString() || PasswordB.Password.Length > 50)
                    {
                        throw new Exception("Пароль не совпадает");
                    }
                    if (PasswordB.Password.Length > 50)
                    {
                        throw new Exception("Пароль введен не корректно");
                    }
                    Users user = new Users()
                    {
                        email = EmailB.Text,
                        Secondname = SecondnameB.Text,
                        Firstname = FirstnameB.Text,
                        Mobile = TelephoneB.Text,
                        password = GetHashString(PasswordB.Password.ToString().Trim()),
                        Admin = false
                    };
                    var users = kP.Users.ToList();
                    foreach (var u in users)
                    {
                        if(u.Mobile == user.Mobile)
                        {
                            throw new Exception("Данный мобильный телефон уже зарегестрирован");
                        }
                        if(u.email == user.email)
                        {
                            throw new Exception("Данный почта уже зарегестрирована");
                        }
                    }
                    kP.Users.Add(user);
                    kP.SaveChanges();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private string GetHashString(string s)
        {
            //переводим строку в байт-массим  
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            //создаем объект для получения средст шифрования  
            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();
            //вычисляем хеш-представление в байтах  
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = string.Empty;
            //формируем одну цельную строку из массива  
            foreach (byte b in byteHash)
            {
                hash += string.Format("{0:x2}", b);
            }
            return hash;
        }
        
    }
}
