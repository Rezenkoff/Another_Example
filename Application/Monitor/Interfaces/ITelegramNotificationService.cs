using System.Threading.Tasks;

namespace Monitor.Application.Interfaces
{
    public interface ITelegramNotificationService : INotificationsService
    {
        Task SendMessageFromSeoWorker(string text);
        Task SendMessageToMdpChat(string text);
    }
}
