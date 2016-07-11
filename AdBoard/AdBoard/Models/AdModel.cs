using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdBoard.Models
{
    public class AdModel
    {
        public int AdTypeId { get; set; }

        public Image[] Images { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        public string Title { get; set; }

        [Required(ErrorMessage = "*")]
        public string Text { get; set; }

        public Ad[] Ads { get; set; }
    }
}