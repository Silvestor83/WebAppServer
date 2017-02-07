using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WebAppServer.Models.Validation
{
	public class NotAdminAttribute : RequiredAttribute
	{
		public NotAdminAttribute()
		{
			ErrorMessage = "Поле должно иметь другое имя.";
		}

		public override bool IsValid(object value)
		{
			if (value.ToString() == "Admin")
			{
				return false;
			}
			return true;
		}
	}
}