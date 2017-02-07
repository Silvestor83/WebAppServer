using System.Web;
using System.Web.Mvc;
using WebAppServer.Filters;

namespace WebAppServer
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
