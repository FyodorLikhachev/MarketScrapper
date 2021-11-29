using System;
using System.Threading.Tasks;

namespace FyodorLikhachev.MarketScrapper.NotificationServices
{
	public class ConsoleNotificationService : INotificationService
	{
		public Task Notify(string message)
		{
			Console.WriteLine(message);
			return Task.CompletedTask;
		}
	}
}