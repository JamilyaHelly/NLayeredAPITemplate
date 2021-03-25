using System.Collections.Generic;

namespace Web.DTOs
{
    public class CountryWithCityDto:CountryDto
    {
        public ICollection<CityDto> Cities {get;set;}
    }
}