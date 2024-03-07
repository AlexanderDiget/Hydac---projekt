using Hydac.Enums;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac.Models
{
    public class UserRepository
    {
        public List<User> _users { get; set; } = new List<User>();
        private readonly string ConnectionString;

        #region Constructor
        public UserRepository()
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            string? ConnectionString = config.GetConnectionString("MyDBConnection");

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select UserName, UserEmail, UserType FROM USER", con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int userId = int.Parse(dr["UserId"].ToString());
                        User user = new User(userId)
                        {


                            UserName = dr["UserName"].ToString(),
                            UserEmail = dr["UserEmail"].ToString(),
                            UserType = Enum.Parse<UserTypes>(dr["UserType"].ToString())


                        };
                        _users.Add(user);

                    }

                }
            }
        }
        #endregion

        #region Get Methods
        public List<User> GetAll()
        {
            return _users;
        }
       

        public User GetById(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select UserName, UserEmail, UserType FROM USER WHERE UserId = @UserId", con);
                cmd.Parameters.AddWithValue("UserId", id);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int userId = int.Parse(dr["UserId"].ToString());
                        User user = new User(userId)
                        {


                            UserName = dr["UserName"].ToString(),
                            UserEmail = dr["UserEmail"].ToString(),
                            UserType = Enum.Parse<UserTypes>(dr["UserType"].ToString())


                        };
                        return user;

                    }

                }
            }
            return null;
        }
        #endregion

        #region CRUD
        public int Add(User user)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO USER(UserName, UserEmail, UserType)" + "VALUES(@UserName, @UserEmail, @UserType)" + "SELECT IDENTITY", con);
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = user.UserName;
                cmd.Parameters.Add("@UserEmail", SqlDbType.NVarChar).Value = user.UserEmail;
                cmd.Parameters.Add("@UserType", SqlDbType.NVarChar).Value = user.UserType;

            }
            _users.Add(user);

            return user.UserId;
        }

        public void Update(User user)
        {
            // Update existing user on database

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE user SET UserName = @UserName, UserEmail = @UserEmail, UserType = @UserType WHERE UserId = @UserId", con);
                cmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = user.UserId;
                cmd.ExecuteNonQuery();
            }

        }

        public void Remove(User user)
        {
            // Delete existing user in database
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM USER WHERE UserId = @UserId", con);
                cmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = user.UserId;
                cmd.ExecuteNonQuery();
            }
            _users.Remove(user);

        }
        #endregion
    }
}

