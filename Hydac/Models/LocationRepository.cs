using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac.Models
{
    public class LocationRepository
    {
        public List<Location> _locations { get; set; } = new List<Location>();
        private readonly string ConnectionString;

        #region Constructor
        public LocationRepository()
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            string? ConnectionString = config.GetConnectionString("MyDBConnection");

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select LocationName, LocationAddress, LocationPhone FROM LOCATION", con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int locationId = int.Parse(dr["locationId"].ToString());
                        Location location = new Location(locationId)
                        {


                            LocationName = dr["LocationName"].ToString(),
                            LocationAddress = dr["LocationAdress"].ToString(),
                            LocationPhone = dr["LocationPhone"].ToString()


                        };
                        _locations.Add(location);

                    }

                }
            }
        }
        #endregion

        #region Get Methods
        public List<Location> GetAll()
        {
            return _locations;
        }


        public Location GetById(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select LocationName, LocationAddress, LocationPhone FROM LOCATION WHERE LocationId = @LocationId", con);
                cmd.Parameters.AddWithValue("@LocationId", id);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int locationId = int.Parse(dr["locationId"].ToString());
                        Location location = new Location(locationId)
                        {


                            LocationName = dr["LocationName"].ToString(),
                            LocationAddress = dr["LocationAdress"].ToString(),
                            LocationPhone = dr["LocationPhone"].ToString()


                        };
                        return location;

                    }

                }
            }


            return null;
        }
        #endregion

        #region CRUD
        public int Add(Location location)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO LOCATION(LocationName, LocationAddress, LocationPhone)" + "VALUES(@LocationName, @LocationAddress, @LocationPhone)" + "SELECT IDENTITY", con);
                cmd.Parameters.Add("@LocationName", SqlDbType.NVarChar).Value = location.LocationName;
                cmd.Parameters.Add("@LocationAddress", SqlDbType.NVarChar).Value = location.LocationAddress;
                cmd.Parameters.Add("@LocationPhone", SqlDbType.NVarChar).Value = location.LocationPhone;

            }
            _locations.Add(location);

            return location.LocationId;
        }

        public void Update(Location location)
        {
            // Update existing location in database
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE location SET LocationName = @LocationName, LocationAddress = @LocationAddress, LocationPhone = @LocationPhone WHERE LocationId = @LocationId", con);
                cmd.Parameters.Add("@LocationId", SqlDbType.NVarChar).Value = location.LocationId;
                cmd.ExecuteNonQuery();
            }

        }

        public void Remove(Location location)
        {
            // Delete existing location in database
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM LOCATION WHERE LocationId = @LocationId", con);
                cmd.Parameters.Add("@LocationId", SqlDbType.NVarChar).Value = location.LocationId;
                cmd.ExecuteNonQuery();
            }
            _locations.Remove(location);

        }
        #endregion
    }
}

