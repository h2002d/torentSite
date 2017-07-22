using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.Models
{
    public class Post
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string GeneralImage { get; set; }
        public string PostContent { get; set; }
        public int SecondaryImageId { get; set; }
        public DateTime DateAdded { get; set; }
        public int CategoryId { get; set; }
        public Decimal Price { get; set; }
        public int Quantity { get; set; }
        public List<string> SecondaryImageList { get; set; }
        public Post()
        {

        }
        public Post GetPost(int id)
        {
            //GetsPostBy ID
            return null;
        }

        public static List<Post> GetPosts(int? postId, int? CategoryId)
        {

            return postId != null ? DAO.PostDAO.getPosts(postId,null) : DAO.PostDAO.getPosts(null, CategoryId);
        }

        public static bool DeletePost(int id)
        {
            return DAO.PostDAO.deletePost(id);
        }

        public Post EditPost(int id)
        {
            //Edit Post
            //Return Post GetPost();
            return null;
        }
        public bool SavePost()
        {
            return DAO.PostDAO.savePost(this);

        }
    }
}
