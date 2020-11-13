namespace RyuFoodClub.Model.CouchDB
{
    public interface ICouchDatabaseSettings
    {
        string ServerUrl { get; set; } 
        string User  { get; set; }
        string Password  { get; set; }
   } 
}
