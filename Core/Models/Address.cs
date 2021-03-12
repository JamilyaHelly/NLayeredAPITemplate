namespace Core.Models
{
    public class Address
    {
        public int  Id { get; set; }
        public string  HomeNumber { get; set; }
        public string Description { get; set; }
        public int  CityId { get; set; }
        public virtual City  City { get; set; }
        
        

        
        
        
        
        
        
        
        
    }
}