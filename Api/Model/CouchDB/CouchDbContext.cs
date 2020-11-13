using CouchDB.Driver;
using CouchDB.Driver.Extensions;
using CouchDB.Driver.Types;
using RyuFoodClub;
using Microsoft.Extensions.Options;

namespace RyuFoodClub.Model.CouchDB
{
    public class CouchDbContext: ICouchDbContext
    {
        private CouchClient _couchClient;
        public CouchDbContext(IOptions<CouchDatabaseSettings> configuration)
         {
             _couchClient = new CouchClient(configuration.Value.ServerUrl,
                settings => 
                    settings.UseBasicAuthentication(configuration.Value.User,
                        configuration.Value.Password));
         }

         public ICouchDatabase<T> GetCollection<T>(string name) where T: CouchDocument
         {
             return _couchClient.GetOrCreateDatabaseAsync<T>(name).Result;
         } 
    }
}