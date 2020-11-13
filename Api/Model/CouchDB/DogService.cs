using Microsoft.Extensions.Options;
using RyuFoodClub.Model;

namespace RyuFoodClub.Model.CouchDB
{
    public class DogService: BaseRepository<Dog>, IDogService 
    {
        public DogService(ICouchDbContext context): base(context)
        {
        }
    }
}
