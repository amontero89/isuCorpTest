using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IsuCorpTest.Entities.Metadata
{
    public class ReservationMetadata
    {
        [Required]
        [StringLength(160)]
        public string ContactName { get; set; }

        [Required]
        public int ContactTypeId { get; set; }

        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Range(1, 5)]
        public int Ranking { get; set; }

        public bool isFavorite { get; set; }

        public string BodyText { get; set; }
    }
}