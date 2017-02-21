using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace WebAppServer.Controllers
{



	public class HomeController : Controller
	{
		public HomeController()
		{
			
		}
		private ApplicationUserManager _userManager;

		public ApplicationUserManager UserManager
		{
			get
			{
				return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
			}
			private set
			{
				_userManager = value;
			}
		}

		public ActionResult Index()
		{
			Console.WriteLine();
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Download()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Data()
		{
			ViewBag.Message = "Your application description page.";
			var name = HttpContext.User.Identity.Name;

			var user = UserManager.FindByName(name);
			if (user != null)
			{
				
			}
			ViewBag.Test = name;

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}