using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Core.Models
{
    public class Country
    {

        public Country()
        {
            Cities=new Collection<City>();
        }
        public int  Id { get; set; }
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }
        
        
        
            
            
            
        
        
    }
}