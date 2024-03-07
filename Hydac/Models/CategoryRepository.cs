using Hydac.Enums;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac.Models
{
    public class CategoryRepository
    {
        public List<Category> _categories { get; set; } = new List<Category>();
        private readonly string ConnectionString;

        #region Constructor
        public CategoryRepository()
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            string? ConnectionString = config.GetConnectionString("MyDBConnection");

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select CategoryType, CategoryOtherType FROM CATEGORY", con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int categoryId = int.Parse(dr["CategoryId"].ToString());
                        Category category = new Category(categoryId)
                        {

                            CategoryType = Enum.Parse<CategoryTypes>(dr["CategoryType"].ToString()),
                            CategoryOtherType = dr["CategoryOtherType"].ToString()

                        };
                        _categories.Add(category);

                    }

                }
            }
        }
        #endregion

        #region Get Methods
        public List<Category> GetAll()
        {
            return _categories;
        }

        public Category GetById(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select CategoryType, CategoryOtherType FROM CATEGORY WHERE CategoryId =  @CategoryId", con);
                cmd.Parameters.AddWithValue("CategoryId", id);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int categoryId = int.Parse(dr["CategoryId"].ToString());
                        Category category = new Category(categoryId)
                        {

                            CategoryType = Enum.Parse<CategoryTypes>(dr["CategoryType"].ToString()),
                            CategoryOtherType = dr["CategoryOtherType"].ToString()

                        };
                        return category;

                    }

                }
            }
            return null;
        }
        #endregion

        #region CRUD
        public int Add(Category category)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO CATEGORY(CategoryType, CategoryOtherType)" + "VALUES(@CategoryType, @CategoryOtherType)" + "SELECT IDENTITY", con);
                cmd.Parameters.Add("@CategoryType", SqlDbType.NVarChar).Value = category.CategoryType;
                cmd.Parameters.Add("@CategoryOtherType", SqlDbType.NVarChar).Value = category.CategoryOtherType;

            }
            _categories.Add(category);

            return category.CategoryId;
        }
        public void Update(Category category)
        {
            // Update existing category in database
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE category SET CategoryType = @CategoryType, CategoryOtherType = @CategoryOtherType WHERE CategoryId = @CategoryId", con);
                cmd.Parameters.Add("@CategoryId", SqlDbType.NVarChar).Value = category.CategoryId;
                cmd.ExecuteNonQuery();
            }

        }

        public void Remove(Category category)
        {
            // Delete existing location in database
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM CATEGORY WHERE CategoryId = @CategoryId", con);
                cmd.Parameters.Add("@CategoryId", SqlDbType.NVarChar).Value = category.CategoryId;
                cmd.ExecuteNonQuery();
            }
            _categories.Remove(category);

        }
        #endregion
    }
}


