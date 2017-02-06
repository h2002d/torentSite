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
    class OrderDAO
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["CarProjectConnectionString"].ConnectionString;

        public static bool saveOrder(Order newOrder)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SaveOrder", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                     
                        command.Parameters.AddWithValue("@ItemId", newOrder.ItemId); 
                        command.Parameters.AddWithValue("@Phone", newOrder.Phone);

                        command.Parameters.AddWithValue("@Address", newOrder.Address);
                        command.Parameters.AddWithValue("@Latitude", newOrder.Latitude);
                        command.Parameters.AddWithValue("@Longitude", newOrder.Longitude);
                        command.Parameters.AddWithValue("@StatusId", newOrder.StatusId);
                        command.Parameters.AddWithValue("@Quantity", newOrder.Quantity);



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
    }
}
