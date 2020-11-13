using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RyuFoodClub.Model
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {       
            Task Create(TEntity obj);
            void Update(string id, TEntity obj);
            void Delete(string id);
            Task<TEntity> Get(string id);
            Task<IEnumerable<TEntity>> Get();
    }
}
