using System.Collections.Generic;
using CoreWebTest.Models;

namespace CoreWebTest.Data
{
    public interface IPostRepository
    {
        List<Post> GetAll();
        Post GetPost(int id);
        void AddPost(Post post);
    }
}
