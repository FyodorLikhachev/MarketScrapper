using System.Threading.Tasks;

namespace FyodorLikhachev.MarketScrapper.NotificationServices
{
	public interface INotificationService
	{
		public Task Notify(string message);
	}
}