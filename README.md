# MarketScrapper

Service for monitoring product availability in different e-shops. Currently supported `Ozon`, `ReStore`, `Svyznoy`.

## Notifications

Service can report the available product to the console or to the `Telegram`.

To use telegram you need to specify 2 environment variables:

1. TELEGRAM_BOT_TOKEN = your bot's token in telegram
2. TELEGRAM_BOT_CHAT_ID = the active chat with your bot you want to report to

## TODO

1. Products list configuration
2. Interval configuration
3. User-friendly notifications system configuration
