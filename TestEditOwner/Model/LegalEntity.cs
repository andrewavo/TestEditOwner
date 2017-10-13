using System;
using System.Collections.Generic;

namespace TestEditOwner.Model
{
    public partial class LegalEntity
    {
        public int LegalEntityId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? AccountId { get; set; }

        public Account Account { get; set; }
    }
}
