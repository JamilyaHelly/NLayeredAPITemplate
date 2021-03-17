using System.Collections.Generic;

namespace API.DTOs
{
    public class CountryWithCityDto:CountryDto
    {
        public ICollection<CityDto> Cities {get;set;}
    }
}