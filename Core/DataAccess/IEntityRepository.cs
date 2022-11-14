using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T:class, IEntity, new()
    { 
         
        List<T> GetAll(Expression<Func<T, bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Delete(T Tentity);
        void Add(T Tentity);
        void Update(T Tentity);


    }
}
