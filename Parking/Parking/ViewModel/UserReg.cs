using DevExpress.Mvvm;
using Parking.Admin;
using Parking.DataBase;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Parking.ViewModel
{
    class UserReg : ViewModelBase
    {
        private string firstname;
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value.Trim();
                RaisePropertiesChanged("Firstname");
            }
        }
        private string secondname;
        public string Secondname
        {
            get
            {
                return secondname;
            }
            set
            {
                secondname = value.Trim();
                RaisePropertiesChanged("Secondname");
            }
        }
        private string mobile;
        public string Mobile
        {
            get
            {
                return mobile;
            }
            set
            {
                mobile = value.Trim();
                RaisePropertiesChanged("Mobile");
            }
        }
        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value.Trim();
                RaisePropertiesChanged("Email");
            }
        }
        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value.Trim();
                RaisePropertiesChanged("Password");
            }
        }
        private string passwordAgn;
        public string PasswordAgn
        {
            get
            {
                return passwordAgn;
            }
            set
            {
                passwordAgn = value.Trim();
                RaisePropertiesChanged("PasswordAgn");
            }
        }
        private string emailforEnter;
        public string EmailforEnter
        {
            get
            {
                return emailforEnter;
            }
            set
            {
                emailforEnter = value.Trim();
                RaisePropertiesChanged("EmailforEnter");
            }
        }
        private string passwordforEnter;
        public string PasswrdforEnter
        {
            get
            {
                return passwordforEnter;
            }
            set
            {
                passwordforEnter = value.Trim();
            }
        }
        public void Enter()
        {
            using(KPContext kp = new KPContext())
            {
                var forenter = kp.Database.SqlQuery<Users>($"select * from Users where Users.email = '{emailforEnter}'");
                foreach(var check in forenter)
                {
                    if(check.email == emailforEnter && check.password == PasswrdforEnter && check.Admin == true)
                    {
                        MainAdmin mainAdmin = new MainAdmin();
                        mainAdmin.Show();
                        foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
                        {
                            if (window.DataContext == this)
                            {
                                window.Close();
                            }

                        }
                    }
                    if (check.email == emailforEnter && check.password == GetHashPassword(PasswrdforEnter) && check.Admin == false)
                    {
                        MainWindow main = new MainWindow();
                        main.UserInfo(check.UserId, check.Firstname, check.Secondname, check.email, check.Mobile);
                        main.Show();
                        foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
                        {
                            if (window.DataContext == this)
                            {
                                window.Close();
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Проверьте email или пароль");
                    }
                }
                
            }
        }
        public void Regist()
        {
            if (ValidReg() == true)
            {
                using (KPContext kp = new KPContext())
                {

                    Users user = new Users()
                    {
                        Secondname = secondname,
                        Firstname = firstname,
                        email = _email,
                        Mobile = mobile,
                        password = GetHashPassword(_password),
                        Admin = false
                    };
                    kp.Users.Add(user);
                    kp.SaveChanges();
                }
                MainWindow main = new MainWindow();
                main.Show();
                foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
                {
                    if (window.DataContext == this)
                    {
                        window.Close();
                    }
                }
            }
        }
        public ICommand regist => new DelegateCommand(Regist);
        public ICommand enter => new DelegateCommand(Enter);

        public bool ValidReg()
        {
            try
            {
                char[] Firstnamech = firstname.ToCharArray();
                char[] Secondnamech = secondname.ToCharArray();
                string regular_mobile = "[+]{1}[0-9]{12}";
                string regular_email = "[@]{1}";
            
                if (Regex.IsMatch(_email, regular_email) == false || _email.Length > 100 || _email.Length < 1)
                {
                    throw new Exception("Email введен не корректно");
                }
                if (Regex.IsMatch(mobile, regular_mobile, RegexOptions.IgnoreCase) == false)
                {
                    throw new Exception("Номер телефона введен не корректно");
                }
                foreach (char i in Firstnamech)
                {
                    if (char.IsLetter(i) == false || Firstnamech.Length > 50 || Firstnamech.Length < 1)
                    {
                        throw new Exception("Имя введено не корректно");
                    }
                }
                foreach (char i in Secondnamech)
                {
                    if (char.IsLetter(i) == false || Secondnamech.Length > 50 || Secondnamech.Length < 1)
                    {
                        throw new Exception("Фамилия введена не корректно");
                    }
                }
                if(_password != passwordAgn)
                {
                    throw new Exception("Пароль не совпадает");
                }
                if(_password.Length > 50 || _password.Length < 6)
                {
                    throw new Exception("Пароль введен не корректно");
                }
                
                using (KPContext kp = new KPContext())
                {

                    var users1 = kp.Database.SqlQuery<Users>($"select * from Users where Users.Mobile = '{mobile}'");
                    foreach (var usercheck in users1)
                    {
                        if (usercheck.Mobile != null)
                        {
                            MessageBox.Show("Телефон с таким номером уже зарегестрирован");
                            return false;
                        }
                    }
                    users1 = kp.Database.SqlQuery<Users>($"select * from Users where Users.email = '{_email}'");
                    foreach (var usercheck in users1)
                    {
                        if (usercheck.email != null)
                        {
                            MessageBox.Show("Такая почта уже зарегестрирована");
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                if(ex.Message == "Ссылка на объект не указывает на экземпляр объекта.")
                {
                    MessageBox.Show("Проверьте корректность введенных данных");
                    return false;
                }
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private string GetHashPassword(string s)
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
