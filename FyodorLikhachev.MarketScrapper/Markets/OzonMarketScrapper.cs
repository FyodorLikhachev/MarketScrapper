using System.Linq;
using FyodorLikhachev.MarketScrapper.NotificationServices;
using HtmlAgilityPack;

namespace FyodorLikhachev.MarketScrapper.Markets
{
	public class OzonMarketScrapper : MarketScrapperBase
	{
		public OzonMarketScrapper(HtmlWeb web, INotificationService notificationService) 
			: base(web, notificationService)
		{
			BaseUrl = "https://www.ozon.ru/product/";
			ProductUrls = new[]
			{
				GetProductUrl("315311014"), GetProductUrl("315311017"),
				GetProductUrl("315311018"), GetProductUrl("315311021"),
			};
		}

		protected override bool IsProductAvailable()
		{
			var buyProductNode = Document.DocumentNode.Descendants("span")
				.FirstOrDefault(n => n.HasClass("ui-e6")
					&& n.InnerText.Contains("Добавить в корзину"));

			return buyProductNode != null;
		}
	}
}