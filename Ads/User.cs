using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads
{
    internal class User
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public bool IsPremiun { get; set; }

        public User(string login, string name, bool premium) 
        {
            Login = login;
            Name = name;
            IsPremiun = premium;
        }
    }
}
