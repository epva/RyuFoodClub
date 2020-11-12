using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RyuFoodClub.Model
{
    public class Dog
   {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; } 
   } 
}
