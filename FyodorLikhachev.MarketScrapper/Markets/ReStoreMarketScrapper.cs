using System.Linq;
using FyodorLikhachev.MarketScrapper.NotificationServices;
using HtmlAgilityPack;

namespace FyodorLikhachev.MarketScrapper.Markets
{
	public class ReStoreMarketScrapper : MarketScrapperBase
	{
		public ReStoreMarketScrapper(HtmlWeb web, INotificationService notificationService)
			: base(web, notificationService)
		{
			BaseUrl = "https://re-store.ru/catalog/";
			ProductUrls = new[]
			{
				GetProductUrl("MLW13RU-A"), GetProductUrl("MLW53RU-A"),
				GetProductUrl("MLW43RU-A"), GetProductUrl("MLW83RU-A"),
			};
		}

		protected override bool IsProductAvailable()
		{
			var buyProductNode = Document.DocumentNode.Descendants("button")
				.FirstOrDefault(n => n.HasClass("button-buy") 
									 && n.InnerText.Contains("Добавить в корзину"));

			return buyProductNode != null;
		}
	}
}