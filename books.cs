using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme
{
    class books
    {
        private static string bookname;
        private static string bookauthor;
        private static DateTime publishdate;
        private static int Id;

        public static String Bookname
        {
            get { return bookname; }
            set { bookname = value; }
        }
        public static String Bookauthor
        {
            get { return bookauthor; }
            set { bookauthor = value; }
        }
        public static int id
        {
            get { return Id; }
            set { Id = value; }
        }
        public static DateTime Publishdate
        {
            get { return publishdate; }
            set { publishdate = value; }
        }

    }
}
