using System.Threading.Tasks;
using Telegram.Bot;

namespace FyodorLikhachev.MarketScrapper.NotificationServices
{
	public class TelegramNotificationService : INotificationService
	{
		private TelegramBotClient BotClient { get; }
		private string Token { get; }
		private long ChatId { get; }

		public TelegramNotificationService()
		{
			Token = EnvUtils.GetStringEnv("TELEGRAM_BOT_TOKEN");
			ChatId = EnvUtils.GetLongEnv("TELEGRAM_BOT_CHAT_ID");
			BotClient = new TelegramBotClient(Token);
		}

		public async Task Notify(string message)
			=> await BotClient.SendTextMessageAsync(ChatId, message);
	}
}