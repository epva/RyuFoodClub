using CouchDB.Driver;
using CouchDB.Driver.Extensions;
using CouchDB.Driver.Types;

namespace RyuFoodClub.Model.CouchDB
{
    public interface ICouchDbContext
    {
        ICouchDatabase<T> GetCollection<T>(string name) where T: CouchDocument;
    }  
} 