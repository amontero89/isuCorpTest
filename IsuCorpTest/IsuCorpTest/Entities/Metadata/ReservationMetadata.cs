using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using IsuCorpTest.Resources;

namespace IsuCorpTest.Entities.Metadata
{
    public class ReservationMetadata
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ATTRIBUTE_REQUIRED")]
        [StringLength(160)]
        public string ContactName { get; set; }

        [Required]
        public int ContactTypeId { get; set; }

        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ATTRIBUTE_REQUIRED")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }

        [Range(1, 5)]
        public int Ranking { get; set; }

        public bool isFavorite { get; set; }

        [AllowHtml]
        public string BodyText { get; set; }
    }
}