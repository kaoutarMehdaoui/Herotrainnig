using Application.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Text.Json.Serialization;
using System.Text.Json;
using Infrastructure.contrat;

namespace Application.Repository
{
    public class GeneriqueImp<T> : IGenerique<T> where T : Common
    {
        private readonly MyContext _context;
        private readonly DbSet<T> _dbSet;

        public GeneriqueImp(MyContext myContext)
        {
            _context = myContext;
             _dbSet = _context.Set<T>();
        }
        public void addOne(T item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public IReadOnlyList<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public string  GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _dbSet;

            if (include != null)

            {

                query = include(query);

            }
            var data = query.ToList();
            var options = new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve };
            var serializedData = JsonSerializer.Serialize(data, options); // Return the serialized data
            return serializedData;

            
        }

        public T getOne(int id)
        {
            return _dbSet.FirstOrDefault(x=>x.Id == id);
           
        }

        public void RemoveOne(int id)
        {
            var itemToRemove= _dbSet.FirstOrDefault(_ => _.Id == id);
            if (itemToRemove != null)
            {
                _dbSet.Remove(itemToRemove);
                _context.SaveChanges();
            }
        }

        public void UpdateOne(T item)
        {
            this._context.Update(item);
            this._context.SaveChanges();
        }
    }
}
