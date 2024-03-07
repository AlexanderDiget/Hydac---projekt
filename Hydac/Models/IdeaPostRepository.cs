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
    public class IdeaPostRepository
    {
        public List<IdeaPost> _ideaPosts { get; set; } = new List<IdeaPost>();
        private readonly string ConnectionString;

        #region Constructor
        public IdeaPostRepository()
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            string? ConnectionString = config.GetConnectionString("MyDBConnection");

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select IPTitle, IPDescription, IPDOC FROM IDEAPOST", con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int ideaPostId = int.Parse(dr["IdeapostId"].ToString());
                        IdeaPost ideapost = new IdeaPost(ideaPostId)
                        {

                            IPTitle = dr["IPTitle"].ToString(),
                            IPDescription = dr["IPDescription"].ToString(),
                            IPDOC = (dr["IPDOC"] != DBNull.Value) ? DateTime.Parse(dr["IPDOC"].ToString()) : DateTime.MinValue

                        };
                        _ideaPosts.Add(ideapost);

                    }

                }
            }
        }
#endregion

        #region Get Methods
        public List<IdeaPost> GetAll()
        {
            return _ideaPosts;
        }

        public IdeaPost GetByid(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select IPTitle, IPDescription, IPDOC FROM IDEAPOST WHERE IdeaPostId = @IdeaPostId", con);
                cmd.Parameters.AddWithValue("IdeaPostId", id);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int ideaPostId = int.Parse(dr["IdeapostId"].ToString());
                        IdeaPost ideapost = new IdeaPost(ideaPostId)
                        {

                            IPTitle = dr["IPTitle"].ToString(),
                            IPDescription = dr["IPDescription"].ToString(),
                            IPDOC = (dr["IPDOC"] != DBNull.Value) ? DateTime.Parse(dr["IPDOC"].ToString()) : DateTime.MinValue

                        };

                        return ideapost;

                    }

                }
            }

            return null;
        }
        #endregion

        #region CRUD
        public int Add(IdeaPost ideaPost)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO IDEAPOST(IPTitle, IPDescription, IPDOC)" + "VALUES(@IPTitle, @IPDescription, @IPDOC)" + "SELECT IDENTITY", con);
                cmd.Parameters.Add("@IPTitle", SqlDbType.NVarChar).Value = ideaPost.IPTitle;
                cmd.Parameters.Add("@IPDescription", SqlDbType.NVarChar).Value = ideaPost.IPDescription;
                cmd.Parameters.Add("@IPDOC", SqlDbType.DateTime2).Value = ideaPost.IPDOC;

            }
            _ideaPosts.Add(ideaPost);

            return ideaPost.IdeaPostId;
        }

        public void Update(IdeaPost ideaPost)
        {
            // Update existing post in database
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE ideaPost SET IPTitle = @IPTitle, IPDescription = @IPDescription, IPDOC = @IPDOC WHERE IdeaPostId = @IdeaPostId", con);
                cmd.Parameters.Add("@IdeaPostId", SqlDbType.NVarChar).Value = ideaPost.IdeaPostId;
                cmd.ExecuteNonQuery();
            }

        }

        public void Remove(IdeaPost ideaPost)
        {
            // Delete existing post in database
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM IDEAPOST WHERE IdeaPostId = @IdeaPostId", con);
                cmd.Parameters.Add("@IdeaPostId", SqlDbType.NVarChar).Value = ideaPost.IdeaPostId;
                cmd.ExecuteNonQuery();
            }
            _ideaPosts.Remove(ideaPost);

        }
        #endregion
    }
}
