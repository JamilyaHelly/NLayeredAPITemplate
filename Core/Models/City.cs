namespace Core.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PostCode { get; set; }
        public int CountryId { get; set; }
        public virtual Country  Country { get; set; }
        
        

        
        
        

        
        
        
        
        
        
        
        
    }
}