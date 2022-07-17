using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme
{
    class rentbooks
    {
        private static int Id;
        private static String bookname;
        private static DateTime bookin;
        private static DateTime bookout;
        private static DateTime bookreturn;
        private static string username;

        public static DateTime Bookin
        {
            get { return bookin; }
            set { bookin = value; }
        }
        public static DateTime Bookout
        {
            get { return bookout; }
            set { bookout = value; }
        }

        public static DateTime Bookreturn
        {
            get { return bookreturn; }
            set { bookreturn = value; }
        }


        public static int id
        {
            get { return Id; }
            set { Id = value; }
        }

        public static String Bookname
        {
            get { return bookname; }
            set { bookname = value; }
        }

        public static String Username
        {
            get { return username; }
            set { username = value; }
        }
        

    
}

}
