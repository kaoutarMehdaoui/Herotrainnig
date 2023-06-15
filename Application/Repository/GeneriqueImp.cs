using Application.Data;
using Domain.Models;
using Infrastructur.Contrat;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class GeneriqueImp<T> : IGenerique<T> where T : Comman
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
