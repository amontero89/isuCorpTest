using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsuCorpTest.Entities
{
    public partial class Reservation
    {
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BodyText { get; set; }
        public int? Ranking { get; set; }
        public bool? isFavorite { get; set; }
        public int ContactTypeId { get; set; }
        public virtual ContactType ContactType { get; set; }
    }
}