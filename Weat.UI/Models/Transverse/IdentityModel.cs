using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weat.UI.Models.Transverse
{
    public class WeatUser : IUser<int>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string PreferredLanguageCode { get; set; }
        public string CivilityId { get; set; }
        public bool IsActive { get; set; }
        public bool IsBlocked { get; set; }
        public int ActivationCode { get; set; }

    }
}