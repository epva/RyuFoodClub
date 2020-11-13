using MongoDB.Driver;

namespace RyuFoodClub.Model.MongoDB
{
    public interface IMongoDbContext
    {
        IMongoCollection<T> GetCollection<T>(string name); 
    }
}
