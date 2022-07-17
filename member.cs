using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme
{
    class member:person
    {
        private static int memberrole = 2;

        public static int Memberrole
        {
            get { return memberrole; }
            set { memberrole = value; }
        }
    }
}
