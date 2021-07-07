
namespace Monitor.Infrastructure.Settings
{
    public class TelegramNotificationSettings
    {
        public string BotName { get; set; }
        public string BotKey { get; set; }
        public string SendMessageEndpoint { get; set; }
        public string ChatId { get; set; }
        public string SeoWorkerBotName { get; set; }
        public string SeoWorkerChatId { get; set; }
        public string MdpChatId { get; set; }
    }
}
