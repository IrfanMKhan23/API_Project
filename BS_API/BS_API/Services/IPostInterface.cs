using BS_API.Common;
using System.Collections.Generic;
using System.Data;

namespace BS_API.Services
{
    public interface IPostInterface
    {

        public DataTable GetPosts();
        public DataSet SearchPosts(string id);
        public DataTable GetComments();

        public void LikeComment(string id);
        public void DislikeComment(string id);

    }
}
