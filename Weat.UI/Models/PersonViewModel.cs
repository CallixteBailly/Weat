using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Weat.Constant;

namespace Weat.UI.Models
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        [Display(ResourceType = typeof(WeatResource), Name = "Weat_Person_FirsName")]
        public string FirstName { get; set; }
        [Display(ResourceType = typeof(WeatResource), Name = "Weat_Person_LastName")]
        public string LastName { get; set; }
        [Display(ResourceType = typeof(WeatResource), Name = "Weat_Person_UserName")]
        public string Pseudo { get; set; }
        [Display(ResourceType = typeof(WeatResource), Name = "Weat_Person_Password")]
        public string Password { get; set; }
        [Display(ResourceType = typeof(WeatResource), Name = "Weat_Person_Mail")]
        public string  Mail { get; set; }
    }
}