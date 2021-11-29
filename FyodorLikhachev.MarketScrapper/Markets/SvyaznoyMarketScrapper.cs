using System.Linq;
using FyodorLikhachev.MarketScrapper.NotificationServices;
using HtmlAgilityPack;

namespace FyodorLikhachev.MarketScrapper.Markets
{
	public class SvyaznoyMarketScrapper : MarketScrapperBase
	{
		public SvyaznoyMarketScrapper(HtmlWeb web, INotificationService notificationService)
			: base(web, notificationService)
		{
			BaseUrl = "https://www.svyaznoy.ru/catalog/phone/224/";
			ProductUrls = new[]
			{
				GetProductUrl("6270627"), GetProductUrl("6270587"),
				GetProductUrl("6270599"), GetProductUrl("6270631"),
				GetProductUrl("6270331"),
			};
		}

		protected override bool IsProductAvailable()
		{
			var buyProductNode = Document.DocumentNode.Descendants("a")
				.FirstOrDefault(n => n.HasClass("b-main-btn__text")
									&& n.InnerText.Contains("Купить"));

			return buyProductNode != null;
		}
	}
}