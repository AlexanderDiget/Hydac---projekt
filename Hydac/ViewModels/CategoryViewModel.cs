using Hydac.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac.ViewModels
{
    public class CategoryViewModel
    {
        private CategoryRepository categoryRepo = new CategoryRepository();
        public ObservableCollection<Category> CategoriesVM { get; set; } = new ObservableCollection<Category>();

        public CategoryViewModel()
        {
            foreach (var item in categoryRepo._categories)
            {
                CategoriesVM.Add(item);
            }
        }
    }
}
