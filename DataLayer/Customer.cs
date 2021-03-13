using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DataLayer
{
    public partial class Customer
    {
        public Customer()
        {
            Addresses = new HashSet<Address>();
        }
        [Key]
        public int CustomerId { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
