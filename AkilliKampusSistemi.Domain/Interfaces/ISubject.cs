using AkilliCampusSistemi.Domain.Models;

namespace AkilliCampusSistemi.Domain.Interfaces
{
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify(Announcement announcement);
    }
}