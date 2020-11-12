using MongoDB.Driver;
using RyuFoodClub;
using Microsoft.Extensions.Options;
using RyuFoodClub.Model;

namespace RyuFoodClub.Model.MongoDB
{
    public class MongoDbContext : IMongoDbContext
   {
       private IMongoDatabase _db { get; set; }
       private MongoClient _mongoClient { get; set; }
       public IClientSessionHandle Session { get; set; }
       public MongoDbContext(IOptions<MongoDatabaseSettings> configuration)
       {
           _mongoClient = new MongoClient(configuration.Value.ConnectionString);
           _db =_mongoClient.GetDatabase(configuration.Value.DatabaseName);
       }
      
       public IMongoCollection<T> GetCollection<T>(string name)
       {
           return _db.GetCollection<T>(name);
       }
   }
}