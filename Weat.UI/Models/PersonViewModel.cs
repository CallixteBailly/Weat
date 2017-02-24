using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Weat.UI.Models
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Prenom")]
        public string FirstName { get; set; }
        [Display(Name = "Nom")]
        public string LastName { get; set; }
        [Display(Name = "Pseudo")]
        public string Pseudo { get; set; }
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }
        [Display(Name = "Mail")]
        public string  Mail { get; set; }
    }
}