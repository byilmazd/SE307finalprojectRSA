using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SE307finalprojectRSA
{
    class Member
    {
        public String name;
        public String surname;
        public String address;
        public String phoneNumber;
        public Member(String n, String s, String a, String p)
        {
            name = n;
            surname = s;
            address = a;
            phoneNumber = p;
        }
    }
}
