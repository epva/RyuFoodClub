using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using CouchDB.Driver.Types;

namespace RyuFoodClub.Model
{
    public class Dog: CouchDocument
   {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdMongo { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
   } 
}
