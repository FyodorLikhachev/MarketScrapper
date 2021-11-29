using System;
using System.Threading.Tasks;
using FyodorLikhachev.MarketScrapper.NotificationServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FyodorLikhachev.MarketScrapper
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			try
			{
				await CreateHostBuilder(args).Build().RunAsync();
			}
			catch (ArgumentException aex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(aex.Message);
				Console.ForegroundColor = ConsoleColor.Gray;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Unhandled exception has occured\n{ex}");
			}
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureServices((_, services) =>
				{
					services.AddSingleton<INotificationService, TelegramNotificationService>();
					services.AddPlainMarketScrappers();
				});
	}
}