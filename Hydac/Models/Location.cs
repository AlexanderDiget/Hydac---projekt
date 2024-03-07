using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac.Models
{
    public class Location
    {
        public int LocationId { get; }
        public string LocationName { get; set; }
        public string LocationAddress { get; set; }
        public string LocationPhone { get; set; }

        //Constructor fra vores DCD
        //public Location(string locationName, string locationAddress, string locationPhone) 
        //{
        //    LocationName = locationName;
        //    LocationAddress = locationAddress;
        //    LocationPhone = locationPhone;

        //}

        //Constructor taget ud fra PetParadise
        public Location(int locationId)
        {
            LocationId = locationId;
        }

    }
}
