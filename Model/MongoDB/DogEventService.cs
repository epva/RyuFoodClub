using Microsoft.Extensions.Options;
using RyuFoodClub.Model;

namespace RyuFoodClub.Model.MongoDB
{
    public class DogEventService: BaseRepository<DogEvent>, IDogEventService 
    {
        public DogEventService(IMongoDbContext context): base(context)
        {
        }
    }
}
