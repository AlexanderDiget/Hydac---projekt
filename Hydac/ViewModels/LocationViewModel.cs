using Hydac.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac.ViewModels
{
    public class LocationViewModel
    {
        private LocationRepository locationRepo = new LocationRepository();
        public ObservableCollection<Location> LocationsVM { get; set; } = new ObservableCollection<Location>();

        public LocationViewModel() 
        {
            foreach (var item in locationRepo._locations)
            {
                LocationsVM.Add(item);
            }
        }
    }
}
