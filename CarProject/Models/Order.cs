using CarProject.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.Models
{
   public class Order
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }

        public static List<Order> GetOrder(int? id)
        {
            return OrderDAO.geOrders(id);
        }
        public bool SaveOrder()
        {
            return OrderDAO.saveOrder(this);
        }
        public static bool SaveOrderStatus(int orderId,int statusId)
        {
            return OrderDAO.setOrderStatus(orderId,statusId);
        }

    }
}
