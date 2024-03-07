using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hydac.Enums;

namespace Hydac.Models
{
    public class User
    {
        public int UserId { get; }
        public string UserName { get; set; }    
        public string UserEmail { get; set; }
        public UserTypes UserType { get; set; }
        
        //Constructor fra vores DCD
        //public User(string name, string email, UserTypes userType) 
        //{
        //    UserName = name;
        //    UserEmail = email;
        //    UserType = userType;

        //}

        //Constructor taget ud fra PetParadise
        public User(int userId)
        {
            UserId = userId;
        }
    }
}
