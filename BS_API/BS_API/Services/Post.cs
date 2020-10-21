using System;
using BS_API.Common;
using System.Collections.Generic;
using System.Data;

namespace BS_API.Services
{
    public class Post : IPostInterface
    {
        private readonly List<PostProduct> _productItems;

        //public List<PostProduct> GetProducts()

        public DataTable GetPosts()
        {
            DatabaseManager dtm = new DatabaseManager();
            DataTable dt = dtm.GetDataPost();
            return dt;
        }
        public DataSet SearchPosts(string id)
        {
            DatabaseManager dtm = new DatabaseManager();
            DataSet dt = dtm.SearchDataPost(id);
            return dt;
        }
        public DataTable GetComments()
        {
            DatabaseManager dtm = new DatabaseManager();
            DataTable dt = dtm.GetDataComment();
            return dt;
        }

        public void LikeComment(string id)
        {
            try
            {
                DatabaseManager dtm = new DatabaseManager();
                dtm.LikeComment(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DislikeComment(string id)
        {
            try
            {
                DatabaseManager dtm = new DatabaseManager();
                dtm.DisLikeComment(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
