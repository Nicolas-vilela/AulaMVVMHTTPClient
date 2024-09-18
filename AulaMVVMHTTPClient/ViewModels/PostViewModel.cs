using AulaMVVMHTTPClient.Models;
using AulaMVVMHTTPClient.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AulaMVVMHTTPClient.ViewModels
{
    public partial class PostViewModel : ObservableObject
    {
        [ObservableProperty]
        List<Post> posts;
        public PostService postsService;
        private ICommand getPostsCommand;

        PostViewModel()
        {
            PostService postsService = new PostService();
            getPostsCommand = new Command(getPosts);
        }

        public async void getPosts()
        {
            //Buscar os dados da API
            Posts = await postsService.GetPosts(); 
        }
    }
}
