using CarProject.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }


        private bool SaveCategory()
        {
           return CategoryDAO.saveCategory(this);
        }
        public static Category GetCategory(int? id)
        {
            return CategoryDAO.getGategories(id).FirstOrDefault();
        }
    }
}
