using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme
{
    class scifibook:books
    {
        private static string booktype = "scifi";
        public static String Booktype
        {
            get { return booktype; }
            set { booktype = value; }
        }

    }
}
