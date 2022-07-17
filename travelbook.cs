using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme
{
    class travelbook:books
    {

        private static string booktype = "travel";
        public static String Booktype
        {
            get { return booktype; }
            set { booktype = value; }
        }
    }
}
