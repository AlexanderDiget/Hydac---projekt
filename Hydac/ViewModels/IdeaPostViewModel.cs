using Hydac.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac.ViewModels
{
    public class IdeaPostViewModel
    {
        private IdeaPostRepository ideaPostRepo = new IdeaPostRepository();
        public ObservableCollection<IdeaPost> IdeaPostsVM { get; set; } = new ObservableCollection<IdeaPost>();

        public IdeaPostViewModel()
        {
            foreach (var item in ideaPostRepo._ideaPosts)
            {
                IdeaPostsVM.Add(item);
            }
        }
    }
}
