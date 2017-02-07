using CarProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.DAO
{
    class CategoryDAO
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["CarProjectConnectionString"].ConnectionString;

        public static bool saveCategory(Category newCategory)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SaveCategory", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@CategoryName", newCategory.CategoryName);



                        command.ExecuteNonQuery();

                        return true;
                    }
                    catch (Exception ex)
                    {
                    }
                    return false;
                }
            }
        }
        public static List<Category> getGategories(int? CategoryId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetCategory", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (CategoryId != null)
                        {
                            command.Parameters.AddWithValue("@CategoryId", CategoryId);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@CategoryId", DBNull.Value);
                        }

                        SqlDataReader rdr = command.ExecuteReader();
                        List<Category> categoryList = new List<Category>();

                        while (rdr.Read())
                        {
                            Category category = new Category();
                            category.Id = Convert.ToInt32(rdr["Id"]);
                            category.CategoryName = rdr["CategoryName"].ToString();

                            categoryList.Add(category);
                        }
                        return categoryList;
                    }
                    catch (Exception ex)
                    {
                    }
                    return null;
                }
            }

        }

    }
}
