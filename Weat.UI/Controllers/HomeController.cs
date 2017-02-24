using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weat.UI.Controllers.Transverse;
using Weat.UI.Models;
using Weat.UI.Models.Transverse;

namespace Weat.UI.Controllers
{
    public partial class HomeController : BaseController
    {
        public virtual ActionResult Index()
        {
            return View();
        }
        public virtual ActionResult Person()
        {
            PersonViewModel model = new PersonViewModel()
            {
                Id = WeatUser.Id,
                FirstName = WeatUser.FirstName,
                LastName = WeatUser.LastName,
                Mail = WeatUser.Mail,
                Password = WeatUser.Password,
                Pseudo = WeatUser.UserName
            };
            return View(MVC.Person.Views.PersonView,model);
        }

        public virtual ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public virtual ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}