using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using RyuFoodClub.Model;

namespace RyuFoodClub.Model.MongoDB
{
    public abstract class BaseRepository<TEntity>:
        IBaseRepository<TEntity>
        where TEntity : class
    {
        protected readonly IMongoDbContext _context;
        protected IMongoCollection<TEntity> _dbCollection;
  
        protected BaseRepository(IMongoDbContext context)
        {
            _context = context;
            _dbCollection = _context.GetCollection<TEntity>(typeof(TEntity).Name);
        }
        public async Task Create(TEntity obj)
        {
            if(obj == null)
            {
                throw new ArgumentNullException(typeof(TEntity).Name + " object is null");
            }
            _dbCollection = _context.GetCollection<TEntity>(typeof(TEntity).Name);
            await _dbCollection.InsertOneAsync(obj);
        }
 
        public void Delete(string id)
        {
            //ex. 5dc1039a1521eaa36835e541
 
            var objectId = new ObjectId(id);
            _dbCollection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", objectId));
 
        }

        public virtual void Update(string id, TEntity obj)
        {
            _dbCollection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", id), obj);
        }
 
        public async Task<TEntity> Get(string id)
        {
            //ex. 5dc1039a1521eaa36835e541
            var objectId = new ObjectId(id);
            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("_id", objectId);
            _dbCollection = _context.GetCollection<TEntity>(typeof(TEntity).Name);
            return await _dbCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
        }
 
        public async Task<IEnumerable<TEntity>> Get()
        {
            var all = await _dbCollection.FindAsync(Builders<TEntity>.Filter.Empty);
            return await all.ToListAsync();
        }
    }
}
    