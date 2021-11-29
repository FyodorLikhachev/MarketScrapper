using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FyodorLikhachev.MarketScrapper.NotificationServices;
using HtmlAgilityPack;
using Microsoft.Extensions.Hosting;

namespace FyodorLikhachev.MarketScrapper.Markets
{
	public abstract class MarketScrapperBase : BackgroundService
	{
		protected string BaseUrl { get; init; }
		protected string[] ProductUrls { get; init; }
		protected HtmlDocument Document { get; set; }
		protected HtmlWeb Web { get; }
		private INotificationService NotificationService { get; }

		protected MarketScrapperBase(HtmlWeb web, INotificationService notificationService)
		{
			Web = web;
			NotificationService = notificationService;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{
				await Task.WhenAll(ProductUrls.Select(CheckProductAvailability));
				await Task.Delay(60_000, stoppingToken);
			}
		}

		protected virtual async Task CheckProductAvailability(string productUrl)
		{
			Document = await Web.LoadFromWebAsync(productUrl);

			if (!IsProductAvailable()) return;

			await NotificationService.Notify($"Product is available on {productUrl} at {DateTime.Now}");
		}

		protected string GetProductUrl(string productId) => $"{BaseUrl}{productId}";

		protected abstract bool IsProductAvailable();
	}
}