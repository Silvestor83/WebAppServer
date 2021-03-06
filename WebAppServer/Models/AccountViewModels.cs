﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebAppServer.Models.Validation;

namespace WebAppServer.Models
{
	public class ExternalLoginConfirmationViewModel
	{
		[Required]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}

	public class ExternalLoginListViewModel
	{
		public string ReturnUrl { get; set; }
	}

	public class SendCodeViewModel
	{
		public string SelectedProvider { get; set; }
		public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
		public string ReturnUrl { get; set; }
		public bool RememberMe { get; set; }
	}

	public class VerifyCodeViewModel
	{
		[Required]
		public string Provider { get; set; }

		[Required]
		[Display(Name = "Code")]
		public string Code { get; set; }
		public string ReturnUrl { get; set; }

		[Display(Name = "Remember this browser?")]
		public bool RememberBrowser { get; set; }

		public bool RememberMe { get; set; }
	}

	public class ForgotViewModel
	{
		[Required(ErrorMessage = "Поле не должно быть пустым.")]
		[EmailAddress(ErrorMessage = "Поле не содержит допустимый адрес электронной почты.")]
		[Display(Name = "Эл. почта")]
		public string Email { get; set; }
	}

	public class LoginViewModel
	{
		[Required(ErrorMessage = "Поле не должно быть пустым.")]
		[Display(Name = "Имя")]
		public string Login { get; set; }

		[Required(ErrorMessage = "Поле не должно быть пустым.")]
		[DataType(DataType.Password)]
		[Display(Name = "Пароль")]
		public string Password { get; set; }

		[Display(Name = "Запомнить на этом компьютере?")]
		public bool RememberMe { get; set; }
	}

	public class RegisterViewModel
	{
		[Required(ErrorMessage = "Поле не должно быть пустым.")]
		[NotAdmin]
		[MinLength(3, ErrorMessage = "Длина должна быть более 3 символов.")]
		[MaxLength(50, ErrorMessage = "Длина должна быть менее 50 символов.")]
		[RegularExpression(@"[a-zA-Z0-9@_\.]*", ErrorMessage = "Недопустимые символы в имени.")]
		[Display(Name = "Имя")]
		[Remote("ValidateUser", "Account", ErrorMessage = "Данное имя уже занято.")]
		public string Login { get; set; }

		[Required(ErrorMessage = "Поле не должно быть пустым.")]
		[EmailAddress(ErrorMessage = "Поле не содержит допустимый адрес электронной почты.")]
		[Display(Name = "Эл. почта")]
		[Remote("ValidateEmail", "Account", ErrorMessage = "Данный адрес уже используется.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Поле не должно быть пустым.")]
		[StringLength(100, ErrorMessage = "{0} должен быть не менее {2} символов.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Пароль")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Подтвердить пароль")]
		[System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Пароль и подтверждение пароля должны совпадать.")]
		public string ConfirmPassword { get; set; }
	}

	public class ResetPasswordViewModel
	{
		[Required(ErrorMessage = "Поле должно быть заполнено.")]
		[Display(Name = "Имя")]
		public string Login { get; set; }

		[Required(ErrorMessage = "Поле не должно быть пустым.")]
		[StringLength(100, ErrorMessage = "{0} должен быть не менее {2} символов.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Пароль")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Подтвердить пароль")]
		[System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Пароль и подтверждение пароля должны совпадать.")]
		public string ConfirmPassword { get; set; }

		public string Code { get; set; }
	}

	public class ForgotPasswordViewModel
	{
		[Required]
		[EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}
}
