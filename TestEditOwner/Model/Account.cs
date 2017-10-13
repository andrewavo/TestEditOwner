using System;
using System.Collections.Generic;

namespace TestEditOwner.Model
{
    public partial class Account
    {
        public Account()
        {
            LegalEntity = new HashSet<LegalEntity>();
            Person = new HashSet<Person>();
        }

        public int AccoutId { get; set; }
        public string Number { get; set; }
        public decimal? Balance { get; set; }

        public ICollection<LegalEntity> LegalEntity { get; set; }
        public ICollection<Person> Person { get; set; }
    }
}
