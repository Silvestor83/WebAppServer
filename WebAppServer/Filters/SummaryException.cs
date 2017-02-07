using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace WebAppServer.Filters
{
	public class SummaryException : FilterAttribute, IExceptionFilter
	{
		public void OnException(ExceptionContext exceptionContext)
		{
			if (!exceptionContext.ExceptionHandled && exceptionContext.Exception is SmtpFailedRecipientException)
			{
				exceptionContext.Result = new JavaScriptResult{Script = "window.location = 'http://localhost:4602/Home/About'"}; ;
				exceptionContext.ExceptionHandled = true;
			}
		}
	}
}