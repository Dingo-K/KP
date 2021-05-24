using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Singleton
{
    class MainUserInfo
    {
        public Info info { get; set; }
        public void Show(string id, string firstname, string secondname, string email, string phone)
        {
            info = Info.Getinstance(id,firstname,secondname,email,phone);
        }
    }
    class Info
    {
        public string UserId { get; private set; }
        public string Firstname { get; private set; }
        public string Secondname { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public static Info instance;
        protected Info(string id,string firstname,string secondname,string email,string phone)
        {
            UserId = id;
            Firstname = firstname;
            Secondname = secondname;
            Email = email;
            Phone = phone;
        }
        public static Info Getinstance(string id, string firstname, string secondname, string email, string phone)
        {
            if(instance == null)
            {
                instance = new Info(id, firstname, secondname, email, phone);
            }
            return instance;
        }
    }
}
