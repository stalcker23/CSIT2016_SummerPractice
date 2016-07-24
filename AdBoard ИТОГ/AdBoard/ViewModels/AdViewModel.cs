using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdBoard.ViewModels
{
    public class AdViewModel
    {
        public int AdTypeId { get; set; }

        public Image[] Images { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        public string Title { get; set; }

        [Required(ErrorMessage = "*")]
        public string Text { get; set; }

        public string Owner { get; set; }
        public Ad[] Ads { get; set; }
    }
}