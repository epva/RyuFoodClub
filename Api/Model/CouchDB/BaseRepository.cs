using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouchDB.Driver;
using CouchDB.Driver.Extensions;
using CouchDB.Driver.Options;
using CouchDB.Driver.Types;
using RyuFoodClub.Model;

namespace RyuFoodClub.Model.CouchDB
{
    public abstract class BaseRepository<TEntity>:
        IBaseRepository<TEntity>
        where TEntity : CouchDocument
    {
        protected readonly ICouchDbContext _context;
        protected ICouchDatabase<TEntity> _dbCollection;
 
        protected BaseRepository(ICouchDbContext context)
        {
            _context = context;
            _dbCollection = _context.GetCollection<TEntity>(typeof(TEntity).Name.ToLower());
        }

        public async Task Create(TEntity obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(typeof(TEntity).Name + " object is null");
            }
            await _dbCollection.AddOrUpdateAsync(obj);
        }
 
        public void Delete(string id)
        {
            TEntity obj = _dbCollection.FindAsync(id).Result;
            _dbCollection.RemoveAsync(obj).Wait();
 
        }

        public virtual void Update(string id, TEntity obj)
        {
            _dbCollection.AddOrUpdateAsync(obj).Wait();
        }
 
        public async Task<TEntity> Get(string id)
        {
            return await _dbCollection.FindAsync(id);
        }
 
 
        public async Task<IEnumerable<TEntity>> Get()
        {
            return await _dbCollection.ToListAsync();
        }
    }
}
    