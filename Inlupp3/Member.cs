using System;
using System.Collections.Generic;
using System.Text;

namespace Inlupp3
{
    class Member
    {
        public long PersonNummer { get; private set; }

        public string LastName { get; private set; }

        public string FirstName { get; private set; }

        public bool HasPaidMembershipDues { get; private set; }

        public Member(long personNumber, string lastName, string firstName, bool hasPaidMembershipDues)
        {
            PersonNummer = personNumber;
            LastName = lastName;
            FirstName = firstName;
            HasPaidMembershipDues = hasPaidMembershipDues;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}, {2}, {3} ", FirstName, LastName, PersonNummer,
                HasPaidMembershipDues ? "Har betalat medlemsavgift" : "Har inte betalat avgift");


        }
    }
}
