using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hydac.Models;

namespace Hydac.ViewModels
{
    public class UserViewModel
    {
        private UserRepository userRepo = new UserRepository();
        public ObservableCollection<User> UsersVM { get; set; } = new ObservableCollection<User>();

        public UserViewModel() 
        {
            foreach (var user in userRepo._users)
            {
                UsersVM.Add(user);
            }
        }
    }
}
