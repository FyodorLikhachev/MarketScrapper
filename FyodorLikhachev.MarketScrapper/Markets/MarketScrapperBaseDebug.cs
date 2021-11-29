using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using FyodorLikhachev.MarketScrapper.NotificationServices;
using HtmlAgilityPack;

namespace FyodorLikhachev.MarketScrapper.Markets
{
	public abstract class MarketScrapperBaseDebug : MarketScrapperBase
	{
		private Process CurrentProcess { get; }
		
		protected MarketScrapperBaseDebug(HtmlWeb web, INotificationService notificationService)
			: base(web, notificationService)
		{
			CurrentProcess = Process.GetCurrentProcess();
		}
		
		protected override async Task CheckProductAvailability(string productUrl)
		{
			Console.WriteLine($"Starting scrapping for {productUrl}. " +
			                  $"Thread#{Thread.CurrentThread.ManagedThreadId} of {CurrentProcess.Threads.Count}");
			var stopwatch = Stopwatch.StartNew();
			Document = await Web.LoadFromWebAsync(productUrl);
			
			var loadTime = stopwatch.ElapsedMilliseconds;
			var isAvailable = IsProductAvailable();

			Console.WriteLine($"Is product available at {productUrl}: {isAvailable}. " +
			                  $"Loaded document in {loadTime} ms. " +
			                  $"Check passed in {stopwatch.ElapsedMilliseconds - loadTime} ms. " +
			                  $"Thread#{Thread.CurrentThread.ManagedThreadId} of {CurrentProcess.Threads.Count}. " +
			                  $"GC: {GC.GetTotalMemory(false) / (1024*1024)} MB");

			if (!isAvailable) return;

			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"Product is available on {productUrl} at {DateTime.Now}");
			Console.ForegroundColor = ConsoleColor.Black;
			
			while (!Console.KeyAvailable)
			{
				Console.Beep();
				await Task.Delay(1_000);
			}
		}
	}
}