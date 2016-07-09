using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsuCorpTest.Entities
{
    public class ContactType
    {
        public int Id { get; set; }
        public string ContacTypeName { get; set; }
        public virtual IList<Reservation> Reservations { get; set; }
    }
}