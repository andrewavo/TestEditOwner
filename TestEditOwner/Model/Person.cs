using System;
using System.Collections.Generic;

namespace TestEditOwner.Model
{
    public partial class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime? BirthDay { get; set; }
        public int? AccountId { get; set; }

        public Account Account { get; set; }
    }
}
