using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Core.Models
{
    public class User
    {
        public User()
        {
            Orders = new Collection<Order>();
            Address= new Collection<Address>();
        }
               
        public int  Id{ get; set; }
        public string Name { get; set; }
        public string Surname  { get; set; }
        public int  IdentityNumber { get; set; }
        public string TelefonNumber  { get; set; }
        public ICollection <Order> Orders { get; set; }
        public ICollection<Address> Address { get; set; }
        
        
        
        


        
        
       
        
                
        
     
    }
}