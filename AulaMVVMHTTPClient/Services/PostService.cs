using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using AulaMVVMHTTPClient.Models;

namespace AulaMVVMHTTPClient.Services
{
    public class PostService
    {
        HttpClient client;
        JsonSerializerOptions options;

        public List<Post> posts;

        public PostService()
        {
            client = new HttpClient();
            options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<Post>> GetPosts()
        {
            Uri uri = new Uri("https://jsonplaceholder.typicode.com/posts");
            try
            {
                HttpResponseMessage httpResponseMessage = client.GetAsync(uri).Result;
                if(httpResponseMessage.IsSuccessStatusCode)
                {
                    string content = await httpResponseMessage.Content.ReadAsStringAsync();
                    posts = JsonSerializer.Deserialize<List<Post>>(content, options);
                }
            }
            catch(Exception ex)
            {

            }
            return posts;
        }

    }
}
