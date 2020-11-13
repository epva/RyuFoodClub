namespace RyuFoodClub.Model.CouchDB
{
    public class CouchDatabaseSettings: ICouchDatabaseSettings
    {
        public string ServerUrl { get; set; } 
        public string User  { get; set; }
        public string Password  { get; set; }
   } 
}
