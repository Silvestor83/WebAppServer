using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace WebAppServer.Controllers
{
	public class ApplicationController : Controller
	{
		private ApplicationUserManager _userManager;
		private NetworkStream stream;
		private TcpListener tcpListener;
		private string id;
		private int fileCount;
		private int maxFileCount = 1000;


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

		// GET: Application
		public async Task<ActionResult> LaunchTcpServer(string Login, string Password)
		{
			var user = await UserManager.FindAsync(Login, Password);
			if (user == null)
			{
				return new HttpUnauthorizedResult();
			}
			id = user.Id;
			if (!Directory.Exists(Server.MapPath(@"~/Images/" + id)))
			{
				Directory.CreateDirectory(Server.MapPath(@"~/Images/" + id));
			}
			fileCount = Directory.GetFiles(Server.MapPath(@"~/Images/" + id)).Length;

			Random random = new Random();
			int port = random.Next(49152, 65535);

			if (!await ServerLaunched(port))
			{
				return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
			}

			HttpContext.Response.Headers.Add("PortNumber", port.ToString());
			return new EmptyResult();
		}

		/// <summary>
		/// Метод для запуска Tcp сервера и возврата bool как результата запуска
		/// </summary>
		private async Task<bool> ServerLaunched(int port)
		{
			try
			{
				tcpListener = new TcpListener(IPAddress.Any, port);
				tcpListener.Start();
			}
			catch (Exception)
			{
				return false;
			}

			Task.Run((Action)GetImage);
			return true;
		}

		/// <summary>
		/// Метод для запуска цикла по приему массива байт от клиента, с целью последующей трансформации
		/// его в файл изображения
		/// </summary>
		private async void GetImage()
		{
			TcpClient client = null;
			string date = DateTime.Now.ToString("yyyy-MM-dd  HH-mm-ss", CultureInfo.InvariantCulture);
			int lengthDateInBytes = Encoding.Unicode.GetBytes(date).Length;

			DateTime starTime = DateTime.Now;

			try
			{
				// Ожидание получения данных от клиента, если нет в течении 60 сек, то выброс исключения,
				// с последующим очищением TcpListener
				while (!tcpListener.Pending())
				{
					await Task.Delay(100);
					if (DateTime.Now - starTime > TimeSpan.FromSeconds(60))
					{
						throw new Exception("Время ожидания, получения данных от клиента, истекло.");
					}
				}

				client = await tcpListener.AcceptTcpClientAsync();
				stream = client.GetStream();
				// Установка таймаута 60 сек. Если за это время от клиента в поток не поступит данных,
				// то Tcp сервер приостанавливает работу.
				stream.ReadTimeout = 60000;

				while (true)
				{
					BinaryReader reader = new BinaryReader(stream);
					byte[] lengthInBytes = reader.ReadBytes(4);

					int length = BitConverter.ToInt32(lengthInBytes, 0);
					byte[] arr = reader.ReadBytes(length);
					SaveImageFromBytes(arr, lengthDateInBytes);
				}
			}
			catch (Exception e)
			{

			}
			finally
			{
				if (client != null)
				{
					client.Close();
				}
				tcpListener.Stop();
			}
		}

		/// <summary>
		/// Метод для трансформации массива байт в изображение и сохранением его в папку пользователя
		/// </summary>
		/// <param name="lengthDateInBytes">Длина даты в байтах с начала исходного массива, после которых записаны
		/// данные изображения</param>
		private void SaveImageFromBytes(byte[] arr, int lengthDateInBytes)
		{
			byte[] dateArr = new byte[lengthDateInBytes];
			byte[] imageArr = new byte[arr.Length - lengthDateInBytes];

			for (int i = 0; i < arr.Length - lengthDateInBytes; i++)
			{
				if (i < lengthDateInBytes)
				{
					dateArr[i] = arr[i];
				}
				else
				{
					imageArr[i - lengthDateInBytes] = arr[i];
				}
			}

			string date = Encoding.Unicode.GetString(dateArr);

			if (fileCount >= maxFileCount) CleanSpace();
			System.IO.File.WriteAllBytes(Server.MapPath(@"~/Images/" + id + "/" + date + ".jpeg"), imageArr);
			fileCount++;
		}


		/// <summary>
		/// Метод очитки директории от старых файлов при заполнении предельного размера 
		/// на величину (Предельный размер / 3)
		/// </summary>
		private void CleanSpace()
		{
			DirectoryInfo dir = new DirectoryInfo(Server.MapPath(@"~/Images/" + id));
			var files = dir.GetFiles();
			for (int i = 0; i < maxFileCount / 3; i++)
			{
				files[i].Delete();
			}
		}
	}
}