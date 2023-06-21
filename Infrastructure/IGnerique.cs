using Domain.Models;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Infrastructure
{
    public interface IGenerique<T> where T : Common
    {
        IReadOnlyList<T> GetAll();
        string GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        void addOne(T item);
        void RemoveOne(int id);
        void UpdateOne(T item);
        T getOne(int id);
    }
}
