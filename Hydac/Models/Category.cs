using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hydac.Enums;

namespace Hydac.Models
{
    public class Category
    {
        public int CategoryId { get; }
        public CategoryTypes CategoryType { get; set; }
        public string? CategoryOtherType { get; set; }

        //Constructor fra vores DCD
        //public Category(CategoryTypes categoryType, string? categoryOtherType) 
        //{
        //    CategoryType = categoryType;
        //    CategoryOtherType = categoryOtherType;
        //}

        //Constructor taget ud fra PetParadise
        public Category(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
