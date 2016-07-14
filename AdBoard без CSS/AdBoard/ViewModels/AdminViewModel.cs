using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdBoard.ViewModels
{
    public class AdminViewModel
    {
        public List<User> Users = new List<User>();
        public Ad[] Ads { get; set; }
    }
}