namespace AkilliCampusSistemi.Domain.Interfaces
{
    public interface INotificationService
    {
        void SendNotification(string recipientName, string message);
    }
}