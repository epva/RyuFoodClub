using Microsoft.Extensions.Options;
using RyuFoodClub.Model;

namespace RyuFoodClub.Model.CouchDB
{
    public class DogEventService: BaseRepository<DogEvent>, IDogEventService 
    {
        public DogEventService(ICouchDbContext context): base(context)
        {
        }
    }
}
