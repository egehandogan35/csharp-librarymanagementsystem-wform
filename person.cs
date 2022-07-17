using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme
{
    public  class person
    {
        private static int memberrole;
        private static String username;
        private static int penalty = 0;
        private static int  Id;
        private static string  password;


        public static int Memberrole
        {
            get { return memberrole; }
            set { memberrole = value; }
        }

        public static int id
        {
            get { return Id; }
            set { Id = value; }
        }
        public static int Penalty
        {
            get { return penalty; }
            set { penalty = value; }
        }

        public static String Username
        {
            get { return username; }
            set { username = value; }
        }

        public static String Password
        {
            get { return password; }
            set { password = value; }
        }
       


    }
}
