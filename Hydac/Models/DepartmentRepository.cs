using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.VisualBasic.ApplicationServices;

namespace Hydac.Models
{
    public class DepartmentRepository
    {
        public List<Department> _departments { get; set; } = new List<Department>();
        private readonly string ConnectionString;

        #region Constructor
        public DepartmentRepository() 
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            string? ConnectionString = config.GetConnectionString("MyDBConnection");

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select DepartmentType, DepartmentManager, DepartmentPhone FROM DEPARTMENT", con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int departmentId = int.Parse(dr["DepartmentId"].ToString());
                        Department department = new Department(departmentId)
                        {


                            DepartmentType = dr["DepartmentType"].ToString(),
                            DepartmentManager = dr["DepartmentManager"].ToString(),
                            DepartmentPhone = dr["DepartmentPhone"].ToString()
                            

                        };
                        _departments.Add(department);

                    }

                }
            }
        }
#endregion

        #region Get Methods
        public List<Department> GetAll()
        {
            return _departments;
        }
        
        public Department GetById(int Id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select DepartmentType, DepartmentManager, DepartmentPhone FROM DEPARTMENT WHERE DepartmentId = @DepartmentId", con);
                cmd.Parameters.AddWithValue("DepartmentId", Id);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int departmentId = int.Parse(dr["DepartmentId"].ToString());
                        Department department = new Department(departmentId)
                        {


                            DepartmentType = dr["DepartmentType"].ToString(),
                            DepartmentManager = dr["DepartmentManager"].ToString(),
                            DepartmentPhone = dr["DepartmentPhone"].ToString()


                        };
                        return department;

                    }

                }
            }
            return null;
        }
#endregion

        #region CRUD
        public int Add(Department department)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO DEPARTMENT(DepartmentType, DepartmentManager, DepartmentPhone)" + "VALUES(@DepartmentType, @DepartmentManager, @DepartmentPhone)" + "SELECT IDENTITY", con);
                cmd.Parameters.Add("@DepartmentType", SqlDbType.NVarChar).Value = department.DepartmentType;
                cmd.Parameters.Add("@DepartmentManager", SqlDbType.NVarChar).Value = department.DepartmentManager;
                cmd.Parameters.Add("@DepartmentPhone", SqlDbType.NVarChar).Value = department.DepartmentPhone;

            }
            _departments.Add(department);

            return department.DepartmentId;
        }

        public void Update(Department department)
        {
            // Update existing department in database
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE department SET DepartmentType = @DepartmentType, DepartmentManager = @DepartmentManager, DepartmentPhone = @DepartmentPhone WHERE DepartmentId = @DepartmentId", con);
                cmd.Parameters.Add("@DepartmentId", SqlDbType.NVarChar).Value = department.DepartmentId;
                cmd.ExecuteNonQuery();
            }

        }

        public void Remove(Department department)
        {
            // Delete existing department in database
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM DEPARTMENT WHERE DepartmentId = @DepartmentId", con);
                cmd.Parameters.Add("@DepartmentId", SqlDbType.NVarChar).Value = department.DepartmentId;
                cmd.ExecuteNonQuery();
            }
            _departments.Remove(department);

        }
#endregion
    }
}
