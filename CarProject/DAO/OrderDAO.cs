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
        public static List<Order> geOrders(int? id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetOrder", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (id == null)
                        {
                            command.Parameters.AddWithValue("@OrderId", DBNull.Value);
                           
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@OrderId", id);
                        }

                        SqlDataReader rdr = command.ExecuteReader();
                        List<Order> orderList = new List<Order>();

                        while (rdr.Read())
                        {
                            Order order = new Order();
                            order.Id = Convert.ToInt32(rdr["Id"]);
                            order.ItemId =Convert.ToInt32( rdr["ItemId"]);
                            order.Phone = rdr["Phone"].ToString();
                            order.StatusId = Convert.ToInt32(rdr["Status"]);
                            order.OrderDate = Convert.ToDateTime(rdr["OrderDate"]);
                            order.Quantity = Convert.ToInt32(rdr["Quantity"]);
                            order.Latitude = rdr["Latitude"].ToString();
                            order.Longitude = rdr["Longitude"].ToString();
                            order.Address = rdr["Address"].ToString();
                            order.StatusName = rdr["StatusName"].ToString();



                          
                            orderList.Add(order);
                        }
                        return orderList;
                    }
                    catch (Exception ex)
                    {
                    }
                    return null;
                }
            }

        }
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
        public static bool setOrderStatus(int orderId,int statusId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("ChangeOrderStatus", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@OrderId", orderId);
                        command.Parameters.AddWithValue("@StatusId", statusId);
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
        public static List<Status> getStatuses()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("Select * From Statuses", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.Text;
                       

                        SqlDataReader rdr = command.ExecuteReader();
                        List<Status> orderList = new List<Status>();

                        while (rdr.Read())
                        {
                            Status order = new Status();
                            order.State = rdr["Id"].ToString();
                            order.Name = rdr["StatusName"].ToString();
                            orderList.Add(order);
                        }
                        return orderList;
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
