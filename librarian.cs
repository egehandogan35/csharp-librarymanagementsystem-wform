using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme
{
    public  class librarian:person
    {
        private static int memberrole = 1;

        public static int Memberrole
        {
            get { return memberrole; }
            set { memberrole = value; }
        }
    }
}
