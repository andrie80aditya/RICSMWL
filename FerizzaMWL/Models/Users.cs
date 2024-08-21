using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FerizzaMWL.Models
{
    public partial class Users
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime? Expires { get; set; }
        public bool UseCardReader { get; set; }
        public string FriendlyName { get; set; }
        public string UserType { get; set; }
        public string ExtendedName { get; set; }
    }

    public partial class Radiologyst
    {
        [Key]
        public string UserName { get; set; }
        public string RadiologystName { get; set; }
    }
}
