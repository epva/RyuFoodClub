using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using CouchDB.Driver.Types;

namespace RyuFoodClub.Model
{
     public class DogEvent: CouchDocument
     {
          [BsonId]
          [BsonRepresentation(BsonType.ObjectId)]
          public override string Id 
          {
               get { return base.Id; }
               set  { base.Id = value; }
          }
          public DateTime Time { get; set; }
          public string Name { get; set; }      
     } 
}





