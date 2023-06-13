using Domain.Models;

namespace Infrastructur.Contrat
{
    public interface IGenerique<T> where T : Comman
    {
        IReadOnlyList<T> GetAll();
        void addOne(T item);
        void RemoveOne(int id);
        void UpdateOne(T item);
        T getOne(int id);
    }
}
