using System.Threading.Tasks;
using Tweetbook.Contracts.V1.Requests;
using Refit;

namespace Tweetbook.API.SDK.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var tweetbookApi = RestService.For<ITweetbookApi>("https://localhost:5001");

            var postCreated = await tweetbookApi.CreateAsync(new CreatePostRequest
            {
                Name = "Created from SDK"
            });

            var post = await tweetbookApi.GetAsync(postCreated.Content.Id);

            var postUpdated = await tweetbookApi.UpdateAsync(post.Content.Id, new UpdatePostRequest
            {
                Name = "Updated from SDK"
            });

            var allPosts = await tweetbookApi.GetAllAsync();

            await tweetbookApi.DeleteAsync(post.Content.Id);
        }
    }
}
