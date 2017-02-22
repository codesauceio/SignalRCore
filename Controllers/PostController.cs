using System.Collections.Generic;
using CoreWebTest.Data;
using CoreWebTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Infrastructure;

public class PostsController : Controller
{
    private IPostRepository _postRepository { get; set; }
    private IConnectionManager _connectionManager {get; set; }

    public PostsController(IPostRepository postRepository, IConnectionManager connectionManager)
    {
        _postRepository = postRepository;
        _connectionManager = connectionManager;
    }

    [HttpGet]
    public List<Post> GetPosts()
    {
        return _postRepository.GetAll();
    }

    [HttpGet]
    public Post GetPost(int id)
    {
        return _postRepository.GetPost(id);
    }

    [HttpPost]
    public void AddPost(Post post)
    {
        _postRepository.AddPost(post);
        _connectionManager.GetHubContext<PostsHub>().Clients.All.publishPost(post);
    }
}