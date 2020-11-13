using Microsoft.Extensions.Options;
using RyuFoodClub.Model;

namespace RyuFoodClub.Model.MongoDB
{
    public class DogService: BaseRepository<Dog>, IDogService 
    {
        public DogService(IMongoDbContext context): base(context)
        {
        }
    }
}
